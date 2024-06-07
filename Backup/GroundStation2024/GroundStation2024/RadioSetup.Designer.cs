namespace GroundStation2024
{
    partial class RadioSetup
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            configureBtn = new Button();
            portSelectionComboBox = new ComboBox();
            baudRateSelectionComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 30);
            label1.Name = "label1";
            label1.Size = new Size(294, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter COM port (e.g. COM6) and baud rate:\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 90);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "COM Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 141);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 2;
            label3.Text = "Baud Rate:";
            // 
            // configureBtn
            // 
            configureBtn.Location = new Point(147, 193);
            configureBtn.Name = "configureBtn";
            configureBtn.Size = new Size(94, 29);
            configureBtn.TabIndex = 5;
            configureBtn.Text = "Configure";
            configureBtn.UseVisualStyleBackColor = true;
            configureBtn.Click += configureBtn_Click;
            // 
            // portSelectionComboBox
            // 
            portSelectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            portSelectionComboBox.FormattingEnabled = true;
            portSelectionComboBox.Location = new Point(215, 82);
            portSelectionComboBox.Name = "portSelectionComboBox";
            portSelectionComboBox.Size = new Size(151, 28);
            portSelectionComboBox.TabIndex = 6;
            // 
            // baudRateSelectionComboBox
            // 
            baudRateSelectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            baudRateSelectionComboBox.FormattingEnabled = true;
            baudRateSelectionComboBox.Items.AddRange(new object[] { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400" });
            baudRateSelectionComboBox.Location = new Point(215, 133);
            baudRateSelectionComboBox.Name = "baudRateSelectionComboBox";
            baudRateSelectionComboBox.Size = new Size(151, 28);
            baudRateSelectionComboBox.TabIndex = 7;
            // 
            // RadioSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 246);
            Controls.Add(baudRateSelectionComboBox);
            Controls.Add(portSelectionComboBox);
            Controls.Add(configureBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RadioSetup";
            Text = "Radio Setup";
            Load += RadioSetup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button configureBtn;
        private ComboBox portSelectionComboBox;
        private ComboBox baudRateSelectionComboBox;
    }
}