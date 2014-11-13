namespace SbizServer
{
    partial class SbizServerPropertiesUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.SbizServerServerNameTextbox = new System.Windows.Forms.TextBox();
            this.SbizServerSetUDPPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SbizServerApplySettingsButton = new System.Windows.Forms.Button();
            this.SbizMyIPLabel = new System.Windows.Forms.Label();
            this.SbizServerSetTCPPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SbizServerStopConnectionButton = new System.Windows.Forms.Button();
            this.SbizServerConnectionStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SbizServerSetUDPPortNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SbizServerSetTCPPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Server name:";
            // 
            // SbizServerServerNameTextbox
            // 
            this.SbizServerServerNameTextbox.Location = new System.Drawing.Point(29, 120);
            this.SbizServerServerNameTextbox.MaxLength = 15;
            this.SbizServerServerNameTextbox.Name = "SbizServerServerNameTextbox";
            this.SbizServerServerNameTextbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SbizServerServerNameTextbox.Size = new System.Drawing.Size(192, 20);
            this.SbizServerServerNameTextbox.TabIndex = 23;
            // 
            // SbizServerSetUDPPortNumericUpDown
            // 
            this.SbizServerSetUDPPortNumericUpDown.Location = new System.Drawing.Point(121, 66);
            this.SbizServerSetUDPPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SbizServerSetUDPPortNumericUpDown.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.SbizServerSetUDPPortNumericUpDown.Name = "SbizServerSetUDPPortNumericUpDown";
            this.SbizServerSetUDPPortNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.SbizServerSetUDPPortNumericUpDown.TabIndex = 22;
            this.SbizServerSetUDPPortNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SbizServerSetUDPPortNumericUpDown.Value = new decimal(new int[] {
            49952,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Output UDP port:";
            // 
            // SbizServerApplySettingsButton
            // 
            this.SbizServerApplySettingsButton.AutoSize = true;
            this.SbizServerApplySettingsButton.Location = new System.Drawing.Point(121, 146);
            this.SbizServerApplySettingsButton.Name = "SbizServerApplySettingsButton";
            this.SbizServerApplySettingsButton.Size = new System.Drawing.Size(100, 26);
            this.SbizServerApplySettingsButton.TabIndex = 20;
            this.SbizServerApplySettingsButton.Text = "Apply Settings";
            this.SbizServerApplySettingsButton.UseVisualStyleBackColor = true;
            this.SbizServerApplySettingsButton.Click += new System.EventHandler(this.SbizServerApplySettingsButton_Click);
            // 
            // SbizMyIPLabel
            // 
            this.SbizMyIPLabel.AutoSize = true;
            this.SbizMyIPLabel.Location = new System.Drawing.Point(21, 295);
            this.SbizMyIPLabel.Name = "SbizMyIPLabel";
            this.SbizMyIPLabel.Size = new System.Drawing.Size(105, 13);
            this.SbizMyIPLabel.TabIndex = 19;
            this.SbizMyIPLabel.Text = "Your IP Address is: ?";
            // 
            // SbizServerSetTCPPortNumericUpDown
            // 
            this.SbizServerSetTCPPortNumericUpDown.Location = new System.Drawing.Point(121, 30);
            this.SbizServerSetTCPPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SbizServerSetTCPPortNumericUpDown.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.SbizServerSetTCPPortNumericUpDown.Name = "SbizServerSetTCPPortNumericUpDown";
            this.SbizServerSetTCPPortNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.SbizServerSetTCPPortNumericUpDown.TabIndex = 18;
            this.SbizServerSetTCPPortNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SbizServerSetTCPPortNumericUpDown.Value = new decimal(new int[] {
            49952,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Connection Status: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Input TCP port:";
            // 
            // SbizServerStopConnectionButton
            // 
            this.SbizServerStopConnectionButton.Enabled = false;
            this.SbizServerStopConnectionButton.Location = new System.Drawing.Point(124, 246);
            this.SbizServerStopConnectionButton.Name = "SbizServerStopConnectionButton";
            this.SbizServerStopConnectionButton.Size = new System.Drawing.Size(100, 28);
            this.SbizServerStopConnectionButton.TabIndex = 15;
            this.SbizServerStopConnectionButton.Text = "Stop Connection";
            this.SbizServerStopConnectionButton.UseVisualStyleBackColor = true;
            this.SbizServerStopConnectionButton.Click += new System.EventHandler(this.SbizServerStopConnectionButton_Click);
            // 
            // SbizServerConnectionStatusLabel
            // 
            this.SbizServerConnectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.SbizServerConnectionStatusLabel.Location = new System.Drawing.Point(121, 221);
            this.SbizServerConnectionStatusLabel.Name = "SbizServerConnectionStatusLabel";
            this.SbizServerConnectionStatusLabel.Size = new System.Drawing.Size(100, 13);
            this.SbizServerConnectionStatusLabel.TabIndex = 14;
            this.SbizServerConnectionStatusLabel.Text = "Not Connected";
            this.SbizServerConnectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SbizServerPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SbizServerServerNameTextbox);
            this.Controls.Add(this.SbizServerSetUDPPortNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SbizServerApplySettingsButton);
            this.Controls.Add(this.SbizMyIPLabel);
            this.Controls.Add(this.SbizServerSetTCPPortNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SbizServerStopConnectionButton);
            this.Controls.Add(this.SbizServerConnectionStatusLabel);
            this.Name = "SbizServerPropertiesUC";
            this.Size = new System.Drawing.Size(245, 336);
            ((System.ComponentModel.ISupportInitialize)(this.SbizServerSetUDPPortNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SbizServerSetTCPPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SbizServerServerNameTextbox;
        private System.Windows.Forms.NumericUpDown SbizServerSetUDPPortNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SbizServerApplySettingsButton;
        private System.Windows.Forms.Label SbizMyIPLabel;
        private System.Windows.Forms.NumericUpDown SbizServerSetTCPPortNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SbizServerStopConnectionButton;
        private System.Windows.Forms.Label SbizServerConnectionStatusLabel;
    }
}
