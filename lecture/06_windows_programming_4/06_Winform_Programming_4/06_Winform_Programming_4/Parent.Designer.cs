namespace _06_Winform_Programming_4
{
    partial class Parent
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.openFDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFDlg = new System.Windows.Forms.SaveFileDialog();
            this.fontDlg = new System.Windows.Forms.FontDialog();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.실행취소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.오려내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.복사하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.붙여넣기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.지우기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.보기VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자동줄바꿈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.글꼴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.글자색바꾸기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.바탕색바꾸기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.바둑판배열세로ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.바둑판배열가로ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.계단식배열ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.편집EToolStripMenuItem,
            this.보기VToolStripMenuItem,
            this.ToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(702, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // openFDlg
            // 
            this.openFDlg.FileName = "openFileDialog1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새파일ToolStripMenuItem,
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.다른이름으로저장ToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 새파일ToolStripMenuItem
            // 
            this.새파일ToolStripMenuItem.Name = "새파일ToolStripMenuItem";
            this.새파일ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.새파일ToolStripMenuItem.Text = "새 파일";
            this.새파일ToolStripMenuItem.Click += new System.EventHandler(this.새파일ToolStripMenuItem_Click);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 다른이름으로저장ToolStripMenuItem
            // 
            this.다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
            this.다른이름으로저장ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.다른이름으로저장ToolStripMenuItem.Text = "다른 이름으로 저장";
            this.다른이름으로저장ToolStripMenuItem.Click += new System.EventHandler(this.다른이름으로저장ToolStripMenuItem_Click);
            // 
            // 편집EToolStripMenuItem
            // 
            this.편집EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.실행취소ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.오려내기ToolStripMenuItem,
            this.복사하기ToolStripMenuItem,
            this.붙여넣기ToolStripMenuItem,
            this.지우기ToolStripMenuItem});
            this.편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            this.편집EToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.편집EToolStripMenuItem.Text = "편집(&E)";
            // 
            // 실행취소ToolStripMenuItem
            // 
            this.실행취소ToolStripMenuItem.Name = "실행취소ToolStripMenuItem";
            this.실행취소ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.실행취소ToolStripMenuItem.Text = "실행취소";
            this.실행취소ToolStripMenuItem.Click += new System.EventHandler(this.실행취소ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // 오려내기ToolStripMenuItem
            // 
            this.오려내기ToolStripMenuItem.Name = "오려내기ToolStripMenuItem";
            this.오려내기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.오려내기ToolStripMenuItem.Text = "오려내기";
            this.오려내기ToolStripMenuItem.Click += new System.EventHandler(this.오려내기ToolStripMenuItem_Click);
            // 
            // 복사하기ToolStripMenuItem
            // 
            this.복사하기ToolStripMenuItem.Name = "복사하기ToolStripMenuItem";
            this.복사하기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.복사하기ToolStripMenuItem.Text = "복사하기";
            this.복사하기ToolStripMenuItem.Click += new System.EventHandler(this.복사하기ToolStripMenuItem_Click);
            // 
            // 붙여넣기ToolStripMenuItem
            // 
            this.붙여넣기ToolStripMenuItem.Name = "붙여넣기ToolStripMenuItem";
            this.붙여넣기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.붙여넣기ToolStripMenuItem.Text = "붙여넣기";
            this.붙여넣기ToolStripMenuItem.Click += new System.EventHandler(this.붙여넣기ToolStripMenuItem_Click);
            // 
            // 지우기ToolStripMenuItem
            // 
            this.지우기ToolStripMenuItem.Name = "지우기ToolStripMenuItem";
            this.지우기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.지우기ToolStripMenuItem.Text = "지우기";
            this.지우기ToolStripMenuItem.Click += new System.EventHandler(this.지우기ToolStripMenuItem_Click);
            // 
            // 보기VToolStripMenuItem
            // 
            this.보기VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.자동줄바꿈ToolStripMenuItem,
            this.글꼴ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.글자색바꾸기ToolStripMenuItem,
            this.바탕색바꾸기ToolStripMenuItem});
            this.보기VToolStripMenuItem.Name = "보기VToolStripMenuItem";
            this.보기VToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.보기VToolStripMenuItem.Text = "보기(&V)";
            // 
            // 자동줄바꿈ToolStripMenuItem
            // 
            this.자동줄바꿈ToolStripMenuItem.Name = "자동줄바꿈ToolStripMenuItem";
            this.자동줄바꿈ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.자동줄바꿈ToolStripMenuItem.Text = "자동 줄 바꿈";
            this.자동줄바꿈ToolStripMenuItem.Click += new System.EventHandler(this.자동줄바꿈ToolStripMenuItem_Click);
            // 
            // 글꼴ToolStripMenuItem
            // 
            this.글꼴ToolStripMenuItem.Name = "글꼴ToolStripMenuItem";
            this.글꼴ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.글꼴ToolStripMenuItem.Text = "글꼴";
            this.글꼴ToolStripMenuItem.Click += new System.EventHandler(this.글꼴ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // 글자색바꾸기ToolStripMenuItem
            // 
            this.글자색바꾸기ToolStripMenuItem.Name = "글자색바꾸기ToolStripMenuItem";
            this.글자색바꾸기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.글자색바꾸기ToolStripMenuItem.Text = "글자색 바꾸기";
            this.글자색바꾸기ToolStripMenuItem.Click += new System.EventHandler(this.글자색바꾸기ToolStripMenuItem_Click);
            // 
            // 바탕색바꾸기ToolStripMenuItem
            // 
            this.바탕색바꾸기ToolStripMenuItem.Name = "바탕색바꾸기ToolStripMenuItem";
            this.바탕색바꾸기ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.바탕색바꾸기ToolStripMenuItem.Text = "바탕색 바꾸기";
            this.바탕색바꾸기ToolStripMenuItem.Click += new System.EventHandler(this.바탕색바꾸기ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.바둑판배열세로ToolStripMenuItem,
            this.바둑판배열가로ToolStripMenuItem,
            this.계단식배열ToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.ToolStripMenuItem.Text = "창(&W)";
            // 
            // 바둑판배열세로ToolStripMenuItem
            // 
            this.바둑판배열세로ToolStripMenuItem.Name = "바둑판배열세로ToolStripMenuItem";
            this.바둑판배열세로ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.바둑판배열세로ToolStripMenuItem.Text = "바둑판 배열(세로)";
            this.바둑판배열세로ToolStripMenuItem.Click += new System.EventHandler(this.바둑판배열세로ToolStripMenuItem_Click);
            // 
            // 바둑판배열가로ToolStripMenuItem
            // 
            this.바둑판배열가로ToolStripMenuItem.Name = "바둑판배열가로ToolStripMenuItem";
            this.바둑판배열가로ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.바둑판배열가로ToolStripMenuItem.Text = "바둑판 배열(가로)";
            this.바둑판배열가로ToolStripMenuItem.Click += new System.EventHandler(this.바둑판배열가로ToolStripMenuItem_Click);
            // 
            // 계단식배열ToolStripMenuItem
            // 
            this.계단식배열ToolStripMenuItem.Name = "계단식배열ToolStripMenuItem";
            this.계단식배열ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.계단식배열ToolStripMenuItem.Text = "계단식 배열";
            this.계단식배열ToolStripMenuItem.Click += new System.EventHandler(this.계단식배열ToolStripMenuItem_Click);
            // 
            // Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 433);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Parent";
            this.Text = "Parent";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.OpenFileDialog openFDlg;
        private System.Windows.Forms.SaveFileDialog saveFDlg;
        private System.Windows.Forms.FontDialog fontDlg;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 실행취소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 오려내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 복사하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 붙여넣기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 지우기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 보기VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 자동줄바꿈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 글꼴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 글자색바꾸기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 바탕색바꾸기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 바둑판배열세로ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 바둑판배열가로ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 계단식배열ToolStripMenuItem;
    }
}

