namespace ComboBox_Example
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
            this.lblBirthday = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.lblToggle = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Font = new System.Drawing.Font("굴림", 14F);
            this.lblBirthday.Location = new System.Drawing.Point(12, 30);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(58, 24);
            this.lblBirthday.TabIndex = 0;
            this.lblBirthday.Text = "생일";
            // 
            // cmbYear
            // 
            this.cmbYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(102, 34);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 23);
            this.cmbYear.TabIndex = 1;
            this.cmbYear.Text = "년(4자)";
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmb_ItemOrtextChanged);
            this.cmbYear.TextChanged += new System.EventHandler(this.cmb_ItemOrtextChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(255, 34);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 23);
            this.cmbMonth.TabIndex = 2;
            this.cmbMonth.Text = "월";
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmb_ItemOrtextChanged);
            this.cmbMonth.TextChanged += new System.EventHandler(this.cmb_ItemOrtextChanged);
            // 
            // cmbDay
            // 
            this.cmbDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(404, 34);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(121, 23);
            this.cmbDay.TabIndex = 3;
            this.cmbDay.Text = "일";
            this.cmbDay.TextChanged += new System.EventHandler(this.cmb_ItemOrtextChanged);
            // 
            // lblToggle
            // 
            this.lblToggle.AutoSize = true;
            this.lblToggle.Font = new System.Drawing.Font("굴림", 12F);
            this.lblToggle.Location = new System.Drawing.Point(58, 137);
            this.lblToggle.Name = "lblToggle";
            this.lblToggle.Size = new System.Drawing.Size(46, 20);
            this.lblToggle.TabIndex = 4;
            this.lblToggle.Text = "label";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(39, 176);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(546, 220);
            this.txtNote.TabIndex = 5;
            this.txtNote.WordWrap = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(464, 411);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(121, 47);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 470);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblToggle);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblBirthday);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label lblToggle;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnCalculate;
    }
}

