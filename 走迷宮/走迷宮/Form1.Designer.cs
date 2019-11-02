namespace 走迷宮
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
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureMove1 = new PictureMove.PictureMove();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMove1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureMove1
            // 
            this.pictureMove1.form = this;
            this.pictureMove1.Image = ((System.Drawing.Image)(resources.GetObject("pictureMove1.Image")));
            this.pictureMove1.Interval = 10;
            this.pictureMove1.List = null;
            this.pictureMove1.Location = new System.Drawing.Point(1, 1);
            this.pictureMove1.Name = "pictureMove1";
            this.pictureMove1.Rotate = 0;
            this.pictureMove1.Size = new System.Drawing.Size(25, 25);
            this.pictureMove1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMove1.TabIndex = 2;
            this.pictureMove1.TabStop = false;
            this.pictureMove1.TurnOrNot = false;
            this.pictureMove1.Touch += new PictureMove.PictureMove.OnTouch(this.pictureMove1_Touch);
            this.pictureMove1.Tick += new PictureMove.PictureMove.OnTick(this.pictureMove1_Tick);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(566, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 19);
            this.label9.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(598, 405);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureMove1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMove1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureMove.PictureMove pictureMove1;
        private System.Windows.Forms.Label label9;
    }
}

