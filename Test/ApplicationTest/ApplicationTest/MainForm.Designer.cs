namespace ApplicationTest
{
    partial class MainForm
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
            this.lsvMain = new System.Windows.Forms.ListView();
            this.colIdx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStdNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEng = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSci = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbKor = new System.Windows.Forms.CheckBox();
            this.cbEng = new System.Windows.Forms.CheckBox();
            this.cbMath = new System.Windows.Forms.CheckBox();
            this.cbSoc = new System.Windows.Forms.CheckBox();
            this.cbSci = new System.Windows.Forms.CheckBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.lsvMain.Location = new System.Drawing.Point(12, 12);
            this.lsvMain.Name = "lsvMain";
            this.lsvMain.Size = new System.Drawing.Size(680, 300);
            this.lsvMain.TabIndex = 0;
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
            // cbKor
            // 
            this.cbKor.AutoSize = true;
            this.cbKor.Location = new System.Drawing.Point(12, 24);
            this.cbKor.Name = "cbKor";
            this.cbKor.Size = new System.Drawing.Size(59, 19);
            this.cbKor.TabIndex = 1;
            this.cbKor.Text = "국어";
            this.cbKor.UseVisualStyleBackColor = true;
            this.cbKor.CheckedChanged += new System.EventHandler(this.cbKor_CheckedChanged_1);
            // 
            // cbEng
            // 
            this.cbEng.AutoSize = true;
            this.cbEng.Location = new System.Drawing.Point(166, 24);
            this.cbEng.Name = "cbEng";
            this.cbEng.Size = new System.Drawing.Size(59, 19);
            this.cbEng.TabIndex = 2;
            this.cbEng.Text = "영어";
            this.cbEng.UseVisualStyleBackColor = true;
            this.cbEng.CheckedChanged += new System.EventHandler(this.cbEng_CheckedChanged);
            // 
            // cbMath
            // 
            this.cbMath.AutoSize = true;
            this.cbMath.Location = new System.Drawing.Point(302, 24);
            this.cbMath.Name = "cbMath";
            this.cbMath.Size = new System.Drawing.Size(59, 19);
            this.cbMath.TabIndex = 3;
            this.cbMath.Text = "수학";
            this.cbMath.UseVisualStyleBackColor = true;
            this.cbMath.CheckedChanged += new System.EventHandler(this.cbMath_CheckedChanged);
            // 
            // cbSoc
            // 
            this.cbSoc.AutoSize = true;
            this.cbSoc.Location = new System.Drawing.Point(455, 24);
            this.cbSoc.Name = "cbSoc";
            this.cbSoc.Size = new System.Drawing.Size(59, 19);
            this.cbSoc.TabIndex = 4;
            this.cbSoc.Text = "사회";
            this.cbSoc.UseVisualStyleBackColor = true;
            this.cbSoc.CheckedChanged += new System.EventHandler(this.cbSoc_CheckedChanged);
            // 
            // cbSci
            // 
            this.cbSci.AutoSize = true;
            this.cbSci.Location = new System.Drawing.Point(587, 24);
            this.cbSci.Name = "cbSci";
            this.cbSci.Size = new System.Drawing.Size(59, 19);
            this.cbSci.TabIndex = 5;
            this.cbSci.Text = "과학";
            this.cbSci.UseVisualStyleBackColor = true;
            this.cbSci.CheckedChanged += new System.EventHandler(this.cbSci_CheckedChanged);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(111, 392);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(123, 63);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "보기";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(419, 392);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(123, 63);
            this.btnInput.TabIndex = 7;
            this.btnInput.Text = "입력";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSci);
            this.groupBox1.Controls.Add(this.cbKor);
            this.groupBox1.Controls.Add(this.cbEng);
            this.groupBox1.Controls.Add(this.cbMath);
            this.groupBox1.Controls.Add(this.cbSoc);
            this.groupBox1.Location = new System.Drawing.Point(14, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 61);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "필터링";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lsvMain);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvMain;
        private System.Windows.Forms.CheckBox cbKor;
        private System.Windows.Forms.CheckBox cbEng;
        private System.Windows.Forms.CheckBox cbMath;
        private System.Windows.Forms.CheckBox cbSoc;
        private System.Windows.Forms.CheckBox cbSci;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.ColumnHeader colIdx;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStdNum;
        private System.Windows.Forms.ColumnHeader colKor;
        private System.Windows.Forms.ColumnHeader colEng;
        private System.Windows.Forms.ColumnHeader colMath;
        private System.Windows.Forms.ColumnHeader colSoc;
        private System.Windows.Forms.ColumnHeader colSci;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}