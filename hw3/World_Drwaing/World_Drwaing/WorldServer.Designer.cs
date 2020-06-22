namespace World_Drwaing
{
    partial class WorldServer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chattingLog = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 291);
            this.panel1.TabIndex = 0;
            // 
            // chattingLog
            // 
            this.chattingLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chattingLog.Location = new System.Drawing.Point(0, 291);
            this.chattingLog.Multiline = true;
            this.chattingLog.Name = "chattingLog";
            this.chattingLog.Size = new System.Drawing.Size(800, 159);
            this.chattingLog.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 291);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(800, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // WorldServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.chattingLog);
            this.Controls.Add(this.panel1);
            this.Name = "WorldServer";
            this.Text = "세계그림판_서버";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorldServer_FormClosing);
            this.Load += new System.EventHandler(this.WorldServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox chattingLog;
        private System.Windows.Forms.Splitter splitter1;
    }
}