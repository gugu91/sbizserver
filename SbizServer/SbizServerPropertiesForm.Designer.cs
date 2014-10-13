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
            this.SetPortButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StopConnectionBUtton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.SbizServerConnectionStatusLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.SbizServerConnectionStatusLabel_Paint);
            // 
            // SetPortButton
            // 
            this.SetPortButton.AutoSize = true;
            this.SetPortButton.Location = new System.Drawing.Point(167, 54);
            this.SetPortButton.Name = "SetPortButton";
            this.SetPortButton.Size = new System.Drawing.Size(100, 26);
            this.SetPortButton.TabIndex = 1;
            this.SetPortButton.Text = "Set Port";
            this.SetPortButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "15001";
            // 
            // StopConnectionBUtton
            // 
            this.StopConnectionBUtton.Enabled = false;
            this.StopConnectionBUtton.Location = new System.Drawing.Point(167, 130);
            this.StopConnectionBUtton.Name = "StopConnectionBUtton";
            this.StopConnectionBUtton.Size = new System.Drawing.Size(100, 28);
            this.StopConnectionBUtton.TabIndex = 3;
            this.StopConnectionBUtton.Text = "Stop Connection";
            this.StopConnectionBUtton.UseVisualStyleBackColor = true;
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
            // SbizServerPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopConnectionBUtton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SetPortButton);
            this.Controls.Add(this.SbizServerConnectionStatusLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SbizServerPropertiesForm";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.SbizServerForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SbizServerNotifyIcon;
        private System.Windows.Forms.Label SbizServerConnectionStatusLabel;
        private System.Windows.Forms.Button SetPortButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button StopConnectionBUtton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

