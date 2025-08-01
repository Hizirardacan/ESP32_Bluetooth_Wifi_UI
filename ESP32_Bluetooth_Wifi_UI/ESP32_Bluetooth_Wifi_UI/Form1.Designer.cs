namespace ESP32_Bluetooth_Wifi_UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            radioWifi = new RadioButton();
            radioBluetooth = new RadioButton();
            label1 = new Label();
            txtIp1 = new TextBox();
            txtIp2 = new TextBox();
            txtIp3 = new TextBox();
            txtIp4 = new TextBox();
            ipv4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label9 = new Label();
            WIFIPORT = new Label();
            textBox1 = new TextBox();
            panelWifi = new Panel();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            Send = new Button();
            ConnectButton = new Button();
            label10 = new Label();
            label11 = new Label();
            COM = new ComboBox();
            btnDisconnect = new Button();
            lblStatus = new Label();
            label4 = new Label();
            panelBT = new Panel();
            panelWifi.SuspendLayout();
            panelBT.SuspendLayout();
            SuspendLayout();
            // 
            // radioWifi
            // 
            radioWifi.AutoSize = true;
            radioWifi.Location = new Point(30, 78);
            radioWifi.Name = "radioWifi";
            radioWifi.Size = new Size(46, 19);
            radioWifi.TabIndex = 0;
            radioWifi.TabStop = true;
            radioWifi.Text = "Wifi";
            radioWifi.UseVisualStyleBackColor = true;
            radioWifi.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioBluetooth
            // 
            radioBluetooth.AutoSize = true;
            radioBluetooth.Location = new Point(30, 118);
            radioBluetooth.Name = "radioBluetooth";
            radioBluetooth.Size = new Size(77, 19);
            radioBluetooth.TabIndex = 1;
            radioBluetooth.TabStop = true;
            radioBluetooth.Text = "Bluetooth";
            radioBluetooth.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 40);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 2;
            label1.Text = "Connection Type";
            // 
            // txtIp1
            // 
            txtIp1.Location = new Point(59, 6);
            txtIp1.Name = "txtIp1";
            txtIp1.Size = new Size(26, 23);
            txtIp1.TabIndex = 3;
            // 
            // txtIp2
            // 
            txtIp2.Location = new Point(107, 6);
            txtIp2.Name = "txtIp2";
            txtIp2.Size = new Size(26, 23);
            txtIp2.TabIndex = 4;
            // 
            // txtIp3
            // 
            txtIp3.Location = new Point(155, 6);
            txtIp3.Name = "txtIp3";
            txtIp3.Size = new Size(26, 23);
            txtIp3.TabIndex = 5;
            // 
            // txtIp4
            // 
            txtIp4.Location = new Point(198, 6);
            txtIp4.Name = "txtIp4";
            txtIp4.Size = new Size(26, 23);
            txtIp4.TabIndex = 6;
            txtIp4.TextChanged += textBox4_TextChanged;
            // 
            // ipv4
            // 
            ipv4.AutoSize = true;
            ipv4.FlatStyle = FlatStyle.System;
            ipv4.Location = new Point(12, 6);
            ipv4.Name = "ipv4";
            ipv4.Size = new Size(33, 15);
            ipv4.TabIndex = 13;
            ipv4.Text = "IPV4:";
            ipv4.Click += label2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 14);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 15;
            label2.Text = ".";
            label2.Click += label2_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 14);
            label3.Name = "label3";
            label3.Size = new Size(10, 15);
            label3.TabIndex = 16;
            label3.Text = ".";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(187, 14);
            label9.Name = "label9";
            label9.Size = new Size(10, 15);
            label9.TabIndex = 22;
            label9.Text = ".";
            label9.Click += label9_Click;
            // 
            // WIFIPORT
            // 
            WIFIPORT.AutoSize = true;
            WIFIPORT.Location = new Point(253, 11);
            WIFIPORT.Name = "WIFIPORT";
            WIFIPORT.Size = new Size(38, 15);
            WIFIPORT.TabIndex = 23;
            WIFIPORT.Text = "PORT:";
            WIFIPORT.Click += WIFIPORT_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(302, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 25;
            // 
            // panelWifi
            // 
            panelWifi.Controls.Add(textBox1);
            panelWifi.Controls.Add(txtIp1);
            panelWifi.Controls.Add(txtIp2);
            panelWifi.Controls.Add(WIFIPORT);
            panelWifi.Controls.Add(txtIp3);
            panelWifi.Controls.Add(label9);
            panelWifi.Controls.Add(txtIp4);
            panelWifi.Controls.Add(label3);
            panelWifi.Controls.Add(ipv4);
            panelWifi.Controls.Add(label2);
            panelWifi.Location = new Point(255, 74);
            panelWifi.Name = "panelWifi";
            panelWifi.Size = new Size(407, 38);
            panelWifi.TabIndex = 27;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(255, 217);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(433, 66);
            textBox2.TabIndex = 28;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(255, 314);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(433, 66);
            textBox3.TabIndex = 29;
            // 
            // Send
            // 
            Send.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Send.Location = new Point(704, 217);
            Send.Name = "Send";
            Send.Size = new Size(77, 50);
            Send.TabIndex = 30;
            Send.Text = "Send";
            Send.UseVisualStyleBackColor = true;
            Send.Click += Send_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(675, 75);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(113, 35);
            ConnectButton.TabIndex = 31;
            ConnectButton.Text = "ConnectButton";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(255, 199);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 32;
            label10.Text = "Send Text:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(255, 296);
            label11.Name = "label11";
            label11.Size = new Size(74, 15);
            label11.TabIndex = 33;
            label11.Text = "Receive Text:";
            label11.Click += label11_Click;
            // 
            // COM
            // 
            COM.FormattingEnabled = true;
            COM.Location = new Point(87, 14);
            COM.Name = "COM";
            COM.Size = new Size(121, 23);
            COM.TabIndex = 34;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(675, 118);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(113, 35);
            btnDisconnect.TabIndex = 35;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(704, 40);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 36;
            lblStatus.Text = "Status";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 17);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 37;
            label4.Text = "COM: ";
            // 
            // panelBT
            // 
            panelBT.Controls.Add(label4);
            panelBT.Controls.Add(COM);
            panelBT.Location = new Point(255, 128);
            panelBT.Name = "panelBT";
            panelBT.Size = new Size(407, 46);
            panelBT.TabIndex = 38;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 444);
            Controls.Add(panelBT);
            Controls.Add(lblStatus);
            Controls.Add(btnDisconnect);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(ConnectButton);
            Controls.Add(Send);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(panelWifi);
            Controls.Add(label1);
            Controls.Add(radioBluetooth);
            Controls.Add(radioWifi);
            Name = "Form1";
            Text = "Connection";
            Load += Form1_Load;
            panelWifi.ResumeLayout(false);
            panelWifi.PerformLayout();
            panelBT.ResumeLayout(false);
            panelBT.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioWifi;
        private RadioButton radioBluetooth;
        private Label label1;
        private TextBox txtIp1;
        private TextBox txtIp2;
        private TextBox txtIp3;
        private TextBox txtIp4;
        private Label ipv4;
        private Label label2;
        private Label label3;
        private Label label9;
        private Label WIFIPORT;
        private TextBox textBox1;
        private Panel panelWifi;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button Send;
        private Button ConnectButton;
        private Label label10;
        private Label label11;
        private ComboBox COM;
        private Button btnDisconnect;
        private Label lblStatus;
        private Label label4;
        private Panel panelBT;
    }
}
