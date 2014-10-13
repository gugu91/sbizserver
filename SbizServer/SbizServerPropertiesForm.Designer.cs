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
            this.SbizServerConnectionStatusLabel.Location = new System.Drawing.Point(106, 204);
            this.SbizServerConnectionStatusLabel.Name = "SbizServerConnectionStatusLabel";
            this.SbizServerConnectionStatusLabel.Size = new System.Drawing.Size(77, 13);
            this.SbizServerConnectionStatusLabel.TabIndex = 0;
            this.SbizServerConnectionStatusLabel.Text = "Non Connesso";
            // 
            // SbizServerPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
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
    }
}

