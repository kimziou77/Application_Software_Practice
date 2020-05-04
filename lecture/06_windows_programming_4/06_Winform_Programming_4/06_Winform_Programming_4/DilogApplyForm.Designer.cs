namespace _06_Winform_Programming_4
{
    partial class DilogApplyForm
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
            this.btnModaless = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModaless
            // 
            this.btnModaless.Location = new System.Drawing.Point(29, 12);
            this.btnModaless.Name = "btnModaless";
            this.btnModaless.Size = new System.Drawing.Size(324, 82);
            this.btnModaless.TabIndex = 0;
            this.btnModaless.Text = "모달리스창 띄우기";
            this.btnModaless.UseVisualStyleBackColor = true;
            this.btnModaless.Click += new System.EventHandler(this.btnModaless_Click);
            // 
            // DilogApplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 115);
            this.Controls.Add(this.btnModaless);
            this.Name = "DilogApplyForm";
            this.Text = "DilogApplyForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModaless;
    }
}