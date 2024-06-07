namespace GroundStation2024
{
    partial class CommandForm
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
            commandLabel = new Label();
            label1 = new Label();
            commandMenu = new ComboBox();
            sendCommandBtn = new Button();
            SuspendLayout();
            // 
            // commandLabel
            // 
            commandLabel.AutoSize = true;
            commandLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            commandLabel.Location = new Point(170, 9);
            commandLabel.Name = "commandLabel";
            commandLabel.Size = new Size(97, 23);
            commandLabel.TabIndex = 0;
            commandLabel.Text = "Commands";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 64);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 1;
            label1.Text = "Command:";
            // 
            // commandMenu
            // 
            commandMenu.FormattingEnabled = true;
            commandMenu.Items.AddRange(new object[] { "CMD,2045,CX,ON", "CMD,2045,CX,OFF", "CMD,2045,ST,<UTC_TIME>", "CMD,2045,ST,GPS", "CMD,2045,SIM,ACTIVATE", "CMD,2045,SIM,ENABLE", "CMD,2045,SIM,DISABLE", "CMD,2045,CAL", "CMD,2045,BCN,ON", "CMD,2045,BCN,OFF" });
            commandMenu.Location = new Point(203, 61);
            commandMenu.Name = "commandMenu";
            commandMenu.Size = new Size(228, 28);
            commandMenu.TabIndex = 2;
            commandMenu.SelectedIndexChanged += commandMenu_SelectedIndexChanged;
            // 
            // sendCommandBtn
            // 
            sendCommandBtn.Location = new Point(170, 142);
            sendCommandBtn.Name = "sendCommandBtn";
            sendCommandBtn.Size = new Size(97, 37);
            sendCommandBtn.TabIndex = 3;
            sendCommandBtn.Text = "Send";
            sendCommandBtn.UseVisualStyleBackColor = true;
            sendCommandBtn.Click += sendCommandBtn_Click;
            // 
            // CommandForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 201);
            Controls.Add(sendCommandBtn);
            Controls.Add(commandMenu);
            Controls.Add(label1);
            Controls.Add(commandLabel);
            Name = "CommandForm";
            Text = "Command Form";
            Load += CommandForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label commandLabel;
        private Label label1;
        private ComboBox commandMenu;
        private Button sendCommandBtn;
    }
}