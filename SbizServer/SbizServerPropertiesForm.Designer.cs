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
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.sbizServerPropertiesUC1 = new SbizServer.SbizServerPropertiesUC();
            this.SuspendLayout();
            // 
            // SbizServerNotifyIcon
            // 
            this.SbizServerNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SbizServerNotifyIcon.Icon")));
            this.SbizServerNotifyIcon.Text = "Sbiz Server";
            this.SbizServerNotifyIcon.Visible = true;
            this.SbizServerNotifyIcon.DoubleClick += new System.EventHandler(this.SbizServerNotifyIcon_DoubleClick);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // sbizServerPropertiesUC1
            // 
            this.sbizServerPropertiesUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbizServerPropertiesUC1.Location = new System.Drawing.Point(0, 0);
            this.sbizServerPropertiesUC1.Name = "sbizServerPropertiesUC1";
            this.sbizServerPropertiesUC1.Size = new System.Drawing.Size(252, 332);
            this.sbizServerPropertiesUC1.TabIndex = 0;
            // 
            // SbizServerPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 332);
            this.Controls.Add(this.sbizServerPropertiesUC1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SbizServerPropertiesForm";
            this.Text = "SbizServer Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SbizServerFormClosing);
            this.Resize += new System.EventHandler(this.SbizServerForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon SbizServerNotifyIcon;
        private SbizServerPropertiesUC sbizServerPropertiesUC1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}

