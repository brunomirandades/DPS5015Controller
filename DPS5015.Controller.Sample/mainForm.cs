using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;
using DPS5015.Controller.Sample.Entities;
using DPS5015.Controller.Sample.Entities.Enums;
using Microsoft.Win32;
using System.IO;
using System.Deployment.Application;

namespace DPS5015.Controller.Sample
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            SetAddRemoveProgramsIcon();
            //setting standard baudrate
            baudrateTextBox.Text = "9600";
        }

        //new var for holding the serial connection
        public SerialPort sPort;
        Parity standardParity = (Parity)Enum.Parse(typeof(Parity), "None");
        int standardDatabits = 8;
        StopBits standardStopbits = (StopBits)Enum.Parse(typeof(StopBits), "One");

        //new analysis instance
        Analysis analysis = new Analysis();

        //set clickonce application icon
        private void SetAddRemoveProgramsIcon()
        {
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    var iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "MyIcon.ico");

                    if (!File.Exists(iconSourcePath)) return;

                    var myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    if (myUninstallKey == null) return;

                    var mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    foreach (var subkeyName in mySubKeyNames)
                    {
                        var myKey = myUninstallKey.OpenSubKey(subkeyName, true);
                        var myValue = myKey.GetValue("DisplayName");
                        if (myValue != null && myValue.ToString() == "DPS5015Controller") // same as in 'Product name:' field
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch (Exception uhoh)
                {
                    return;
                }
            }
        }

        private void EnableButtons()
        {
            inSetButton.Enabled = true;
            readInButton.Enabled = true;
            inLockButton.Enabled = true;
            inUnlockButton.Enabled = true;
            outOnButton.Enabled = true;
            outOffButton.Enabled = true;
            readOutButton.Enabled = true;
        }

        private void DisableButtons()
        {
            inSetButton.Enabled = false;
            readInButton.Enabled = false;
            inLockButton.Enabled = false;
            inUnlockButton.Enabled = false;
            outOnButton.Enabled = false;
            outOffButton.Enabled = false;
            readOutButton.Enabled = false;
        }

        private void comPortComboBox_Click(object sender, EventArgs e)
        {
            comPortComboBox.Items.Clear();
            //getting the ports by clicking the combo box
            foreach (String s in SerialPort.GetPortNames())
            {
                comPortComboBox.Items.Add(s);
            }
        }

        public void SerialPort_Connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            try
            {
                //connecting and defining the event handler
                sPort = new SerialPort(port, baudrate, parity, databits, stopbits);
                sPort.ReadTimeout = 500;
                sPort.Close();
                sPort.Open();
                sPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            }
            catch (Exception e) {
                //MessageBox.Show(e.ToString(), "Opening Port Error!"); 
                return;
            }
        }

        public void SerialPort_Disconnect()
        {
            try
            {
                if (sPort.IsOpen)
                {
                    sPort.Close();
                }
            }
            catch (Exception) {
                //MessageBox.Show(e.ToString(), "Closing Port Error!");
                return;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string message = "";
                int length = sPort.BytesToRead;
                byte[] buf = new byte[length];

                string bufferStr = "";

                List<string> bufferStrList = new List<string>();

                sPort.Read(buf, 0, length);

                foreach (byte b in buf)
                {
                    string bString = b.ToString();
                    bufferStrList.Add(bString);
                }

                foreach (string s in bufferStrList)
                {
                    bufferStr += " " + s;
                }

                string standardResponse;

                //switch with the response for each operation defined in the analysis operation property
                switch (analysis.Operation)
                    {
                        case OperationType.SetInput:
                            //compare the response with the standard response to confirm operation
                            standardResponse = " 1 16 0 0 0 2 65 200";
                            if (bufferStr == standardResponse)
                            {
                                message = "Input set successfully";
                            }
                            else { throw new ApplicationException("Input set not successful"); }
                            break;
                        case OperationType.ReadInput:
                        //convert from hex and concatenate the indexes: 3 and 4 (voltage), 5 and 6 (current)
                            string inputVoltage = ConversionOperations.ConvertHexToDec(buf[3], buf[4]);
                            string inputCurrent = ConversionOperations.ConvertHexToDec(buf[5], buf[6]);
                            message = $"Input: {inputVoltage}V {inputCurrent}A";
                        break;
                        case OperationType.LockInput:
                            //compare the response with the standard response to confirm operation
                            standardResponse = " 1 16 0 6 0 1 225 200";
                            if (bufferStr == standardResponse)
                            {
                                message = "Input locked";
                            }
                            else { throw new ApplicationException("Input not locked"); }
                            break;
                        case OperationType.UnlockInput:
                            //compare the response with the standard response to confirm operation
                            standardResponse = " 1 16 0 6 0 1 225 200";
                            if (bufferStr == standardResponse)
                            {
                                message = "Input unlocked";
                            }
                            else { throw new ApplicationException("Input not unlocked"); }
                            break;
                        case OperationType.ReadOutput:
                            //convert from hex and concatenate the indexes: 2 and 3 (voltage), 4 and 5 (current)
                            string outputVoltage = ConversionOperations.ConvertHexToDec(buf[3], buf[4]);
                            string outputCurrent = ConversionOperations.ConvertHexToDec(buf[5], buf[6]);
                            message = $"Output: {outputVoltage}V {outputCurrent}A";
                            break;
                        case OperationType.ActivateOutput:
                            //compare the response with the standard response to confirm operation
                            standardResponse = " 1 16 0 9 0 1 209 203";
                            if (bufferStr == standardResponse)
                            {
                                message = "Output ON";
                            }
                            else { throw new ApplicationException("Output not ON"); }
                            break;
                        case OperationType.DeactivateOutput:
                            //compare the response with the standard response to confirm operation
                            standardResponse = " 1 16 0 9 0 1 209 203";
                            if (bufferStr == standardResponse)
                            {
                                message = "Output OFF";
                            }
                            else { throw new ApplicationException("Output not OFF"); }
                            break;
                        default:
                            break;
                    }

                //message = bufferStr;

                logListBox.Items.Add(message);

                SerialPort_Disconnect();
                //EnableButtons();
            }
            catch (ApplicationException ex) { logListBox.Items.Add(ex.Message); }
            catch (Exception) { return; }
        }

        private void readOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort_Disconnect();
                //DisableButtons();

                analysis.Operation = OperationType.ReadOutput;

                string port = comPortComboBox.Text;
                int baudrate = Convert.ToInt32(baudrateTextBox.Text);
                SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

                String data = "01 03 00 02 00 02 65 cb"; //read output

                byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
                sPort.Write(bytes, 0, bytes.Length); //send as hex

                //String data = "01 03 00 02 00 02 65 cb"; //read output
                //String data = "01 03 00 00 00 02 c4 0b"; //read input
                //String data = "01 10 00 00 00 02 04 00 9f 05 dc c1 48"; //set input
                //String data = "01 10 00 06 00 01 02 00 00 a6 36"; //unlock input
                //String data = "01 10 00 06 00 01 02 00 01 67 f6"; //lock input
                //String data = "01 10 00 09 00 01 02 00 01 67 09"; //output on
                //String data = "01 10 00 09 00 01 02 00 00 a6 c9"; //output off
            }
            catch (Exception ex) {
                MessageBox.Show("Command could not be sent.\nPlease check the port configuration settings.", "Error!");
                EnableButtons();
                //MessageBox.Show(ex.Message.ToString(), "Error!");
                //return;
            }
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
        }

        private void readInButton_Click(object sender, EventArgs e)
        {
            try
            {
                //DisableButtons();
                SerialPort_Disconnect();

                analysis.Operation = OperationType.ReadInput;

                string port = comPortComboBox.Text;
                int baudrate = Convert.ToInt32(baudrateTextBox.Text);
                SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

                String data = "01 03 00 00 00 02 c4 0b"; //read input

                byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
                sPort.Write(bytes, 0, bytes.Length); //send as hex
            }
            catch (Exception)
            {
                MessageBox.Show("Command could not be sent.\nPlease check the port configuration settings.", "Error!");
                EnableButtons();
            }
        }

        private void inLockButton_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort_Disconnect();
                //DisableButtons();

                analysis.Operation = OperationType.LockInput;

                string port = comPortComboBox.Text;
                int baudrate = Convert.ToInt32(baudrateTextBox.Text);
                SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

                String data = "01 10 00 06 00 01 02 00 01 67 f6"; //lock input

                byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
                sPort.Write(bytes, 0, bytes.Length); //send as hex
            }
            catch (Exception)
            {
                MessageBox.Show("Command could not be sent.\nPlease check the port configuration settings.", "Error!");
                EnableButtons();
            }
        }

        private void inUnlockButton_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort_Disconnect();
                //DisableButtons();

                analysis.Operation = OperationType.UnlockInput;

                string port = comPortComboBox.Text;
                int baudrate = Convert.ToInt32(baudrateTextBox.Text);
                SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

                String data = "01 10 00 06 00 01 02 00 00 a6 36"; //unlock input

                byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
                sPort.Write(bytes, 0, bytes.Length); //send as hex
            }
            catch (Exception)
            {
                MessageBox.Show("Command could not be sent.\nPlease check the port configuration settings.", "Error!");
                EnableButtons();
            }
        }

        private void outOnButton_Click(object sender, EventArgs e)
        {
            try
            {
                //DisableButtons();
                SerialPort_Disconnect();

                analysis.Operation = OperationType.ActivateOutput;

                string port = comPortComboBox.Text;
                int baudrate = Convert.ToInt32(baudrateTextBox.Text);
                SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

                String data = "01 10 00 09 00 01 02 00 01 67 09"; //output on

                byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
                sPort.Write(bytes, 0, bytes.Length); //send as hex
            }
            catch (Exception)
            {
                MessageBox.Show("Command could not be sent.\nPlease check the port configuration settings.", "Error!");
                EnableButtons();
            }
        }

        private void outOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort_Disconnect();
                //DisableButtons();
                analysis.Operation = OperationType.DeactivateOutput;

                string port = comPortComboBox.Text;
                int baudrate = Convert.ToInt32(baudrateTextBox.Text);
                SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

                String data = "01 10 00 09 00 01 02 00 00 a6 c9"; //output off

                byte[] bytes = data.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray(); //converting as hex
                sPort.Write(bytes, 0, bytes.Length); //send as hex
            }
            catch (Exception)
            {
                MessageBox.Show("Command could not be sent.\nPlease check the port configuration settings.", "Error!");
                EnableButtons();
            }
        }

        private void inSetButton_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort_Disconnect();
                analysis.Operation = OperationType.SetInput;

                string voltTxtBoxValue = inVoltTextBox.Text.Replace(",", ".");
                string amperTxtBoxValue = inAmperTextBox.Text.Replace(",", ".");

                double inputSetVoltage = Double.Parse(voltTxtBoxValue, CultureInfo.InvariantCulture);
                double inputSetCurrent = Double.Parse(amperTxtBoxValue, CultureInfo.InvariantCulture);

                if ((inputSetVoltage > 21.00 || inputSetVoltage < 00.00) || (inputSetCurrent > 15.00 || inputSetCurrent < 00.00))
                {
                    throw new ApplicationException("Input values: " +
                        "\nVoltage: 00.00 V - 21.00 V." +
                        "\nCurrent: 00.00 A - 15.00 A.");
                }

                inputSetVoltage *= 100;
                inputSetCurrent *= 100;

                //change in the main app
                int voltage = Convert.ToInt32(inputSetVoltage);
                int current = Convert.ToInt32(inputSetCurrent);

                byte[] command = ConversionOperations.GenerateInputCode(voltage, current);

                string port = comPortComboBox.Text;
                int baudrate = Convert.ToInt32(baudrateTextBox.Text);
                SerialPort_Connect(port, baudrate, standardParity, standardDatabits, standardStopbits);

                sPort.Write(command, 0, command.Length); //send as hex
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input value.", "Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Command could not be sent.\nPlease check the port configuration settings.", "Error!");
            }
        }
    }
}
