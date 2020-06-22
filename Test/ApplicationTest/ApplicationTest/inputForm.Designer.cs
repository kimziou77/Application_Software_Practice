namespace ApplicationTest
{
    partial class inputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtStdNum = new System.Windows.Forms.TextBox();
            this.txtEng = new System.Windows.Forms.TextBox();
            this.txtKor = new System.Windows.Forms.TextBox();
            this.txtMath = new System.Windows.Forms.TextBox();
            this.txtSoc = new System.Windows.Forms.TextBox();
            this.txtSci = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "이름 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "학번 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "국어 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "영어 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "수학 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "사회 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "과학 : ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 25);
            this.txtName.TabIndex = 7;
            // 
            // txtStdNum
            // 
            this.txtStdNum.Location = new System.Drawing.Point(84, 56);
            this.txtStdNum.Name = "txtStdNum";
            this.txtStdNum.Size = new System.Drawing.Size(100, 25);
            this.txtStdNum.TabIndex = 8;
            // 
            // txtEng
            // 
            this.txtEng.Location = new System.Drawing.Point(84, 110);
            this.txtEng.Name = "txtEng";
            this.txtEng.Size = new System.Drawing.Size(100, 25);
            this.txtEng.TabIndex = 9;
            // 
            // txtKor
            // 
            this.txtKor.Location = new System.Drawing.Point(84, 82);
            this.txtKor.Name = "txtKor";
            this.txtKor.Size = new System.Drawing.Size(100, 25);
            this.txtKor.TabIndex = 10;
            // 
            // txtMath
            // 
            this.txtMath.Location = new System.Drawing.Point(84, 137);
            this.txtMath.Name = "txtMath";
            this.txtMath.Size = new System.Drawing.Size(100, 25);
            this.txtMath.TabIndex = 11;
            // 
            // txtSoc
            // 
            this.txtSoc.Location = new System.Drawing.Point(84, 165);
            this.txtSoc.Name = "txtSoc";
            this.txtSoc.Size = new System.Drawing.Size(100, 25);
            this.txtSoc.TabIndex = 12;
            // 
            // txtSci
            // 
            this.txtSci.Location = new System.Drawing.Point(84, 196);
            this.txtSci.Name = "txtSci";
            this.txtSci.Size = new System.Drawing.Size(100, 25);
            this.txtSci.TabIndex = 13;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(83, 232);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 57);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "입력";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // inputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 301);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtSci);
            this.Controls.Add(this.txtSoc);
            this.Controls.Add(this.txtMath);
            this.Controls.Add(this.txtKor);
            this.Controls.Add(this.txtEng);
            this.Controls.Add(this.txtStdNum);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "inputForm";
            this.Text = "input_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStdNum;
        private System.Windows.Forms.TextBox txtEng;
        private System.Windows.Forms.TextBox txtKor;
        private System.Windows.Forms.TextBox txtMath;
        private System.Windows.Forms.TextBox txtSoc;
        private System.Windows.Forms.TextBox txtSci;
        private System.Windows.Forms.Button btnOk;
    }
}

