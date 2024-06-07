using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroundStation2024
{
    public partial class RadioSetup : Form
    {
        public RadioSetup()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            portSelectionComboBox.DataSource = ports;
        }

        private void RadioSetup_Load(object sender, EventArgs e)
        {
    
        }

        private void configureBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.Instance.Port = new RFSerialPort(portSelectionComboBox.Text, Int32.Parse(baudRateSelectionComboBox.Text));
                Form1.Instance.Port.PacketReceived += Form1.Instance.AddTelemetryData;

                Form1.Instance.commandBtn.Enabled = true;

                Thread readDataThread = new Thread(new ThreadStart(Form1.Instance.Port.ReadAsynchronously));
                readDataThread.Start();

                configureBtn.Enabled = false;
            }

            catch
            {
                MessageBox.Show("Error!");
            }
            
        }
    }
}
