namespace GroundStation2024
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl = new TabControl();
            allGraphsTabPage = new TabPage();
            tiltYPlot = new ScottPlot.WinForms.FormsPlot();
            tiltXPlot = new ScottPlot.WinForms.FormsPlot();
            rotationRatePlot = new ScottPlot.WinForms.FormsPlot();
            longitudePlot = new ScottPlot.WinForms.FormsPlot();
            latitudePlot = new ScottPlot.WinForms.FormsPlot();
            packetCountPlot = new ScottPlot.WinForms.FormsPlot();
            altitudePlot = new ScottPlot.WinForms.FormsPlot();
            pressurePlot = new ScottPlot.WinForms.FormsPlot();
            tabPage3 = new TabPage();
            tableDataGrid = new DataGridView();
            teamID = new DataGridViewTextBoxColumn();
            missionTime = new DataGridViewTextBoxColumn();
            packetCount = new DataGridViewTextBoxColumn();
            mode = new DataGridViewTextBoxColumn();
            state = new DataGridViewTextBoxColumn();
            altitude = new DataGridViewTextBoxColumn();
            airSpeed = new DataGridViewTextBoxColumn();
            hs_Deployed = new DataGridViewTextBoxColumn();
            pc_deployed = new DataGridViewTextBoxColumn();
            temperature = new DataGridViewTextBoxColumn();
            voltage = new DataGridViewTextBoxColumn();
            pressure = new DataGridViewTextBoxColumn();
            GPS_Time = new DataGridViewTextBoxColumn();
            GPS_Altitude = new DataGridViewTextBoxColumn();
            GPS_Longitude = new DataGridViewTextBoxColumn();
            GPS_Latitude = new DataGridViewTextBoxColumn();
            GPS_Sats = new DataGridViewTextBoxColumn();
            tiltX = new DataGridViewTextBoxColumn();
            tiltY = new DataGridViewTextBoxColumn();
            rotZ = new DataGridViewTextBoxColumn();
            CMD_Echo = new DataGridViewTextBoxColumn();
            tabPage4 = new TabPage();
            telemetryTextBox = new TextBox();
            tabPage1 = new TabPage();
            commandLogTextBox = new TextBox();
            simulationTabPage = new TabPage();
            findFilesBtn = new Button();
            simpFileComboBox = new ComboBox();
            stopSimpBtn = new Button();
            beginSimpBtn = new Button();
            readCSVFileBtn = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            rxDisplayLabel = new Label();
            txDisplayLabel = new Label();
            txSimpTelemetryTextBox = new TextBox();
            rxSIMPlabel = new Label();
            txSIMPlabel = new Label();
            rxSimpTelemetryTextBox = new TextBox();
            simPressurePlot = new ScottPlot.WinForms.FormsPlot();
            commandBtn = new Button();
            modeLabel = new Label();
            stateLabel = new Label();
            airSpeedLabel = new Label();
            pcLabel = new Label();
            hsLabel = new Label();
            temperatureLabel = new Label();
            batteryLabel = new Label();
            radioSetupBtn = new Button();
            tabControl.SuspendLayout();
            allGraphsTabPage.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableDataGrid).BeginInit();
            tabPage4.SuspendLayout();
            tabPage1.SuspendLayout();
            simulationTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(allGraphsTabPage);
            tabControl.Controls.Add(tabPage3);
            tabControl.Controls.Add(tabPage4);
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(simulationTabPage);
            tabControl.Location = new Point(4, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1406, 693);
            tabControl.TabIndex = 0;
            // 
            // allGraphsTabPage
            // 
            allGraphsTabPage.Controls.Add(tiltYPlot);
            allGraphsTabPage.Controls.Add(tiltXPlot);
            allGraphsTabPage.Controls.Add(rotationRatePlot);
            allGraphsTabPage.Controls.Add(longitudePlot);
            allGraphsTabPage.Controls.Add(latitudePlot);
            allGraphsTabPage.Controls.Add(packetCountPlot);
            allGraphsTabPage.Controls.Add(altitudePlot);
            allGraphsTabPage.Controls.Add(pressurePlot);
            allGraphsTabPage.Location = new Point(4, 29);
            allGraphsTabPage.Name = "allGraphsTabPage";
            allGraphsTabPage.Padding = new Padding(3);
            allGraphsTabPage.Size = new Size(1398, 660);
            allGraphsTabPage.TabIndex = 0;
            allGraphsTabPage.Text = "All Graphs";
            allGraphsTabPage.UseVisualStyleBackColor = true;
            // 
            // tiltYPlot
            // 
            tiltYPlot.DisplayScale = 1.25F;
            tiltYPlot.Location = new Point(1047, 292);
            tiltYPlot.Name = "tiltYPlot";
            tiltYPlot.Size = new Size(355, 280);
            tiltYPlot.TabIndex = 7;
            // 
            // tiltXPlot
            // 
            tiltXPlot.DisplayScale = 1.25F;
            tiltXPlot.Location = new Point(701, 292);
            tiltXPlot.Name = "tiltXPlot";
            tiltXPlot.Size = new Size(355, 280);
            tiltXPlot.TabIndex = 6;
            // 
            // rotationRatePlot
            // 
            rotationRatePlot.DisplayScale = 1.25F;
            rotationRatePlot.Location = new Point(351, 292);
            rotationRatePlot.Name = "rotationRatePlot";
            rotationRatePlot.Size = new Size(355, 280);
            rotationRatePlot.TabIndex = 5;
            // 
            // longitudePlot
            // 
            longitudePlot.DisplayScale = 1.25F;
            longitudePlot.Location = new Point(1047, 0);
            longitudePlot.Name = "longitudePlot";
            longitudePlot.Size = new Size(355, 280);
            longitudePlot.TabIndex = 4;
            // 
            // latitudePlot
            // 
            latitudePlot.DisplayScale = 1.25F;
            latitudePlot.Location = new Point(701, 0);
            latitudePlot.Name = "latitudePlot";
            latitudePlot.Size = new Size(355, 280);
            latitudePlot.TabIndex = 3;
            // 
            // packetCountPlot
            // 
            packetCountPlot.DisplayScale = 1.25F;
            packetCountPlot.Location = new Point(-4, 0);
            packetCountPlot.Name = "packetCountPlot";
            packetCountPlot.Size = new Size(355, 280);
            packetCountPlot.TabIndex = 2;
            // 
            // altitudePlot
            // 
            altitudePlot.DisplayScale = 1.25F;
            altitudePlot.Location = new Point(351, 0);
            altitudePlot.Name = "altitudePlot";
            altitudePlot.Size = new Size(355, 280);
            altitudePlot.TabIndex = 1;
            // 
            // pressurePlot
            // 
            pressurePlot.DisplayScale = 1.25F;
            pressurePlot.Location = new Point(4, 292);
            pressurePlot.Name = "pressurePlot";
            pressurePlot.Size = new Size(354, 280);
            pressurePlot.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tableDataGrid);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1398, 660);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Data Table";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableDataGrid
            // 
            tableDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableDataGrid.Columns.AddRange(new DataGridViewColumn[] { teamID, missionTime, packetCount, mode, state, altitude, airSpeed, hs_Deployed, pc_deployed, temperature, voltage, pressure, GPS_Time, GPS_Altitude, GPS_Longitude, GPS_Latitude, GPS_Sats, tiltX, tiltY, rotZ, CMD_Echo });
            tableDataGrid.Location = new Point(0, 0);
            tableDataGrid.Name = "tableDataGrid";
            tableDataGrid.RowHeadersWidth = 51;
            tableDataGrid.RowTemplate.Height = 29;
            tableDataGrid.Size = new Size(1402, 660);
            tableDataGrid.TabIndex = 0;
            tableDataGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // teamID
            // 
            teamID.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            teamID.HeaderText = "Team ID";
            teamID.MinimumWidth = 6;
            teamID.Name = "teamID";
            teamID.ReadOnly = true;
            teamID.Width = 93;
            // 
            // missionTime
            // 
            missionTime.HeaderText = "Mission Time";
            missionTime.MinimumWidth = 6;
            missionTime.Name = "missionTime";
            missionTime.ReadOnly = true;
            missionTime.Width = 125;
            // 
            // packetCount
            // 
            packetCount.HeaderText = "PacketCount";
            packetCount.MinimumWidth = 6;
            packetCount.Name = "packetCount";
            packetCount.ReadOnly = true;
            packetCount.Width = 125;
            // 
            // mode
            // 
            mode.HeaderText = "Mode";
            mode.MinimumWidth = 6;
            mode.Name = "mode";
            mode.ReadOnly = true;
            mode.Width = 125;
            // 
            // state
            // 
            state.HeaderText = "State";
            state.MinimumWidth = 6;
            state.Name = "state";
            state.ReadOnly = true;
            state.Width = 125;
            // 
            // altitude
            // 
            altitude.HeaderText = "Altitude";
            altitude.MinimumWidth = 6;
            altitude.Name = "altitude";
            altitude.ReadOnly = true;
            altitude.Width = 125;
            // 
            // airSpeed
            // 
            airSpeed.HeaderText = "AirSpeed";
            airSpeed.MinimumWidth = 6;
            airSpeed.Name = "airSpeed";
            airSpeed.ReadOnly = true;
            airSpeed.Width = 125;
            // 
            // hs_Deployed
            // 
            hs_Deployed.HeaderText = "HS_Deployed";
            hs_Deployed.MinimumWidth = 6;
            hs_Deployed.Name = "hs_Deployed";
            hs_Deployed.ReadOnly = true;
            hs_Deployed.Width = 125;
            // 
            // pc_deployed
            // 
            pc_deployed.HeaderText = "PC_Deployed";
            pc_deployed.MinimumWidth = 6;
            pc_deployed.Name = "pc_deployed";
            pc_deployed.ReadOnly = true;
            pc_deployed.Width = 125;
            // 
            // temperature
            // 
            temperature.HeaderText = "Temperature";
            temperature.MinimumWidth = 6;
            temperature.Name = "temperature";
            temperature.ReadOnly = true;
            temperature.Width = 125;
            // 
            // voltage
            // 
            voltage.HeaderText = "Voltage";
            voltage.MinimumWidth = 6;
            voltage.Name = "voltage";
            voltage.ReadOnly = true;
            voltage.Width = 125;
            // 
            // pressure
            // 
            pressure.HeaderText = "Pressure";
            pressure.MinimumWidth = 6;
            pressure.Name = "pressure";
            pressure.ReadOnly = true;
            pressure.Width = 125;
            // 
            // GPS_Time
            // 
            GPS_Time.HeaderText = "GPS Time";
            GPS_Time.MinimumWidth = 6;
            GPS_Time.Name = "GPS_Time";
            GPS_Time.ReadOnly = true;
            GPS_Time.Width = 125;
            // 
            // GPS_Altitude
            // 
            GPS_Altitude.HeaderText = "GPS Altitude";
            GPS_Altitude.MinimumWidth = 6;
            GPS_Altitude.Name = "GPS_Altitude";
            GPS_Altitude.ReadOnly = true;
            GPS_Altitude.Width = 125;
            // 
            // GPS_Longitude
            // 
            GPS_Longitude.HeaderText = "GPS Longitude";
            GPS_Longitude.MinimumWidth = 6;
            GPS_Longitude.Name = "GPS_Longitude";
            GPS_Longitude.ReadOnly = true;
            GPS_Longitude.Width = 125;
            // 
            // GPS_Latitude
            // 
            GPS_Latitude.HeaderText = "GPS Latitude";
            GPS_Latitude.MinimumWidth = 6;
            GPS_Latitude.Name = "GPS_Latitude";
            GPS_Latitude.ReadOnly = true;
            GPS_Latitude.Width = 125;
            // 
            // GPS_Sats
            // 
            GPS_Sats.HeaderText = "GPS Sats";
            GPS_Sats.MinimumWidth = 6;
            GPS_Sats.Name = "GPS_Sats";
            GPS_Sats.ReadOnly = true;
            GPS_Sats.Width = 125;
            // 
            // tiltX
            // 
            tiltX.HeaderText = "Tilt X";
            tiltX.MinimumWidth = 6;
            tiltX.Name = "tiltX";
            tiltX.ReadOnly = true;
            tiltX.Width = 125;
            // 
            // tiltY
            // 
            tiltY.HeaderText = "Tilt Y";
            tiltY.MinimumWidth = 6;
            tiltY.Name = "tiltY";
            tiltY.ReadOnly = true;
            tiltY.Width = 125;
            // 
            // rotZ
            // 
            rotZ.HeaderText = "Rot Z";
            rotZ.MinimumWidth = 6;
            rotZ.Name = "rotZ";
            rotZ.ReadOnly = true;
            rotZ.Width = 125;
            // 
            // CMD_Echo
            // 
            CMD_Echo.HeaderText = "CMD Echo";
            CMD_Echo.MinimumWidth = 6;
            CMD_Echo.Name = "CMD_Echo";
            CMD_Echo.ReadOnly = true;
            CMD_Echo.Width = 125;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(telemetryTextBox);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1398, 660);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Telemetry";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // telemetryTextBox
            // 
            telemetryTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            telemetryTextBox.Location = new Point(0, 0);
            telemetryTextBox.Multiline = true;
            telemetryTextBox.Name = "telemetryTextBox";
            telemetryTextBox.ScrollBars = ScrollBars.Vertical;
            telemetryTextBox.Size = new Size(1398, 664);
            telemetryTextBox.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(commandLogTextBox);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1398, 660);
            tabPage1.TabIndex = 4;
            tabPage1.Text = "Command Log";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // commandLogTextBox
            // 
            commandLogTextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            commandLogTextBox.Location = new Point(0, -2);
            commandLogTextBox.Multiline = true;
            commandLogTextBox.Name = "commandLogTextBox";
            commandLogTextBox.ScrollBars = ScrollBars.Vertical;
            commandLogTextBox.Size = new Size(1398, 664);
            commandLogTextBox.TabIndex = 1;
            // 
            // simulationTabPage
            // 
            simulationTabPage.Controls.Add(findFilesBtn);
            simulationTabPage.Controls.Add(simpFileComboBox);
            simulationTabPage.Controls.Add(stopSimpBtn);
            simulationTabPage.Controls.Add(beginSimpBtn);
            simulationTabPage.Controls.Add(readCSVFileBtn);
            simulationTabPage.Controls.Add(label4);
            simulationTabPage.Controls.Add(label3);
            simulationTabPage.Controls.Add(label2);
            simulationTabPage.Controls.Add(label1);
            simulationTabPage.Controls.Add(rxDisplayLabel);
            simulationTabPage.Controls.Add(txDisplayLabel);
            simulationTabPage.Controls.Add(txSimpTelemetryTextBox);
            simulationTabPage.Controls.Add(rxSIMPlabel);
            simulationTabPage.Controls.Add(txSIMPlabel);
            simulationTabPage.Controls.Add(rxSimpTelemetryTextBox);
            simulationTabPage.Controls.Add(simPressurePlot);
            simulationTabPage.Location = new Point(4, 29);
            simulationTabPage.Name = "simulationTabPage";
            simulationTabPage.Padding = new Padding(3);
            simulationTabPage.Size = new Size(1398, 660);
            simulationTabPage.TabIndex = 5;
            simulationTabPage.Text = "Simulation";
            simulationTabPage.UseVisualStyleBackColor = true;
            // 
            // findFilesBtn
            // 
            findFilesBtn.Location = new Point(816, 231);
            findFilesBtn.Name = "findFilesBtn";
            findFilesBtn.Size = new Size(94, 29);
            findFilesBtn.TabIndex = 16;
            findFilesBtn.Text = "Load Files";
            findFilesBtn.UseVisualStyleBackColor = true;
            findFilesBtn.Click += findFilesBtn_Click;
            // 
            // simpFileComboBox
            // 
            simpFileComboBox.FormattingEnabled = true;
            simpFileComboBox.Location = new Point(1085, 164);
            simpFileComboBox.Name = "simpFileComboBox";
            simpFileComboBox.Size = new Size(268, 28);
            simpFileComboBox.TabIndex = 15;
            // 
            // stopSimpBtn
            // 
            stopSimpBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            stopSimpBtn.Location = new Point(1165, 468);
            stopSimpBtn.Name = "stopSimpBtn";
            stopSimpBtn.Size = new Size(123, 64);
            stopSimpBtn.TabIndex = 14;
            stopSimpBtn.Text = "STOP";
            stopSimpBtn.UseVisualStyleBackColor = true;
            stopSimpBtn.Click += stopSimpBtn_Click;
            // 
            // beginSimpBtn
            // 
            beginSimpBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            beginSimpBtn.Location = new Point(896, 468);
            beginSimpBtn.Name = "beginSimpBtn";
            beginSimpBtn.Size = new Size(123, 64);
            beginSimpBtn.TabIndex = 13;
            beginSimpBtn.Text = "BEGIN";
            beginSimpBtn.UseVisualStyleBackColor = true;
            beginSimpBtn.Click += beginSimpBtn_Click;
            // 
            // readCSVFileBtn
            // 
            readCSVFileBtn.Location = new Point(925, 231);
            readCSVFileBtn.Name = "readCSVFileBtn";
            readCSVFileBtn.Size = new Size(94, 29);
            readCSVFileBtn.TabIndex = 12;
            readCSVFileBtn.Text = "Read File";
            readCSVFileBtn.UseVisualStyleBackColor = true;
            readCSVFileBtn.Click += readCSVFileBtn_Click;
            // 
            // label4
            // 
            label4.Location = new Point(816, 150);
            label4.Name = "label4";
            label4.Size = new Size(262, 42);
            label4.TabIndex = 11;
            label4.Text = "Select simulated pressure csv file (e.g. simulated_pressure.csv):\r\n\r\n";
            // 
            // label3
            // 
            label3.Location = new Point(816, 299);
            label3.Name = "label3";
            label3.Size = new Size(537, 89);
            label3.TabIndex = 9;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label2
            // 
            label2.Location = new Point(816, 15);
            label2.Name = "label2";
            label2.Size = new Size(552, 121);
            label2.TabIndex = 8;
            label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(841, 15);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 7;
            // 
            // rxDisplayLabel
            // 
            rxDisplayLabel.AutoSize = true;
            rxDisplayLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rxDisplayLabel.Location = new Point(16, 324);
            rxDisplayLabel.Name = "rxDisplayLabel";
            rxDisplayLabel.Size = new Size(184, 20);
            rxDisplayLabel.TabIndex = 6;
            rxDisplayLabel.Text = "Received packet telemetry";
            // 
            // txDisplayLabel
            // 
            txDisplayLabel.AutoSize = true;
            txDisplayLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txDisplayLabel.Location = new Point(407, 324);
            txDisplayLabel.Name = "txDisplayLabel";
            txDisplayLabel.Size = new Size(202, 20);
            txDisplayLabel.TabIndex = 5;
            txDisplayLabel.Text = "Transmitted packet telemetry";
            // 
            // txSimpTelemetryTextBox
            // 
            txSimpTelemetryTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txSimpTelemetryTextBox.Location = new Point(407, 352);
            txSimpTelemetryTextBox.Multiline = true;
            txSimpTelemetryTextBox.Name = "txSimpTelemetryTextBox";
            txSimpTelemetryTextBox.ScrollBars = ScrollBars.Vertical;
            txSimpTelemetryTextBox.Size = new Size(357, 290);
            txSimpTelemetryTextBox.TabIndex = 4;
            // 
            // rxSIMPlabel
            // 
            rxSIMPlabel.AutoSize = true;
            rxSIMPlabel.Location = new Point(407, 50);
            rxSIMPlabel.Name = "rxSIMPlabel";
            rxSIMPlabel.Size = new Size(120, 20);
            rxSIMPlabel.TabIndex = 3;
            rxSIMPlabel.Text = "Packets received:";
            // 
            // txSIMPlabel
            // 
            txSIMPlabel.AutoSize = true;
            txSIMPlabel.Location = new Point(407, 15);
            txSIMPlabel.Name = "txSIMPlabel";
            txSIMPlabel.Size = new Size(140, 20);
            txSIMPlabel.TabIndex = 2;
            txSIMPlabel.Text = "Packets transmitted:";
            // 
            // rxSimpTelemetryTextBox
            // 
            rxSimpTelemetryTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rxSimpTelemetryTextBox.Location = new Point(16, 352);
            rxSimpTelemetryTextBox.Multiline = true;
            rxSimpTelemetryTextBox.Name = "rxSimpTelemetryTextBox";
            rxSimpTelemetryTextBox.ScrollBars = ScrollBars.Vertical;
            rxSimpTelemetryTextBox.Size = new Size(355, 290);
            rxSimpTelemetryTextBox.TabIndex = 1;
            // 
            // simPressurePlot
            // 
            simPressurePlot.DisplayScale = 1.25F;
            simPressurePlot.Location = new Point(16, 15);
            simPressurePlot.Name = "simPressurePlot";
            simPressurePlot.Size = new Size(366, 282);
            simPressurePlot.TabIndex = 0;
            // 
            // commandBtn
            // 
            commandBtn.Location = new Point(1416, 37);
            commandBtn.Name = "commandBtn";
            commandBtn.Size = new Size(108, 77);
            commandBtn.TabIndex = 3;
            commandBtn.Text = "Send Command";
            commandBtn.UseVisualStyleBackColor = true;
            commandBtn.Click += commandBtn_Click;
            // 
            // modeLabel
            // 
            modeLabel.AutoSize = true;
            modeLabel.Location = new Point(1416, 305);
            modeLabel.Name = "modeLabel";
            modeLabel.Size = new Size(55, 20);
            modeLabel.TabIndex = 4;
            modeLabel.Text = "Mode: ";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(1416, 358);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(50, 20);
            stateLabel.TabIndex = 5;
            stateLabel.Text = "State: ";
            // 
            // airSpeedLabel
            // 
            airSpeedLabel.AutoSize = true;
            airSpeedLabel.Location = new Point(1416, 414);
            airSpeedLabel.Name = "airSpeedLabel";
            airSpeedLabel.Size = new Size(81, 20);
            airSpeedLabel.TabIndex = 6;
            airSpeedLabel.Text = "Air Speed: ";
            // 
            // pcLabel
            // 
            pcLabel.AutoSize = true;
            pcLabel.Location = new Point(1416, 528);
            pcLabel.Name = "pcLabel";
            pcLabel.Size = new Size(76, 20);
            pcLabel.TabIndex = 7;
            pcLabel.Text = "Parachute:";
            // 
            // hsLabel
            // 
            hsLabel.AutoSize = true;
            hsLabel.Location = new Point(1416, 469);
            hsLabel.Name = "hsLabel";
            hsLabel.Size = new Size(93, 20);
            hsLabel.TabIndex = 8;
            hsLabel.Text = "Heat Shield: ";
            // 
            // temperatureLabel
            // 
            temperatureLabel.AutoSize = true;
            temperatureLabel.Location = new Point(1416, 583);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new Size(100, 20);
            temperatureLabel.TabIndex = 9;
            temperatureLabel.Text = "Temperature: ";
            // 
            // batteryLabel
            // 
            batteryLabel.AutoSize = true;
            batteryLabel.Location = new Point(1416, 638);
            batteryLabel.Name = "batteryLabel";
            batteryLabel.Size = new Size(67, 20);
            batteryLabel.TabIndex = 10;
            batteryLabel.Text = "Voltage: ";
            // 
            // radioSetupBtn
            // 
            radioSetupBtn.Location = new Point(1416, 146);
            radioSetupBtn.Name = "radioSetupBtn";
            radioSetupBtn.Size = new Size(108, 77);
            radioSetupBtn.TabIndex = 11;
            radioSetupBtn.Text = "Set up Radio";
            radioSetupBtn.UseVisualStyleBackColor = true;
            radioSetupBtn.Click += radioSetupBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1536, 748);
            Controls.Add(radioSetupBtn);
            Controls.Add(batteryLabel);
            Controls.Add(temperatureLabel);
            Controls.Add(hsLabel);
            Controls.Add(pcLabel);
            Controls.Add(airSpeedLabel);
            Controls.Add(stateLabel);
            Controls.Add(modeLabel);
            Controls.Add(commandBtn);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Ground Station";
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            allGraphsTabPage.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableDataGrid).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            simulationTabPage.ResumeLayout(false);
            simulationTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl;
        private TabPage allGraphsTabPage;
        private ScottPlot.WinForms.FormsPlot pressurePlot;
        public Button commandBtn;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TextBox telemetryTextBox;
        private ScottPlot.WinForms.FormsPlot altitudePlot;
        private ScottPlot.WinForms.FormsPlot latitudePlot;
        private ScottPlot.WinForms.FormsPlot packetCountPlot;
        private ScottPlot.WinForms.FormsPlot tiltYPlot;
        private ScottPlot.WinForms.FormsPlot tiltXPlot;
        private ScottPlot.WinForms.FormsPlot rotationRatePlot;
        private ScottPlot.WinForms.FormsPlot longitudePlot;
        private TabPage tabPage1;
        private TabPage simulationTabPage;
        private ScottPlot.WinForms.FormsPlot simPressurePlot;
        private TextBox rxSimpTelemetryTextBox;
        private Label txSIMPlabel;
        private Label rxSIMPlabel;
        private TextBox txSimpTelemetryTextBox;
        private Label rxDisplayLabel;
        private Label txDisplayLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button readCSVFileBtn;
        private Label label4;
        private Button beginSimpBtn;
        private Button stopSimpBtn;
        private Button findFilesBtn;
        private ComboBox simpFileComboBox;
        private TextBox commandLogTextBox;
        private DataGridView tableDataGrid;
        private DataGridViewTextBoxColumn teamID;
        private DataGridViewTextBoxColumn missionTime;
        private DataGridViewTextBoxColumn packetCount;
        private DataGridViewTextBoxColumn mode;
        private DataGridViewTextBoxColumn state;
        private DataGridViewTextBoxColumn altitude;
        private DataGridViewTextBoxColumn airSpeed;
        private DataGridViewTextBoxColumn hs_Deployed;
        private DataGridViewTextBoxColumn pc_deployed;
        private DataGridViewTextBoxColumn temperature;
        private DataGridViewTextBoxColumn voltage;
        private DataGridViewTextBoxColumn pressure;
        private DataGridViewTextBoxColumn GPS_Time;
        private DataGridViewTextBoxColumn GPS_Altitude;
        private DataGridViewTextBoxColumn GPS_Longitude;
        private DataGridViewTextBoxColumn GPS_Latitude;
        private DataGridViewTextBoxColumn GPS_Sats;
        private DataGridViewTextBoxColumn tiltX;
        private DataGridViewTextBoxColumn tiltY;
        private DataGridViewTextBoxColumn rotZ;
        private DataGridViewTextBoxColumn CMD_Echo;
        private Label modeLabel;
        private Label stateLabel;
        private Label airSpeedLabel;
        private Label pcLabel;
        private Label hsLabel;
        private Label temperatureLabel;
        private Label batteryLabel;
        private Button radioSetupBtn;
    }
}
