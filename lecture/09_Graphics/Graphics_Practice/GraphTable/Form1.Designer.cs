namespace GraphTable
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
            this.displayBTN = new System.Windows.Forms.Button();
            this.clearBTN = new System.Windows.Forms.Button();
            this.exitBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.booksTB = new System.Windows.Forms.TextBox();
            this.periodicalsTB = new System.Windows.Forms.TextBox();
            this.foodsTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // displayBTN
            // 
            this.displayBTN.Location = new System.Drawing.Point(15, 115);
            this.displayBTN.Name = "displayBTN";
            this.displayBTN.Size = new System.Drawing.Size(81, 38);
            this.displayBTN.TabIndex = 0;
            this.displayBTN.Text = "Display";
            this.displayBTN.UseVisualStyleBackColor = true;
            this.displayBTN.Click += new System.EventHandler(this.displayBTN_Click);
            // 
            // clearBTN
            // 
            this.clearBTN.Location = new System.Drawing.Point(15, 162);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(81, 38);
            this.clearBTN.TabIndex = 1;
            this.clearBTN.Text = "Clear";
            this.clearBTN.UseVisualStyleBackColor = true;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // exitBTN
            // 
            this.exitBTN.Location = new System.Drawing.Point(15, 209);
            this.exitBTN.Name = "exitBTN";
            this.exitBTN.Size = new System.Drawing.Size(81, 38);
            this.exitBTN.TabIndex = 2;
            this.exitBTN.Text = "Exit";
            this.exitBTN.UseVisualStyleBackColor = true;
            this.exitBTN.Click += new System.EventHandler(this.exitBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Books";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Periodicals";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F);
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Foods";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Books: Blue, Periodicals :Yello, Food: Red";
            // 
            // booksTB
            // 
            this.booksTB.Location = new System.Drawing.Point(134, 13);
            this.booksTB.Name = "booksTB";
            this.booksTB.Size = new System.Drawing.Size(100, 25);
            this.booksTB.TabIndex = 7;
            // 
            // periodicalsTB
            // 
            this.periodicalsTB.Location = new System.Drawing.Point(134, 45);
            this.periodicalsTB.Name = "periodicalsTB";
            this.periodicalsTB.Size = new System.Drawing.Size(100, 25);
            this.periodicalsTB.TabIndex = 8;
            // 
            // foodsTB
            // 
            this.foodsTB.Location = new System.Drawing.Point(134, 79);
            this.foodsTB.Name = "foodsTB";
            this.foodsTB.Size = new System.Drawing.Size(100, 25);
            this.foodsTB.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 322);
            this.Controls.Add(this.foodsTB);
            this.Controls.Add(this.periodicalsTB);
            this.Controls.Add(this.booksTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitBTN);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.displayBTN);
            this.Name = "Form1";
            this.Text = "Graph";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button displayBTN;
        private System.Windows.Forms.Button clearBTN;
        private System.Windows.Forms.Button exitBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox booksTB;
        private System.Windows.Forms.TextBox periodicalsTB;
        private System.Windows.Forms.TextBox foodsTB;
    }
}

