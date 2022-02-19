namespace DPS5015.Controller.Sample
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baudrateTextBox = new System.Windows.Forms.TextBox();
            this.readInButton = new System.Windows.Forms.Button();
            this.readOutButton = new System.Windows.Forms.Button();
            this.outOnButton = new System.Windows.Forms.Button();
            this.outOffButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.inVoltTextBox = new System.Windows.Forms.TextBox();
            this.inAmperTextBox = new System.Windows.Forms.TextBox();
            this.inSetButton = new System.Windows.Forms.Button();
            this.inLockButton = new System.Windows.Forms.Button();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.comPortComboBox = new System.Windows.Forms.ComboBox();
            this.inUnlockButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate:";
            // 
            // baudrateTextBox
            // 
            this.baudrateTextBox.Location = new System.Drawing.Point(240, 12);
            this.baudrateTextBox.Name = "baudrateTextBox";
            this.baudrateTextBox.Size = new System.Drawing.Size(89, 20);
            this.baudrateTextBox.TabIndex = 3;
            // 
            // readInButton
            // 
            this.readInButton.Location = new System.Drawing.Point(171, 45);
            this.readInButton.Name = "readInButton";
            this.readInButton.Size = new System.Drawing.Size(89, 23);
            this.readInButton.TabIndex = 4;
            this.readInButton.Text = "Read";
            this.readInButton.UseVisualStyleBackColor = true;
            this.readInButton.Click += new System.EventHandler(this.readInButton_Click);
            // 
            // readOutButton
            // 
            this.readOutButton.Location = new System.Drawing.Point(222, 19);
            this.readOutButton.Name = "readOutButton";
            this.readOutButton.Size = new System.Drawing.Size(89, 23);
            this.readOutButton.TabIndex = 5;
            this.readOutButton.Text = "Read";
            this.readOutButton.UseVisualStyleBackColor = true;
            this.readOutButton.Click += new System.EventHandler(this.readOutButton_Click);
            // 
            // outOnButton
            // 
            this.outOnButton.Location = new System.Drawing.Point(6, 19);
            this.outOnButton.Name = "outOnButton";
            this.outOnButton.Size = new System.Drawing.Size(89, 23);
            this.outOnButton.TabIndex = 6;
            this.outOnButton.Text = "ON";
            this.outOnButton.UseVisualStyleBackColor = true;
            this.outOnButton.Click += new System.EventHandler(this.outOnButton_Click);
            // 
            // outOffButton
            // 
            this.outOffButton.Location = new System.Drawing.Point(113, 19);
            this.outOffButton.Name = "outOffButton";
            this.outOffButton.Size = new System.Drawing.Size(89, 23);
            this.outOffButton.TabIndex = 7;
            this.outOffButton.Text = "OFF";
            this.outOffButton.UseVisualStyleBackColor = true;
            this.outOffButton.Click += new System.EventHandler(this.outOffButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "V";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "A";
            // 
            // inVoltTextBox
            // 
            this.inVoltTextBox.Location = new System.Drawing.Point(52, 19);
            this.inVoltTextBox.Name = "inVoltTextBox";
            this.inVoltTextBox.Size = new System.Drawing.Size(89, 20);
            this.inVoltTextBox.TabIndex = 13;
            this.inVoltTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // inAmperTextBox
            // 
            this.inAmperTextBox.Location = new System.Drawing.Point(171, 19);
            this.inAmperTextBox.Name = "inAmperTextBox";
            this.inAmperTextBox.Size = new System.Drawing.Size(89, 20);
            this.inAmperTextBox.TabIndex = 14;
            this.inAmperTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // inSetButton
            // 
            this.inSetButton.Location = new System.Drawing.Point(52, 45);
            this.inSetButton.Name = "inSetButton";
            this.inSetButton.Size = new System.Drawing.Size(89, 23);
            this.inSetButton.TabIndex = 15;
            this.inSetButton.Text = "Set";
            this.inSetButton.UseVisualStyleBackColor = true;
            this.inSetButton.Click += new System.EventHandler(this.inSetButton_Click);
            // 
            // inLockButton
            // 
            this.inLockButton.Location = new System.Drawing.Point(52, 74);
            this.inLockButton.Name = "inLockButton";
            this.inLockButton.Size = new System.Drawing.Size(89, 23);
            this.inLockButton.TabIndex = 16;
            this.inLockButton.Text = "Lock";
            this.inLockButton.UseVisualStyleBackColor = true;
            this.inLockButton.Click += new System.EventHandler(this.inLockButton_Click);
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(6, 19);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(303, 134);
            this.logListBox.TabIndex = 18;
            // 
            // comPortComboBox
            // 
            this.comPortComboBox.FormattingEnabled = true;
            this.comPortComboBox.Location = new System.Drawing.Point(73, 12);
            this.comPortComboBox.Name = "comPortComboBox";
            this.comPortComboBox.Size = new System.Drawing.Size(89, 21);
            this.comPortComboBox.TabIndex = 19;
            this.comPortComboBox.Click += new System.EventHandler(this.comPortComboBox_Click);
            // 
            // inUnlockButton
            // 
            this.inUnlockButton.Location = new System.Drawing.Point(171, 74);
            this.inUnlockButton.Name = "inUnlockButton";
            this.inUnlockButton.Size = new System.Drawing.Size(89, 23);
            this.inUnlockButton.TabIndex = 20;
            this.inUnlockButton.Text = "Unlock";
            this.inUnlockButton.UseVisualStyleBackColor = true;
            this.inUnlockButton.Click += new System.EventHandler(this.inUnlockButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inAmperTextBox);
            this.groupBox1.Controls.Add(this.inUnlockButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.inLockButton);
            this.groupBox1.Controls.Add(this.inVoltTextBox);
            this.groupBox1.Controls.Add(this.readInButton);
            this.groupBox1.Controls.Add(this.inSetButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 108);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.outOnButton);
            this.groupBox2.Controls.Add(this.outOffButton);
            this.groupBox2.Controls.Add(this.readOutButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 50);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clearLogButton);
            this.groupBox3.Controls.Add(this.logListBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 189);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(113, 159);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(89, 23);
            this.clearLogButton.TabIndex = 19;
            this.clearLogButton.Text = "Clear";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 413);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comPortComboBox);
            this.Controls.Add(this.baudrateTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSP5015 Controller";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox baudrateTextBox;
        private System.Windows.Forms.Button readInButton;
        private System.Windows.Forms.Button readOutButton;
        private System.Windows.Forms.Button outOnButton;
        private System.Windows.Forms.Button outOffButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox inVoltTextBox;
        private System.Windows.Forms.TextBox inAmperTextBox;
        private System.Windows.Forms.Button inSetButton;
        private System.Windows.Forms.Button inLockButton;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.ComboBox comPortComboBox;
        private System.Windows.Forms.Button inUnlockButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clearLogButton;
    }
}

