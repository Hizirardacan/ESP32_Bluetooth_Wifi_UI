using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESP32_Bluetooth_Wifi_UI
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private TcpClient tcpClient;
        private NetworkStream tcpStream;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            panelWifi.Visible = true;

            radioWifi.CheckedChanged += radioWifi_CheckedChanged;
            radioBluetooth.CheckedChanged += radioBluetooth_CheckedChanged;

            COM.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            COM.Items.AddRange(ports);
            if (COM.Items.Count > 0)
                COM.SelectedIndex = 0;

            txtIp1.TextChanged += ValidateIpInput;
            txtIp2.TextChanged += ValidateIpInput;
            txtIp3.TextChanged += ValidateIpInput;
            txtIp4.TextChanged += ValidateIpInput;

            txtIp1.KeyPress += IpBox_KeyPress;
            txtIp2.KeyPress += IpBox_KeyPress;
            txtIp3.KeyPress += IpBox_KeyPress;
            txtIp4.KeyPress += IpBox_KeyPress;

        }

        private void radioWifi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWifi.Checked)
            {
                panelWifi.Visible = true;
                panelBT.Visible = false;
            }
        }

        private void radioBluetooth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBluetooth.Checked)
            {
                panelWifi.Visible = false;
                panelBT.Visible = true;
            }
        }

        private bool IsByteValue(string text) => int.TryParse(text, out int value) && value >= 0 && value <= 255;

        private bool IsHexByte(string text) => Regex.IsMatch(text, @"\A[0-9A-Fa-f]{1,2}\z");

        private bool IsValidIPv4(string ip) => Regex.IsMatch(ip, @"^(\d{1,3}\.){3}\d{1,3}$") &&
            ip.Split('.').All(octet => int.TryParse(octet, out int part) && part >= 0 && part <= 255);
        private void ValidateIpInput(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            if (tb.Text.Length > 3) tb.Text = tb.Text.Substring(0, 3);
            tb.BackColor = (!IsByteValue(tb.Text) && tb.Text.Length > 0) ? Color.LightCoral : Color.White;
            tb.SelectionStart = tb.Text.Length;
        }

        private void ValidateMacInput(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;
            if (tb.Text.Length > 2) tb.Text = tb.Text.Substring(0, 2);
            tb.BackColor = (!IsHexByte(tb.Text) && tb.Text.Length > 0) ? Color.LightCoral : Color.White;
            tb.SelectionStart = tb.Text.Length;
        }

        private void IpBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void MacBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Uri.IsHexDigit(e.KeyChar)) e.Handled = true;
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            string selectedPort = COM.SelectedItem?.ToString();

            if (radioBluetooth.Checked && string.IsNullOrEmpty(selectedPort))
            {
                MessageBox.Show("Bluetooth baðlantýsý için bir COM port seçin.");
                return;
            }

            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.DataReceived -= SerialPort_DataReceived;
                    serialPort.Close();
                    serialPort.Dispose();
                }

                if (radioBluetooth.Checked)
                {
                    serialPort = new SerialPort(selectedPort, 115200, Parity.None, 8, StopBits.One);
                    serialPort.DataReceived += SerialPort_DataReceived;
                    serialPort.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("COM port açýlamadý: " + ex.Message);
                return;
            }

            if (radioWifi.Checked)
            {
                string ip = $"{txtIp1.Text}.{txtIp2.Text}.{txtIp3.Text}.{txtIp4.Text}";
                string port = textBox1.Text;

                if (!IsValidIPv4(ip))
                {
                    MessageBox.Show("Geçerli bir IP adresi girin.");
                    return;
                }

                if (!int.TryParse(port, out int portNum) || portNum < 1 || portNum > 65535)
                {
                    MessageBox.Show("Geçerli bir port numarasý girin.");
                    return;
                }

                try
                {
                    tcpClient = new TcpClient();
                    await tcpClient.ConnectAsync(ip, portNum);
                    tcpStream = tcpClient.GetStream();
                    ReadTcpDataAsync();

                    lblStatus.Text = "Wi-Fi Connected";
                    lblStatus.ForeColor = Color.Green;

                    MessageBox.Show("Wi-Fi TCP baðlantýsý kuruldu.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("TCP baðlantýsý kurulamadý: " + ex.Message);
                    return;
                }

                string wifiCommand = $"CONNECT_WIFI,{ip},{port}\r\n";
                if (serialPort != null && serialPort.IsOpen)
                    serialPort.Write(wifiCommand);
            }
            else if (radioBluetooth.Checked)
            {


                lblStatus.Text = "Bluetooth Command Sent";
                lblStatus.ForeColor = Color.Orange;

                MessageBox.Show("Bluetooth baðlantý komutu ESP32'ye gönderildi.");
            }
            else
            {
                MessageBox.Show("Lütfen bir baðlantý türü seçin.");
                return;
            }
        }



        private async void ReadTcpDataAsync()
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (tcpClient != null && tcpClient.Connected)
                {
                    int bytesRead = await tcpStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string received = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        System.Diagnostics.Debug.WriteLine("Wi-Fi received: " + received); // Loglama
                        Invoke(new Action(() => textBox3.AppendText(received + Environment.NewLine)));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TCP read error: " + ex.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string received = serialPort.ReadExisting();
                BeginInvoke(new Action(() => textBox3.AppendText(received + Environment.NewLine)));
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() => MessageBox.Show("BT read error: " + ex.Message)));
            }
        }



        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                // TCP baðlantýsýný kapat (Wi-Fi)
                if (tcpClient != null)
                {
                    if (tcpClient.Connected)
                    {
                        tcpStream?.Close();
                        tcpClient?.Close();

                        lblStatus.Text = "Not Connected";
                        lblStatus.ForeColor = Color.Red;

                        MessageBox.Show("Wi-Fi baðlantýsý kesildi.");
                    }

                    tcpStream = null;
                    tcpClient = null;
                }

                // Serial port baðlantýsýný kapat (Bluetooth)
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.DataReceived -= SerialPort_DataReceived;
                    serialPort.Close();
                    serialPort.Dispose();
                    serialPort = null;

                    lblStatus.Text = "Not Connected";
                    lblStatus.ForeColor = Color.Red;

                    MessageBox.Show("Bluetooth baðlantýsý kesildi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Baðlantý kesilirken hata oluþtu: " + ex.Message);
            }
        }

        // Boþ event’ler
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void WIFIPORT_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }

        private void Send_Click(object sender, EventArgs e)
        {
            string message = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Lütfen gönderilecek bir mesaj girin.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (radioWifi.Checked)
                {
                    if (tcpClient != null && tcpClient.Connected && tcpStream != null && tcpStream.CanWrite)
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(message + "\n");
                        tcpStream.Write(buffer, 0, buffer.Length);
                        tcpStream.Flush();
                        MessageBox.Show("Mesaj Wi-Fi üzerinden gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Wi-Fi baðlantýsý yok veya baðlantý kapalý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (radioBluetooth.Checked)
                {
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        serialPort.Write(message + "\r\n"); // \r\n genellikle daha uyumludur
                        MessageBox.Show("Mesaj Bluetooth üzerinden gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bluetooth baðlantýsý açýk deðil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir baðlantý yöntemi seçin (Wi-Fi veya Bluetooth).", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj gönderilirken hata oluþtu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}