namespace _08_Socket_Programming_02
{
    partial class ChattingProgram
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
            this.txt_all = new System.Windows.Forms.TextBox();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Server = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_ServerIp = new System.Windows.Forms.TextBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_all
            // 
            this.txt_all.Location = new System.Drawing.Point(0, 12);
            this.txt_all.Multiline = true;
            this.txt_all.Name = "txt_all";
            this.txt_all.Size = new System.Drawing.Size(342, 333);
            this.txt_all.TabIndex = 0;
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(0, 361);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(342, 25);
            this.txt_send.TabIndex = 1;
            this.txt_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_send_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ServerIp);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.btn_Server);
            this.groupBox1.Location = new System.Drawing.Point(348, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 240);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "옵션";
            // 
            // btn_Server
            // 
            this.btn_Server.ForeColor = System.Drawing.Color.Black;
            this.btn_Server.Location = new System.Drawing.Point(18, 34);
            this.btn_Server.Name = "btn_Server";
            this.btn_Server.Size = new System.Drawing.Size(177, 44);
            this.btn_Server.TabIndex = 0;
            this.btn_Server.Text = "서버 켜기";
            this.btn_Server.UseVisualStyleBackColor = true;
            this.btn_Server.Click += new System.EventHandler(this.btn_Server_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(17, 110);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(177, 44);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "서버 연결";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_ServerIp
            // 
            this.txt_ServerIp.Location = new System.Drawing.Point(18, 189);
            this.txt_ServerIp.Name = "txt_ServerIp";
            this.txt_ServerIp.Size = new System.Drawing.Size(176, 25);
            this.txt_ServerIp.TabIndex = 2;
            this.txt_ServerIp.Text = "127.0.0.1";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(366, 272);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(177, 44);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "프로그램 종료";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(366, 342);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(177, 44);
            this.btn_Send.TabIndex = 4;
            this.btn_Send.Text = "보내기";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 407);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.txt_all);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_all;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ServerIp;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Server;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Send;
    }
}

