namespace DrawingNotepad
{
    partial class Drawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drawing));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.newButton = new System.Windows.Forms.ToolBarButton();
            this.lineButton = new System.Windows.Forms.ToolBarButton();
            this.rectButton = new System.Windows.Forms.ToolBarButton();
            this.circleButton = new System.Windows.Forms.ToolBarButton();
            this.line0Button = new System.Windows.Forms.ToolBarButton();
            this.line1Button = new System.Windows.Forms.ToolBarButton();
            this.line2Button = new System.Windows.Forms.ToolBarButton();
            this.line3Button = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.newButton,
            this.lineButton,
            this.rectButton,
            this.circleButton,
            this.line0Button,
            this.line1Button,
            this.line2Button,
            this.line3Button});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(788, 28);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // newButton
            // 
            this.newButton.ImageIndex = 0;
            this.newButton.Name = "newButton";
            // 
            // lineButton
            // 
            this.lineButton.ImageIndex = 1;
            this.lineButton.Name = "lineButton";
            // 
            // rectButton
            // 
            this.rectButton.ImageIndex = 3;
            this.rectButton.Name = "rectButton";
            // 
            // circleButton
            // 
            this.circleButton.ImageIndex = 2;
            this.circleButton.Name = "circleButton";
            // 
            // line0Button
            // 
            this.line0Button.ImageIndex = 4;
            this.line0Button.Name = "line0Button";
            // 
            // line1Button
            // 
            this.line1Button.ImageIndex = 5;
            this.line1Button.Name = "line1Button";
            // 
            // line2Button
            // 
            this.line2Button.ImageIndex = 6;
            this.line2Button.Name = "line2Button";
            // 
            // line3Button
            // 
            this.line3Button.ImageIndex = 7;
            this.line3Button.Name = "line3Button";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "new document.png");
            this.imageList1.Images.SetKeyName(1, "line.png");
            this.imageList1.Images.SetKeyName(2, "circle.png");
            this.imageList1.Images.SetKeyName(3, "square.png");
            this.imageList1.Images.SetKeyName(4, "line-width.png");
            this.imageList1.Images.SetKeyName(5, "line_width_1.png");
            this.imageList1.Images.SetKeyName(6, "line_width_3.png");
            this.imageList1.Images.SetKeyName(7, "line_dashed.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 360);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Drawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 388);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "Drawing";
            this.Text = "Paint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton newButton;
        private System.Windows.Forms.ToolBarButton lineButton;
        private System.Windows.Forms.ToolBarButton rectButton;
        private System.Windows.Forms.ToolBarButton circleButton;
        private System.Windows.Forms.ToolBarButton line0Button;
        private System.Windows.Forms.ToolBarButton line1Button;
        private System.Windows.Forms.ToolBarButton line2Button;
        private System.Windows.Forms.ToolBarButton line3Button;
        private System.Windows.Forms.Panel panel1;
    }
}

