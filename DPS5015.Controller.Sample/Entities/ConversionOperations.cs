using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DPS5015.Controller.Sample.Entities
{
    public static class ConversionOperations
    {
        public static string ConvertHexToDec(byte value1, byte value2)
        {
            string value1Hex = value1.ToString("X");
            string value2Hex = value2.ToString("X");
            if (Convert.ToInt32(value2Hex) < 9)
            {
                value1Hex += "0";
            }
            string fullValueHex = value1Hex + value2Hex;
            double valueDec = Convert.ToInt32(fullValueHex, 16);
            valueDec /= 100;
            return valueDec.ToString("F2", CultureInfo.InvariantCulture);
        }

        public static byte[] GenerateInputCode(int voltage, int current)
        {
            //01 - slave address
            //10 - function code
            //00 00 - register starting address
            //00 02 - registers to write to
            //04 - bytes to write
            //XX XX -voltage
            //XX XX -current
            //XX XX -CRC code

            byte slaveAddress = 0x1;
            byte functionCode = 0x10;
            ushort startAddress = 0x0;
            ushort numberOfPoints = 0x2;
            byte bytesToWrite = 0x4;
            ushort voltageToSet = (ushort)voltage;
            ushort currentToSet = (ushort)current;

            List<byte> entryCode = new List<byte>();

            entryCode.Add(slaveAddress);
            entryCode.Add(functionCode);
            entryCode.Add((byte)(startAddress >> 8));
            entryCode.Add((byte)startAddress);
            entryCode.Add((byte)(numberOfPoints >> 8));
            entryCode.Add((byte)numberOfPoints);
            entryCode.Add(bytesToWrite);
            entryCode.Add((byte)(voltageToSet >> 8));
            entryCode.Add((byte)voltageToSet);
            entryCode.Add((byte)(currentToSet >> 8));
            entryCode.Add((byte)currentToSet);

            int entryCodeSize = entryCode.Count;

            byte[] frame = new byte[entryCodeSize + 2];

            for (int i = 0; i <= entryCodeSize - 1; i++)
            {
                frame[i] = entryCode[i];
            }

            byte[] checkSum = CRC16(frame);
            frame[entryCodeSize] = checkSum[0];
            frame[entryCodeSize + 1] = checkSum[1];

            //string outputText = "";

            //foreach (byte n in frame)
            //{
            //    outputText += " " + string.Format("{0:X2} ", n);
            //}

            //return outputText.Trim();
            return frame;
        }

        private static byte[] CRC16(byte[] data)
        {
            byte[] checkSum = new byte[2];
            ushort reg_crc = 0XFFFF;

            for (int i = 0; i < data.Length - 2; i++)
            {
                reg_crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((reg_crc & 0x01) == 1)
                    {
                        reg_crc = (ushort)((reg_crc >> 1) ^ 0xA001);
                    }
                    else
                    {
                        reg_crc = (ushort)(reg_crc >> 1);
                    }
                }
            }
            checkSum[1] = (byte)((reg_crc >> 8) & 0xFF);
            checkSum[0] = (byte)((reg_crc & 0xFF));
            return checkSum;
        }
    }
}
