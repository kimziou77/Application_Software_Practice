﻿namespace Test1
{
    partial class Default
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Default));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.ESC_timer = new System.Windows.Forms.Timer(this.components);
            this.EscTimeDisplay = new System.Windows.Forms.Label();
            this.ActionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TDB_notify_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DirChangeBtn = new System.Windows.Forms.Button();
            this.consoleeee = new System.Windows.Forms.TextBox();
            this.NameChangeBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ActionMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 197);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.SystemColors.HotTrack;
            this.name.Cursor = System.Windows.Forms.Cursors.Default;
            this.name.Font = new System.Drawing.Font("-윤고딕310", 10F);
            this.name.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.name.Location = new System.Drawing.Point(21, 26);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(57, 19);
            this.name.TabIndex = 1;
            this.name.Text = "KIMYO";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button.Font = new System.Drawing.Font("굴림", 10F);
            this.button.Location = new System.Drawing.Point(171, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(33, 33);
            this.button.TabIndex = 2;
            this.button.Text = "N";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button1_Click);
            // 
            // ESC_timer
            // 
            this.ESC_timer.Tick += new System.EventHandler(this.ESC_timer_Tick);
            // 
            // EscTimeDisplay
            // 
            this.EscTimeDisplay.AutoSize = true;
            this.EscTimeDisplay.BackColor = System.Drawing.SystemColors.HotTrack;
            this.EscTimeDisplay.Font = new System.Drawing.Font("굴림", 14F);
            this.EscTimeDisplay.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.EscTimeDisplay.Location = new System.Drawing.Point(108, 64);
            this.EscTimeDisplay.Name = "EscTimeDisplay";
            this.EscTimeDisplay.Size = new System.Drawing.Size(23, 24);
            this.EscTimeDisplay.TabIndex = 3;
            this.EscTimeDisplay.Text = "0";
            this.EscTimeDisplay.TextChanged += new System.EventHandler(this.EscTimeDisplay_TextChanged);
            // 
            // ActionMenu
            // 
            this.ActionMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ActionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu1,
            this.menu2});
            this.ActionMenu.Name = "contextMenuStrip1";
            this.ActionMenu.Size = new System.Drawing.Size(164, 52);
            // 
            // menu1
            // 
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(210, 24);
            this.menu1.Text = "Kill NotePad";
            this.menu1.Click += new System.EventHandler(this.menu1_Click);
            // 
            // menu2
            // 
            this.menu2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu3});
            this.menu2.Name = "menu2";
            this.menu2.Size = new System.Drawing.Size(210, 24);
            this.menu2.Text = "M2";
            // 
            // menu3
            // 
            this.menu3.Name = "menu3";
            this.menu3.Size = new System.Drawing.Size(114, 26);
            this.menu3.Text = "M3";
            this.menu3.Click += new System.EventHandler(this.menu3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.ContextMenuStrip = this.ActionMenu;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 111);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            // 
            // TDB_notify_icon
            // 
            this.TDB_notify_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("TDB_notify_icon.Icon")));
            this.TDB_notify_icon.Text = "TDB";
            this.TDB_notify_icon.Visible = true;
            this.TDB_notify_icon.DoubleClick += new System.EventHandler(this.TDB_notify_icon_DoubleClick);
            // 
            // MoveTimer
            // 
            this.MoveTimer.Tick += new System.EventHandler(this.MoveTimer_Tick);
            // 
            // DirChangeBtn
            // 
            this.DirChangeBtn.Location = new System.Drawing.Point(90, 0);
            this.DirChangeBtn.Name = "DirChangeBtn";
            this.DirChangeBtn.Size = new System.Drawing.Size(75, 23);
            this.DirChangeBtn.TabIndex = 7;
            this.DirChangeBtn.Text = "Dir";
            this.DirChangeBtn.UseVisualStyleBackColor = true;
            this.DirChangeBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // consoleeee
            // 
            this.consoleeee.Font = new System.Drawing.Font("굴림", 8F);
            this.consoleeee.Location = new System.Drawing.Point(108, 46);
            this.consoleeee.Multiline = true;
            this.consoleeee.Name = "consoleeee";
            this.consoleeee.Size = new System.Drawing.Size(96, 72);
            this.consoleeee.TabIndex = 8;
            // 
            // NameChangeBtn
            // 
            this.NameChangeBtn.Location = new System.Drawing.Point(117, 134);
            this.NameChangeBtn.Name = "NameChangeBtn";
            this.NameChangeBtn.Size = new System.Drawing.Size(75, 23);
            this.NameChangeBtn.TabIndex = 9;
            this.NameChangeBtn.Text = "Change";
            this.NameChangeBtn.UseVisualStyleBackColor = true;
            this.NameChangeBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Font = new System.Drawing.Font("굴림", 7F);
            this.stopBtn.Location = new System.Drawing.Point(12, 0);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(66, 23);
            this.stopBtn.TabIndex = 10;
            this.stopBtn.Text = "STOP!!";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // Default
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(204, 197);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.NameChangeBtn);
            this.Controls.Add(this.consoleeee);
            this.Controls.Add(this.DirChangeBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.EscTimeDisplay);
            this.Controls.Add(this.button);
            this.Controls.Add(this.name);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Default";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "GooseTest";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.HotTrack;
            this.Load += new System.EventHandler(this.Default_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoticeForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Default_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Default_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.Resize += new System.EventHandler(this.Default_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ActionMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Timer ESC_timer;
        private System.Windows.Forms.Label EscTimeDisplay;
        private System.Windows.Forms.ContextMenuStrip ActionMenu;
        private System.Windows.Forms.ToolStripMenuItem menu1;
        private System.Windows.Forms.ToolStripMenuItem menu2;
        private System.Windows.Forms.ToolStripMenuItem menu3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NotifyIcon TDB_notify_icon;
        private System.Windows.Forms.Timer MoveTimer;
        private System.Windows.Forms.Button DirChangeBtn;
        private System.Windows.Forms.TextBox consoleeee;
        private System.Windows.Forms.Button NameChangeBtn;
        private System.Windows.Forms.Button stopBtn;
    }
}

