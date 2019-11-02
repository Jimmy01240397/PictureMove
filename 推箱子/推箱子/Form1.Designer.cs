namespace 推箱子
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureMove1 = new PictureMove.PictureMove();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMove1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(907, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "分數：";
            // 
            // pictureMove1
            // 
            this.pictureMove1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureMove1.form = this;
            this.pictureMove1.Image = global::推箱子.Properties.Resources._1;
            this.pictureMove1.Interval = 10;
            this.pictureMove1.List = null;
            this.pictureMove1.Location = new System.Drawing.Point(1, 1);
            this.pictureMove1.Name = "pictureMove1";
            this.pictureMove1.Rotate = 0;
            this.pictureMove1.Size = new System.Drawing.Size(40, 40);
            this.pictureMove1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMove1.TabIndex = 0;
            this.pictureMove1.TabStop = false;
            this.pictureMove1.TurnOrNot = false;
            this.pictureMove1.Touch += new PictureMove.PictureMove.OnTouch(this.pictureMove1_Touch);
            this.pictureMove1.Tick += new PictureMove.PictureMove.OnTick(this.pictureMove1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureMove1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMove1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureMove.PictureMove pictureMove1;
        private System.Windows.Forms.Label label1;
    }
}

