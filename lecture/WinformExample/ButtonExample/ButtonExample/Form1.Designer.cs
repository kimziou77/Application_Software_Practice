namespace ButtonExample
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
            this.TextNote = new System.Windows.Forms.TextBox();
            this.MessageBtn = new System.Windows.Forms.Button();
            this.SeletctBtn = new System.Windows.Forms.Button();
            this.GroupFonts = new System.Windows.Forms.GroupBox();
            this.RadioGung = new System.Windows.Forms.RadioButton();
            this.RadioGul = new System.Windows.Forms.RadioButton();
            this.RadioDot = new System.Windows.Forms.RadioButton();
            this.GroupStyle = new System.Windows.Forms.GroupBox();
            this.CheckItalic = new System.Windows.Forms.CheckBox();
            this.CheckLine = new System.Windows.Forms.CheckBox();
            this.CheckBold = new System.Windows.Forms.CheckBox();
            this.GroupFonts.SuspendLayout();
            this.GroupStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextNote
            // 
            this.TextNote.Location = new System.Drawing.Point(12, 12);
            this.TextNote.Multiline = true;
            this.TextNote.Name = "TextNote";
            this.TextNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextNote.Size = new System.Drawing.Size(294, 166);
            this.TextNote.TabIndex = 0;
            // 
            // MessageBtn
            // 
            this.MessageBtn.Location = new System.Drawing.Point(394, 30);
            this.MessageBtn.Name = "MessageBtn";
            this.MessageBtn.Size = new System.Drawing.Size(137, 49);
            this.MessageBtn.TabIndex = 1;
            this.MessageBtn.Text = "Message";
            this.MessageBtn.UseVisualStyleBackColor = true;
            this.MessageBtn.Click += new System.EventHandler(this.MessageBtn_Click);
            // 
            // SeletctBtn
            // 
            this.SeletctBtn.Location = new System.Drawing.Point(394, 105);
            this.SeletctBtn.Name = "SeletctBtn";
            this.SeletctBtn.Size = new System.Drawing.Size(137, 55);
            this.SeletctBtn.TabIndex = 2;
            this.SeletctBtn.Text = "Select";
            this.SeletctBtn.UseVisualStyleBackColor = true;
            this.SeletctBtn.Click += new System.EventHandler(this.SeletctBtn_Click);
            // 
            // GroupFonts
            // 
            this.GroupFonts.Controls.Add(this.RadioGung);
            this.GroupFonts.Controls.Add(this.RadioGul);
            this.GroupFonts.Controls.Add(this.RadioDot);
            this.GroupFonts.Location = new System.Drawing.Point(12, 212);
            this.GroupFonts.Name = "GroupFonts";
            this.GroupFonts.Size = new System.Drawing.Size(244, 241);
            this.GroupFonts.TabIndex = 3;
            this.GroupFonts.TabStop = false;
            this.GroupFonts.Text = "Fonts";
            // 
            // RadioGung
            // 
            this.RadioGung.AutoSize = true;
            this.RadioGung.Font = new System.Drawing.Font("궁서", 13.8F);
            this.RadioGung.Location = new System.Drawing.Point(76, 186);
            this.RadioGung.Name = "RadioGung";
            this.RadioGung.Size = new System.Drawing.Size(79, 28);
            this.RadioGung.TabIndex = 2;
            this.RadioGung.TabStop = true;
            this.RadioGung.Text = "궁서";
            this.RadioGung.UseVisualStyleBackColor = true;
            this.RadioGung.CheckedChanged += new System.EventHandler(this.RadioGung_CheckedChanged);
            // 
            // RadioGul
            // 
            this.RadioGul.AutoSize = true;
            this.RadioGul.Font = new System.Drawing.Font("굴림", 13.8F);
            this.RadioGul.Location = new System.Drawing.Point(76, 112);
            this.RadioGul.Name = "RadioGul";
            this.RadioGul.Size = new System.Drawing.Size(79, 28);
            this.RadioGul.TabIndex = 1;
            this.RadioGul.TabStop = true;
            this.RadioGul.Text = "굴림";
            this.RadioGul.UseVisualStyleBackColor = true;
            this.RadioGul.CheckedChanged += new System.EventHandler(this.RadioGul_CheckedChanged);
            // 
            // RadioDot
            // 
            this.RadioDot.AutoSize = true;
            this.RadioDot.Font = new System.Drawing.Font("돋움", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioDot.Location = new System.Drawing.Point(76, 38);
            this.RadioDot.Name = "RadioDot";
            this.RadioDot.Size = new System.Drawing.Size(79, 28);
            this.RadioDot.TabIndex = 0;
            this.RadioDot.TabStop = true;
            this.RadioDot.Text = "돋움";
            this.RadioDot.UseVisualStyleBackColor = true;
            this.RadioDot.CheckedChanged += new System.EventHandler(this.RadioDot_CheckedChanged);
            // 
            // GroupStyle
            // 
            this.GroupStyle.Controls.Add(this.CheckItalic);
            this.GroupStyle.Controls.Add(this.CheckLine);
            this.GroupStyle.Controls.Add(this.CheckBold);
            this.GroupStyle.Location = new System.Drawing.Point(306, 212);
            this.GroupStyle.Name = "GroupStyle";
            this.GroupStyle.Size = new System.Drawing.Size(258, 252);
            this.GroupStyle.TabIndex = 4;
            this.GroupStyle.TabStop = false;
            this.GroupStyle.Text = "Style";
            // 
            // CheckItalic
            // 
            this.CheckItalic.AutoSize = true;
            this.CheckItalic.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CheckItalic.Location = new System.Drawing.Point(88, 186);
            this.CheckItalic.Name = "CheckItalic";
            this.CheckItalic.Size = new System.Drawing.Size(86, 28);
            this.CheckItalic.TabIndex = 2;
            this.CheckItalic.Text = "Italic";
            this.CheckItalic.UseVisualStyleBackColor = true;
            this.CheckItalic.CheckedChanged += new System.EventHandler(this.CheckItalic_CheckedChanged);
            // 
            // CheckLine
            // 
            this.CheckLine.AutoSize = true;
            this.CheckLine.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CheckLine.Location = new System.Drawing.Point(65, 113);
            this.CheckLine.Name = "CheckLine";
            this.CheckLine.Size = new System.Drawing.Size(134, 28);
            this.CheckLine.TabIndex = 1;
            this.CheckLine.Text = "UnderLine";
            this.CheckLine.UseVisualStyleBackColor = true;
            this.CheckLine.CheckedChanged += new System.EventHandler(this.CheckLine_CheckedChanged);
            // 
            // CheckBold
            // 
            this.CheckBold.AutoSize = true;
            this.CheckBold.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CheckBold.Location = new System.Drawing.Point(88, 38);
            this.CheckBold.Name = "CheckBold";
            this.CheckBold.Size = new System.Drawing.Size(81, 28);
            this.CheckBold.TabIndex = 0;
            this.CheckBold.Text = "Bold";
            this.CheckBold.UseVisualStyleBackColor = true;
            this.CheckBold.CheckedChanged += new System.EventHandler(this.CheckBold_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 486);
            this.Controls.Add(this.GroupStyle);
            this.Controls.Add(this.GroupFonts);
            this.Controls.Add(this.SeletctBtn);
            this.Controls.Add(this.MessageBtn);
            this.Controls.Add(this.TextNote);
            this.Name = "Form1";
            this.Text = "KIMSUBIN";
            this.GroupFonts.ResumeLayout(false);
            this.GroupFonts.PerformLayout();
            this.GroupStyle.ResumeLayout(false);
            this.GroupStyle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button MessageBtn;
        private System.Windows.Forms.Button SeletctBtn;
        private System.Windows.Forms.GroupBox GroupFonts;
        private System.Windows.Forms.GroupBox GroupStyle;
        private System.Windows.Forms.RadioButton RadioGung;
        private System.Windows.Forms.RadioButton RadioGul;
        private System.Windows.Forms.RadioButton RadioDot;
        private System.Windows.Forms.CheckBox CheckItalic;
        private System.Windows.Forms.CheckBox CheckLine;
        private System.Windows.Forms.CheckBox CheckBold;
        private System.Windows.Forms.TextBox TextNote;
    }
}

