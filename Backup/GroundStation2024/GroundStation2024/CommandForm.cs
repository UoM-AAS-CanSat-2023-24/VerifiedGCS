using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroundStation2024
{

    public partial class CommandForm : Form
    {
        public RFSerialPort Port;
        public CommandForm(RFSerialPort sp)
        {
            Port = sp;
            InitializeComponent();
        }

        private void CommandForm_Load(object sender, EventArgs e)
        {
            commandMenu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            string commandString = commandMenu.Text;
            if(commandMenu.Text== "CMD,2045,ST,<UTC_TIME>")
            {
                DateTime dateToday = DateTime.Now;
                string hour, minute, second;
                if(dateToday.Hour < 10)
                {
                    hour = "0" + dateToday.Hour;
                }
                else
                {
                    hour = dateToday.Hour.ToString();
                }

                if (dateToday.Minute < 10)
                {
                    minute = "0" + dateToday.Minute;
                }
                else
                {
                    minute = dateToday.Minute.ToString();
                }

                if (dateToday.Second < 10)
                {
                    second = "0" + dateToday.Second;
                }
                else
                {
                    second = dateToday.Second.ToString();
                }

                commandString = "CMD,2045,ST," + hour + ":" + minute + ":" + second;
            }
            Port.Write(commandString);
            Form1.Instance.SetCMDTextBox(commandString);
        }

        private void commandMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
