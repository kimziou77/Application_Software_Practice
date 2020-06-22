namespace Client
{
    partial class world_Client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(world_Client));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolHand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPencil = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRect = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.line1 = new System.Windows.Forms.ToolStripMenuItem();
            this.line2 = new System.Windows.Forms.ToolStripMenuItem();
            this.line3 = new System.Windows.Forms.ToolStripMenuItem();
            this.line4 = new System.Windows.Forms.ToolStripMenuItem();
            this.line5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFill = new System.Windows.Forms.ToolStripButton();
            this.btnColor1 = new System.Windows.Forms.ToolStripButton();
            this.btnColor2 = new System.Windows.Forms.ToolStripButton();
            this.chatBoard = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.chatting = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cld = new System.Windows.Forms.ColorDialog();
            this.drawingBoard = new Client.DoubleBufferPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelect,
            this.lineSelect,
            this.btnFill,
            this.btnColor1,
            this.btnColor2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(615, 47);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSelect
            // 
            this.toolSelect.BackColor = System.Drawing.Color.White;
            this.toolSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolHand,
            this.toolPencil,
            this.toolLine,
            this.toolCircle,
            this.toolRect});
            this.toolSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolSelect.Image")));
            this.toolSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Size = new System.Drawing.Size(54, 44);
            this.toolSelect.Text = "toolStripDropDownButton1";
            // 
            // toolHand
            // 
            this.toolHand.Image = global::Client.Properties.Resources.hand;
            this.toolHand.Name = "toolHand";
            this.toolHand.Size = new System.Drawing.Size(133, 26);
            this.toolHand.Text = "Hand";
            this.toolHand.Click += new System.EventHandler(this.tools_Click);
            // 
            // toolPencil
            // 
            this.toolPencil.Image = global::Client.Properties.Resources.pencil;
            this.toolPencil.Name = "toolPencil";
            this.toolPencil.Size = new System.Drawing.Size(133, 26);
            this.toolPencil.Text = "Pencil";
            this.toolPencil.Click += new System.EventHandler(this.tools_Click);
            // 
            // toolLine
            // 
            this.toolLine.Image = global::Client.Properties.Resources.line;
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(133, 26);
            this.toolLine.Text = "Line";
            this.toolLine.Click += new System.EventHandler(this.tools_Click);
            // 
            // toolCircle
            // 
            this.toolCircle.Image = global::Client.Properties.Resources.ellipse;
            this.toolCircle.Name = "toolCircle";
            this.toolCircle.Size = new System.Drawing.Size(133, 26);
            this.toolCircle.Text = "Circle";
            this.toolCircle.Click += new System.EventHandler(this.tools_Click);
            // 
            // toolRect
            // 
            this.toolRect.Image = global::Client.Properties.Resources.rectangle;
            this.toolRect.Name = "toolRect";
            this.toolRect.Size = new System.Drawing.Size(133, 26);
            this.toolRect.Text = "Rect";
            this.toolRect.Click += new System.EventHandler(this.tools_Click);
            // 
            // lineSelect
            // 
            this.lineSelect.BackColor = System.Drawing.Color.White;
            this.lineSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.line1,
            this.line2,
            this.line3,
            this.line4,
            this.line5});
            this.lineSelect.Image = ((System.Drawing.Image)(resources.GetObject("lineSelect.Image")));
            this.lineSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineSelect.Name = "lineSelect";
            this.lineSelect.Size = new System.Drawing.Size(54, 44);
            this.lineSelect.Text = "toolStripDropDownButton2";
            // 
            // line1
            // 
            this.line1.Image = global::Client.Properties.Resources.line1Button;
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(100, 26);
            this.line1.Text = "1";
            this.line1.Click += new System.EventHandler(this.lines_Click);
            // 
            // line2
            // 
            this.line2.Image = global::Client.Properties.Resources.line2Button;
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(100, 26);
            this.line2.Text = "2";
            this.line2.Click += new System.EventHandler(this.lines_Click);
            // 
            // line3
            // 
            this.line3.Image = global::Client.Properties.Resources.line3Button;
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(100, 26);
            this.line3.Text = "3";
            this.line3.Click += new System.EventHandler(this.lines_Click);
            // 
            // line4
            // 
            this.line4.Image = global::Client.Properties.Resources.line4Button;
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(100, 26);
            this.line4.Text = "4";
            this.line4.Click += new System.EventHandler(this.lines_Click);
            // 
            // line5
            // 
            this.line5.Image = global::Client.Properties.Resources.line5Button;
            this.line5.Name = "line5";
            this.line5.Size = new System.Drawing.Size(100, 26);
            this.line5.Text = "5";
            this.line5.Click += new System.EventHandler(this.lines_Click);
            // 
            // btnFill
            // 
            this.btnFill.BackColor = System.Drawing.Color.White;
            this.btnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(58, 44);
            this.btnFill.Text = "채우기";
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnColor1
            // 
            this.btnColor1.BackColor = System.Drawing.Color.White;
            this.btnColor1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColor1.Image = ((System.Drawing.Image)(resources.GetObject("btnColor1.Image")));
            this.btnColor1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(44, 44);
            this.btnColor1.Text = "toolStripButton2";
            this.btnColor1.Click += new System.EventHandler(this.btnColor1_Click);
            // 
            // btnColor2
            // 
            this.btnColor2.BackColor = System.Drawing.Color.Black;
            this.btnColor2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColor2.Image = ((System.Drawing.Image)(resources.GetObject("btnColor2.Image")));
            this.btnColor2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(44, 44);
            this.btnColor2.Text = "toolStripButton3";
            this.btnColor2.Click += new System.EventHandler(this.btnColor2_Click);
            // 
            // chatBoard
            // 
            this.chatBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatBoard.Location = new System.Drawing.Point(0, 290);
            this.chatBoard.Multiline = true;
            this.chatBoard.Name = "chatBoard";
            this.chatBoard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBoard.Size = new System.Drawing.Size(615, 105);
            this.chatBoard.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Location = new System.Drawing.Point(502, 395);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(113, 34);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "say";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // chatting
            // 
            this.chatting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatting.Location = new System.Drawing.Point(0, 395);
            this.chatting.Multiline = true;
            this.chatting.Name = "chatting";
            this.chatting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatting.Size = new System.Drawing.Size(502, 34);
            this.chatting.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 395);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 34);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pencil.jpg");
            this.imageList1.Images.SetKeyName(1, "ellipse.jpg");
            this.imageList1.Images.SetKeyName(2, "ellipseColored.jpg");
            this.imageList1.Images.SetKeyName(3, "hand.png");
            this.imageList1.Images.SetKeyName(4, "line.jpg");
            this.imageList1.Images.SetKeyName(5, "line1Button.JPG");
            this.imageList1.Images.SetKeyName(6, "line2Button.JPG");
            this.imageList1.Images.SetKeyName(7, "line3Button.JPG");
            this.imageList1.Images.SetKeyName(8, "line4Button.JPG");
            this.imageList1.Images.SetKeyName(9, "line5Button.JPG");
            this.imageList1.Images.SetKeyName(10, "rectangle.jpg");
            this.imageList1.Images.SetKeyName(11, "rectangleColored.jpg");
            // 
            // drawingBoard
            // 
            this.drawingBoard.BackColor = System.Drawing.Color.White;
            this.drawingBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.drawingBoard.Location = new System.Drawing.Point(0, 47);
            this.drawingBoard.Name = "drawingBoard";
            this.drawingBoard.Size = new System.Drawing.Size(615, 243);
            this.drawingBoard.TabIndex = 1;
            this.drawingBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingBoard_Paint);
            this.drawingBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingBoard_MouseDown);
            this.drawingBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingBoard_MouseMove);
            this.drawingBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingBoard_MouseUp);
            // 
            // world_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 429);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.chatting);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chatBoard);
            this.Controls.Add(this.drawingBoard);
            this.Controls.Add(this.toolStrip1);
            this.Name = "world_Client";
            this.Text = "세계그림판";
            this.Load += new System.EventHandler(this.world_Client_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Client.DoubleBufferPanel drawingBoard;
        private System.Windows.Forms.TextBox chatBoard;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox chatting;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripDropDownButton toolSelect;
        private System.Windows.Forms.ToolStripDropDownButton lineSelect;
        private System.Windows.Forms.ToolStripButton btnFill;
        private System.Windows.Forms.ToolStripButton btnColor1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColorDialog cld;
        private System.Windows.Forms.ToolStripMenuItem toolHand;
        private System.Windows.Forms.ToolStripMenuItem toolPencil;
        private System.Windows.Forms.ToolStripMenuItem toolLine;
        private System.Windows.Forms.ToolStripMenuItem toolCircle;
        private System.Windows.Forms.ToolStripMenuItem toolRect;
        private System.Windows.Forms.ToolStripMenuItem line1;
        private System.Windows.Forms.ToolStripMenuItem line2;
        private System.Windows.Forms.ToolStripMenuItem line3;
        private System.Windows.Forms.ToolStripMenuItem line4;
        private System.Windows.Forms.ToolStripMenuItem line5;
        private System.Windows.Forms.ToolStripButton btnColor2;
    }
}