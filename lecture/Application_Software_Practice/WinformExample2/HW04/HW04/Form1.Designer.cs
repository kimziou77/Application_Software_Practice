namespace HW04
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.rdoStretchImage = new System.Windows.Forms.RadioButton();
            this.rdoAutoSize = new System.Windows.Forms.RadioButton();
            this.rdoCenterImage = new System.Windows.Forms.RadioButton();
            this.rdoZoom = new System.Windows.Forms.RadioButton();
            this.btnChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picProfile
            // 
            this.picProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picProfile.Image = ((System.Drawing.Image)(resources.GetObject("picProfile.Image")));
            this.picProfile.Location = new System.Drawing.Point(-49, -110);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(283, 354);
            this.picProfile.TabIndex = 0;
            this.picProfile.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(240, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 232);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "프로필관리";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoZoom);
            this.groupBox2.Controls.Add(this.rdoCenterImage);
            this.groupBox2.Controls.Add(this.rdoAutoSize);
            this.groupBox2.Controls.Add(this.rdoStretchImage);
            this.groupBox2.Controls.Add(this.rdoNormal);
            this.groupBox2.Controls.Add(this.chkVisible);
            this.groupBox2.Location = new System.Drawing.Point(6, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "옵션";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChange);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtUrl);
            this.groupBox3.Location = new System.Drawing.Point(6, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(582, 81);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "사진변경";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(69, 24);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(507, 25);
            this.txtUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(9, 74);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(74, 19);
            this.chkVisible.TabIndex = 4;
            this.chkVisible.Text = "숨기기";
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.chkVisible_CheckedChanged);
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Location = new System.Drawing.Point(9, 24);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(72, 19);
            this.rdoNormal.TabIndex = 5;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "Normal";
            this.rdoNormal.UseVisualStyleBackColor = true;
            this.rdoNormal.CheckedChanged += new System.EventHandler(this.rdoOption_CheckedChanged);
            // 
            // rdoStretchImage
            // 
            this.rdoStretchImage.AutoSize = true;
            this.rdoStretchImage.Location = new System.Drawing.Point(101, 24);
            this.rdoStretchImage.Name = "rdoStretchImage";
            this.rdoStretchImage.Size = new System.Drawing.Size(112, 19);
            this.rdoStretchImage.TabIndex = 6;
            this.rdoStretchImage.TabStop = true;
            this.rdoStretchImage.Text = "StretchImage";
            this.rdoStretchImage.UseVisualStyleBackColor = true;
            this.rdoStretchImage.CheckedChanged += new System.EventHandler(this.rdoOption_CheckedChanged);
            // 
            // rdoAutoSize
            // 
            this.rdoAutoSize.AutoSize = true;
            this.rdoAutoSize.Location = new System.Drawing.Point(235, 24);
            this.rdoAutoSize.Name = "rdoAutoSize";
            this.rdoAutoSize.Size = new System.Drawing.Size(87, 19);
            this.rdoAutoSize.TabIndex = 7;
            this.rdoAutoSize.TabStop = true;
            this.rdoAutoSize.Text = "AutoSize";
            this.rdoAutoSize.UseVisualStyleBackColor = true;
            this.rdoAutoSize.CheckedChanged += new System.EventHandler(this.rdoOption_CheckedChanged);
            // 
            // rdoCenterImage
            // 
            this.rdoCenterImage.AutoSize = true;
            this.rdoCenterImage.Location = new System.Drawing.Point(347, 24);
            this.rdoCenterImage.Name = "rdoCenterImage";
            this.rdoCenterImage.Size = new System.Drawing.Size(108, 19);
            this.rdoCenterImage.TabIndex = 8;
            this.rdoCenterImage.TabStop = true;
            this.rdoCenterImage.Text = "CenterImage";
            this.rdoCenterImage.UseVisualStyleBackColor = true;
            this.rdoCenterImage.CheckedChanged += new System.EventHandler(this.rdoOption_CheckedChanged);
            // 
            // rdoZoom
            // 
            this.rdoZoom.AutoSize = true;
            this.rdoZoom.Location = new System.Drawing.Point(477, 24);
            this.rdoZoom.Name = "rdoZoom";
            this.rdoZoom.Size = new System.Drawing.Size(66, 19);
            this.rdoZoom.TabIndex = 9;
            this.rdoZoom.TabStop = true;
            this.rdoZoom.Text = "Zoom";
            this.rdoZoom.UseVisualStyleBackColor = true;
            this.rdoZoom.CheckedChanged += new System.EventHandler(this.rdoOption_CheckedChanged);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(501, 55);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 250);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picProfile);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoZoom;
        private System.Windows.Forms.RadioButton rdoCenterImage;
        private System.Windows.Forms.RadioButton rdoAutoSize;
        private System.Windows.Forms.RadioButton rdoStretchImage;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
    }
}

