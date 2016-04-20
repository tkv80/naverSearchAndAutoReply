namespace NaverSearch
{
    partial class Main
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.cbOntime = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(1, 357);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(642, 245);
            this.webBrowser1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbOntime);
            this.groupBox1.Controls.Add(this.numDelay);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtLog);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 347);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상품 찾기";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLog.Location = new System.Drawing.Point(13, 43);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(613, 295);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(314, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(13, 18);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(249, 21);
            this.txtComment.TabIndex = 5;
            this.txtComment.Text = "저요";
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(268, 17);
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(40, 21);
            this.numDelay.TabIndex = 6;
            this.numDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbOntime
            // 
            this.cbOntime.AutoSize = true;
            this.cbOntime.Location = new System.Drawing.Point(396, 22);
            this.cbOntime.Name = "cbOntime";
            this.cbOntime.Size = new System.Drawing.Size(60, 16);
            this.cbOntime.TabIndex = 7;
            this.cbOntime.Text = "한번만";
            this.cbOntime.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 602);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Main";
            this.Text = "네이버";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.CheckBox cbOntime;
    }
}

