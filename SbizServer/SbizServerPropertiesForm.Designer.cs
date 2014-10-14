namespace SbizServer
{
    partial class SbizServerPropertiesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SbizServerPropertiesForm));
            this.SbizServerNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SbizServerConnectionStatusLabel = new System.Windows.Forms.Label();
            this.SbizServerSetPortButton = new System.Windows.Forms.Button();
            this.SbizServerStopConnectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SbizServerSetPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SbizServerSetPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SbizServerNotifyIcon
            // 
            this.SbizServerNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SbizServerNotifyIcon.Icon")));
            this.SbizServerNotifyIcon.Text = "Sbiz Server";
            this.SbizServerNotifyIcon.Visible = true;
            this.SbizServerNotifyIcon.DoubleClick += new System.EventHandler(this.SbizServerNotifyIcon_DoubleClick);
            // 
            // SbizServerConnectionStatusLabel
            // 
            this.SbizServerConnectionStatusLabel.AutoSize = true;
            this.SbizServerConnectionStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.SbizServerConnectionStatusLabel.Location = new System.Drawing.Point(188, 105);
            this.SbizServerConnectionStatusLabel.Name = "SbizServerConnectionStatusLabel";
            this.SbizServerConnectionStatusLabel.Size = new System.Drawing.Size(79, 13);
            this.SbizServerConnectionStatusLabel.TabIndex = 0;
            this.SbizServerConnectionStatusLabel.Text = "Not Connected";
            // 
            // SbizServerSetPortButton
            // 
            this.SbizServerSetPortButton.AutoSize = true;
            this.SbizServerSetPortButton.Location = new System.Drawing.Point(167, 54);
            this.SbizServerSetPortButton.Name = "SbizServerSetPortButton";
            this.SbizServerSetPortButton.Size = new System.Drawing.Size(100, 26);
            this.SbizServerSetPortButton.TabIndex = 1;
            this.SbizServerSetPortButton.Text = "Set Port";
            this.SbizServerSetPortButton.UseVisualStyleBackColor = true;
            this.SbizServerSetPortButton.Click += new System.EventHandler(this.SbizServerSetPortButton_Click);
            // 
            // SbizServerStopConnectionButton
            // 
            this.SbizServerStopConnectionButton.Enabled = false;
            this.SbizServerStopConnectionButton.Location = new System.Drawing.Point(167, 130);
            this.SbizServerStopConnectionButton.Name = "SbizServerStopConnectionButton";
            this.SbizServerStopConnectionButton.Size = new System.Drawing.Size(100, 28);
            this.SbizServerStopConnectionButton.TabIndex = 3;
            this.SbizServerStopConnectionButton.Text = "Stop Connection";
            this.SbizServerStopConnectionButton.UseVisualStyleBackColor = true;
            this.SbizServerStopConnectionButton.Click += new System.EventHandler(this.SbizServerStopConnectionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Configure server input port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Connection Status: ";
            // 
            // SbizServerSetPortNumericUpDown
            // 
            this.SbizServerSetPortNumericUpDown.Location = new System.Drawing.Point(152, 26);
            this.SbizServerSetPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SbizServerSetPortNumericUpDown.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.SbizServerSetPortNumericUpDown.Name = "SbizServerSetPortNumericUpDown";
            this.SbizServerSetPortNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.SbizServerSetPortNumericUpDown.TabIndex = 7;
            this.SbizServerSetPortNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SbizServerSetPortNumericUpDown.Value = new decimal(new int[] {
            49952,
            0,
            0,
            0});
            this.SbizServerSetPortNumericUpDown.Paint += new System.Windows.Forms.PaintEventHandler(this.SbizServerSetPortNumericUpDown_Paint);
            // 
            // SbizServerPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.SbizServerSetPortNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SbizServerStopConnectionButton);
            this.Controls.Add(this.SbizServerSetPortButton);
            this.Controls.Add(this.SbizServerConnectionStatusLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SbizServerPropertiesForm";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.SbizServerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SbizServerSetPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SbizServerNotifyIcon;
        private System.Windows.Forms.Label SbizServerConnectionStatusLabel;
        private System.Windows.Forms.Button SbizServerSetPortButton;
        private System.Windows.Forms.Button SbizServerStopConnectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SbizServerSetPortNumericUpDown;
    }
}

