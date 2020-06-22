namespace ApplicationTest2
{
    partial class ServerForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnServerOn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lsvMain = new System.Windows.Forms.ListView();
            this.colIdx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStdNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEng = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "PORT :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(232, 25);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(371, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 25);
            this.textBox2.TabIndex = 4;
            // 
            // btnServerOn
            // 
            this.btnServerOn.Location = new System.Drawing.Point(514, 22);
            this.btnServerOn.Name = "btnServerOn";
            this.btnServerOn.Size = new System.Drawing.Size(90, 27);
            this.btnServerOn.TabIndex = 5;
            this.btnServerOn.Text = "서버켜기";
            this.btnServerOn.UseVisualStyleBackColor = true;
            this.btnServerOn.Click += new System.EventHandler(this.btnServerOn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 143);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "log";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 24);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(687, 113);
            this.textBox3.TabIndex = 7;
            // 
            // lsvMain
            // 
            this.lsvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdx,
            this.colName,
            this.colStdNum,
            this.colKor,
            this.colEng,
            this.colMath,
            this.colSoc,
            this.colSci});
            this.lsvMain.Location = new System.Drawing.Point(12, 214);
            this.lsvMain.Name = "lsvMain";
            this.lsvMain.Size = new System.Drawing.Size(693, 295);
            this.lsvMain.TabIndex = 7;
            this.lsvMain.UseCompatibleStateImageBehavior = false;
            this.lsvMain.View = System.Windows.Forms.View.Details;
            // 
            // colIdx
            // 
            this.colIdx.Text = "index";
            this.colIdx.Width = 84;
            // 
            // colName
            // 
            this.colName.Text = "이름";
            this.colName.Width = 88;
            // 
            // colStdNum
            // 
            this.colStdNum.Text = "학번";
            this.colStdNum.Width = 81;
            // 
            // colKor
            // 
            this.colKor.Text = "국어";
            this.colKor.Width = 87;
            // 
            // colEng
            // 
            this.colEng.Text = "영어";
            this.colEng.Width = 85;
            // 
            // colMath
            // 
            this.colMath.Text = "수학";
            this.colMath.Width = 87;
            // 
            // colSoc
            // 
            this.colSoc.Text = "사회";
            this.colSoc.Width = 86;
            // 
            // colSci
            // 
            this.colSci.Text = "과학";
            this.colSci.Width = 250;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 521);
            this.Controls.Add(this.lsvMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnServerOn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnServerOn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListView lsvMain;
        private System.Windows.Forms.ColumnHeader colIdx;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStdNum;
        private System.Windows.Forms.ColumnHeader colKor;
        private System.Windows.Forms.ColumnHeader colEng;
        private System.Windows.Forms.ColumnHeader colMath;
        private System.Windows.Forms.ColumnHeader colSoc;
        private System.Windows.Forms.ColumnHeader colSci;
    }
}

