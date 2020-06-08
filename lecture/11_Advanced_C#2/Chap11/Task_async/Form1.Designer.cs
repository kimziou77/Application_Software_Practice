namespace Task_async
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLog = new System.Windows.Forms.Label();
            this.pbLog = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("굴림", 11F);
            this.lblLog.Location = new System.Drawing.Point(20, 34);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(19, 19);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "0";
            // 
            // pbLog
            // 
            this.pbLog.Location = new System.Drawing.Point(24, 74);
            this.pbLog.Name = "pbLog";
            this.pbLog.Size = new System.Drawing.Size(275, 32);
            this.pbLog.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(101, 128);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 46);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 197);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbLog);
            this.Controls.Add(this.lblLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ProgressBar pbLog;
        private System.Windows.Forms.Button btnStart;
    }
}

