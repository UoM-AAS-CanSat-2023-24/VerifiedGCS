using ScottPlot;
using ScottPlot.Plottables;
using System.Diagnostics;
using System.IO.Ports;
using System.Net.Mail;
using System.Net.Sockets;
using System.Timers;
using System.Windows.Forms;

namespace GroundStation2024
{
    public partial class Form1 : Form
    {
        string[] dataArray = new string[3];
        string stringData = string.Empty;

        //RFSerialPort Port = new RFSerialPort("COM6", 115200);
        public RFSerialPort Port;
        TelemetryData receivedData = new TelemetryData();

        string lastCMDsent = string.Empty;
        int unregistedCMDEchoes = 0;

        public float[] simPressureArray;
        public int simpIteration = 0;
        System.Timers.Timer simpTimer = new System.Timers.Timer();
        bool initialised = false;

        public static Form1 Instance;

        public delegate void UpdateTextBox(string bufferString);
        public delegate void SetTextCallback(string text);
        public Form1()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Port.PacketReceived += AddTelemetryData;

            commandBtn.Enabled = false;
            beginSimpBtn.Enabled = false;
            stopSimpBtn.Enabled = false;

            InitializePlots();

            telemetryTextBox.ReadOnly = true;
            telemetryTextBox.BackColor = System.Drawing.Color.White;

            commandLogTextBox.ReadOnly = true;
            commandLogTextBox.BackColor = System.Drawing.Color.White;

            rxSimpTelemetryTextBox.ReadOnly = true;
            rxSimpTelemetryTextBox.BackColor = System.Drawing.Color.White;

            simpFileComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            allGraphsTabPage.BackColor = System.Drawing.Color.Transparent;

            //Thread readDataThread = new Thread(new ThreadStart(Port.ReadAsynchronously));
            //readDataThread.Start();
        }

        public void UpdateTelemetry(string bufferString)
        {
            stringData = bufferString;

            //Try catch block to see if packet can be parsed and displayed
            
            try
            {
                receivedData.SetNewData(bufferString);

                if (receivedData.simPacket == true)
                {
                    rxSimpTelemetryTextBox.AppendText(bufferString + "\r\n");
                    telemetryTextBox.AppendText(bufferString + "\r\n");
                    rxSIMPlabel.Text = "Packets received: " + receivedData.simulatedPressureTelemetry.Length;
                    rxSIMPlabel.Refresh();
                    UpdateSimpPlot();
                }

                else
                {
                    telemetryTextBox.AppendText(receivedData.fullString + "\r\n");
                    UpdateGraphs();
                    UpdateDataGrid();
                    UpdateLabels();

                    checkCMDEcho();

                    Thread writeCSV = new Thread(WriteCSV.WriteTelemetry);
                    writeCSV.Start(receivedData.packetString);

                }
            }

            catch (Exception parseException)
            {
                telemetryTextBox.AppendText("FAILED PACKET! (PARSE ERROR)" + "\r\n");
            }

        }

        private void UpdateLabels()
        {
            modeLabel.Text = "Mode: " + "\r\n" + receivedData.packetString.mode;
            stateLabel.Text = "State: " + "\r\n" + receivedData.packetString.state;
            airSpeedLabel.Text = "Air Speed: " + "\r\n" + receivedData.packetString.airSpeed;
            hsLabel.Text = "Heat Shield: " + "\r\n" + receivedData.packetString.HS_Deployed;
            pcLabel.Text = "Parachute: " + "\r\n" + receivedData.packetString.PC_Deployed;
            temperatureLabel.Text = "Temperature: " + "\r\n" + receivedData.packetString.temperature;
            batteryLabel.Text = "Voltage: " + "\r\n" + receivedData.packetString.voltage;

            modeLabel.Refresh();
            stateLabel.Refresh();
            airSpeedLabel.Refresh();
            hsLabel.Refresh();
            pcLabel.Refresh();
            temperatureLabel.Refresh();
            batteryLabel.Refresh();
        }

        private void UpdateDataGrid()
        {
            this.tableDataGrid.Rows.Add(receivedData.packetString.teamID, receivedData.packetString.missionTime, receivedData.packetString.packetCount, receivedData.packetString.mode, receivedData.packetString.state,
                    receivedData.packetString.altitude, receivedData.packetString.airSpeed, receivedData.packetString.HS_Deployed, receivedData.packetString.HS_Deployed, receivedData.packetString.temperature,
                    receivedData.packetString.voltage, receivedData.packetString.pressure, receivedData.packetString.GPS_Time, receivedData.packetString.GPS_Altitude, receivedData.packetString.GPS_Latitude,
                    receivedData.packetString.GPS_Longitude, receivedData.packetString.GPS_Sats, receivedData.packetString.TiltX, receivedData.packetString.TiltY, receivedData.packetString.RotZ, receivedData.packetString.CMD_Echo);

        }
        private void commandBtn_Click(object sender, EventArgs e)
        {
            CommandForm cmd = new CommandForm(Port);
            cmd.Show();
        }
        public void AddTelemetryData(string bufferString)
        {
            object delegateParameter = bufferString;
            BeginInvoke(new UpdateTextBox(UpdateTelemetry), delegateParameter);
        }
        private void beginSimpBtn_Click(object sender, EventArgs e)
        {
            if (initialised == false) 
            {
                try
                {
                    InitializeSimpTimer();
                    stopSimpBtn.Enabled = true;
                    beginSimpBtn.Enabled = false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error!");
                }
            }
            else
            {
                simpTimer.Start();
                stopSimpBtn.Enabled = true;
                beginSimpBtn.Enabled = false;
            }
        }
        private void stopSimpBtn_Click(object sender, EventArgs e)
        {
            simpTimer.Stop();
            stopSimpBtn.Enabled = false;
            beginSimpBtn.Enabled = true;
        }

        private void InitializeSimpTimer()
        {
            simpTimer.Interval = 1000;
            simpTimer.Elapsed += SendSimpCommand;
            simpTimer.AutoReset = true;
            simpTimer.Start();
            initialised = true;
        }

        private void StopSimpTimer()
        {
            simpTimer.Stop();
        }

        private void SendSimpCommand(Object source, ElapsedEventArgs e)
        {
            if(simpIteration >= simPressureArray.Length)
            {
                StopSimpTimer();
                simpIteration = 0;
                MessageBox.Show("All simulated pressure values have been transmitted!");
            }
            else 
            {
                Port.Write("CMD,2045,SIMP," + simPressureArray[simpIteration]);
                string txText = "CMD,2045,SIMP," + simPressureArray[simpIteration];
                SetSimpCMDText(txText);
                txLabel(".");
                simpIteration++;
            }
            
        }

        private void txLabel(string dummy)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txSIMPlabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(txLabel);
                this.Invoke(d, new object[] { dummy });
            }
            else
            {
                this.txSIMPlabel.Text = "Packets transmitted: " + (simpIteration + 1);
                txSIMPlabel.Refresh();
            }
        }

        private void SetSimpCMDText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txSimpTelemetryTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSimpCMDText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txSimpTelemetryTextBox.AppendText(text + "\r\n");
            }
        }

        private void readCSVFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                simPressureArray = ReadCSV.ReadCsvFile(simpFileComboBox.SelectedItem.ToString());
                beginSimpBtn.Enabled = true;
            }

            catch (Exception exp)
            {
                MessageBox.Show("File could not be read!");
            }

        }


        private void findFilesBtn_Click(object sender, EventArgs e)
        {
            var files = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.csv*", System.IO.SearchOption.AllDirectories);

            string[] shortFileName = new string[0];

            foreach (var file in files)
            {
                string[] split = file.Split('\\');
                shortFileName = shortFileName.Append(split[split.Length - 1]).ToArray();
            }

            simpFileComboBox.DataSource = shortFileName;
        }

        public void UpdateGraphs()
        {
            //Update Altitude Plot
            altitudePlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.altitudeTelemetry).Color = Colors.Red;
            altitudePlot.Plot.Axes.AutoScale();
            altitudePlot.Refresh();

            //Update Pressure Plot
            pressurePlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.pressureTelemetry).Color = Colors.Blue;
            pressurePlot.Plot.Axes.AutoScale();
            pressurePlot.Refresh();

            //Update Packet Count Plot
            packetCountPlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.packetCountTelemetry).Color = Colors.Green;
            packetCountPlot.Plot.Axes.AutoScale();
            packetCountPlot.Refresh();

            //Update Rotation Plot
            rotationRatePlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.rotZTelemetry).Color = Colors.Orange;
            rotationRatePlot.Plot.Axes.AutoScale();
            rotationRatePlot.Refresh();

            //Update Latitude Plot
            latitudePlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.GPS_LatitudeTelemetry).Color = Colors.Purple;
            latitudePlot.Plot.Axes.AutoScale();
            latitudePlot.Refresh();

            //Update Longitude Plot
            longitudePlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.GPS_LongitudeTelemetry).Color = Colors.DarkBlue;
            longitudePlot.Plot.Axes.AutoScale();
            longitudePlot.Refresh();

            //Update TiltX Plot
            tiltXPlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.tiltXTelemetry).Color = Colors.Yellow;
            tiltXPlot.Plot.Axes.AutoScale();
            tiltXPlot.Refresh();

            //Update TiltY Plot
            tiltYPlot.Plot.Add.Scatter(receivedData.missionTimeDateTime, receivedData.tiltYTelemetry).Color = Colors.GreenYellow;
            tiltYPlot.Plot.Axes.AutoScale();
            tiltYPlot.Refresh();

        }

        public void UpdateSimpPlot()
        {
            simPressurePlot.Plot.Add.Scatter(receivedData.simpDateTime, receivedData.simulatedPressureTelemetry).Color = Colors.IndianRed;
            simPressurePlot.Plot.Axes.AutoScale();
            simPressurePlot.Refresh();
        }

        private void InitializePlots()
        {
            //Pressure Plot Initialization
            pressurePlot.Plot.XLabel("Date and Time");
            //pressurePlot.Plot.YLabel("Pressure [kPa]");
            pressurePlot.Plot.Title("Pressure [kPa]");
            pressurePlot.Plot.Axes.DateTimeTicksBottom();

            //Altitude Plot Initialization
            altitudePlot.Plot.XLabel("Date and Time");
            //altitudePlot.Plot.YLabel("Altitude [m]");
            altitudePlot.Plot.Title("Altitude [m]");
            altitudePlot.Plot.Axes.DateTimeTicksBottom();

            //Packet Count Plot Initialization
            packetCountPlot.Plot.XLabel("Date and Time");
            //packetCountPlot.Plot.YLabel("Packet count");
            packetCountPlot.Plot.Title("Packet count");
            packetCountPlot.Plot.Axes.DateTimeTicksBottom();

            //Rotation Rate Plot Initialization
            rotationRatePlot.Plot.XLabel("Date and Time");
            rotationRatePlot.Plot.Title("Rotation rate [deg/s]");
            rotationRatePlot.Plot.Axes.DateTimeTicksBottom();

            //Tilt X Plot Initialization
            tiltXPlot.Plot.XLabel("Date and Time");
            tiltXPlot.Plot.Title("Tilt X [deg]");
            tiltXPlot.Plot.Axes.DateTimeTicksBottom();

            //Tilt Y Plot Initialization
            tiltYPlot.Plot.XLabel("Date and Time");
            tiltYPlot.Plot.Title("Tilt Y [deg]");
            tiltYPlot.Plot.Axes.DateTimeTicksBottom();

            //Latitude Plot Initialization
            latitudePlot.Plot.XLabel("Date and Time");
            latitudePlot.Plot.Title("Latitude [deg]");
            latitudePlot.Plot.Axes.DateTimeTicksBottom();

            //Longitude Plot Initialization
            longitudePlot.Plot.XLabel("Date and Time");
            longitudePlot.Plot.Title("Longitude [deg]");
            longitudePlot.Plot.Axes.DateTimeTicksBottom();

            //Simulated Pressure Plot Initialization
            simPressurePlot.Plot.XLabel("Date and Time");
            simPressurePlot.Plot.Title("Simulated pressure [kPa]");
            simPressurePlot.Plot.Axes.DateTimeTicksBottom();
        }

        public void SetCMDTextBox(string command)
        {
            commandLogTextBox.AppendText(command + "\r\n");
            string[] commandStringArray = command.Split(',');
            /*CMD,2045,CX,ON
              CMD,2045,CX,OFF
              CMD,2045,ST,<UTC_TIME>
              CMD,2045,ST,GPS
              CMD,2045,SIM,ACTIVATE
              CMD,2045,SIM,ENABLE
              CMD,2045,SIM,DISABLE
              CMD,2045,CAL
              CMD,2045,BCN,ON
              CMD,2045,BCN,OFF*/
            if (commandStringArray[2]=="ST" && commandStringArray[3] != "GPS")
            {
                lastCMDsent = "STUTC";
            }

            else if (commandStringArray[2] == "CAL")
            {
                lastCMDsent = "CAL";
            }
            else
            {
                lastCMDsent = commandStringArray[2] + commandStringArray[3];
            }
                
        }

        private void checkCMDEcho()
        {
            if (receivedData.newCMD_Echo != lastCMDsent)
            {
                unregistedCMDEchoes++;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioSetupBtn_Click(object sender, EventArgs e)
        {
            RadioSetup rf = new RadioSetup();
            rf.Show();
        }
    }
}
