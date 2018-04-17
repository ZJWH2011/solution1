namespace EMANFTPFile
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ftpprogressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.ftplabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timelabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.filename = new System.Windows.Forms.TextBox();
            this.dirpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timeSelector1 = new DevComponents.Editors.DateTimeAdv.TimeSelector();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ftpprogressbar,
            this.ftplabel,
            this.timelabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 330);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(799, 36);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ftpprogressbar
            // 
            this.ftpprogressbar.Name = "ftpprogressbar";
            this.ftpprogressbar.Size = new System.Drawing.Size(400, 30);
            // 
            // ftplabel
            // 
            this.ftplabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ftplabel.Name = "ftplabel";
            this.ftplabel.Size = new System.Drawing.Size(0, 31);
            // 
            // timelabel
            // 
            this.timelabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timelabel.Name = "timelabel";
            this.timelabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timelabel.Size = new System.Drawing.Size(382, 31);
            this.timelabel.Spring = true;
            this.timelabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // filename
            // 
            this.filename.Location = new System.Drawing.Point(203, 78);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(359, 21);
            this.filename.TabIndex = 1;
            // 
            // dirpath
            // 
            this.dirpath.Location = new System.Drawing.Point(203, 33);
            this.dirpath.Name = "dirpath";
            this.dirpath.Size = new System.Drawing.Size(359, 21);
            this.dirpath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件夹绝对路径(如 D:\\kdbackup)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "账套名前缀(如 SHJY2018)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 66);
            this.button1.TabIndex = 4;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "备份时间";
            // 
            // timeSelector1
            // 
            this.timeSelector1.AutoSize = true;
            // 
            // 
            // 
            this.timeSelector1.BackgroundStyle.Class = "ItemPanel";
            this.timeSelector1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.timeSelector1.ContainerControlProcessDialogKey = true;
            this.timeSelector1.Location = new System.Drawing.Point(203, 129);
            this.timeSelector1.Name = "timeSelector1";
            this.timeSelector1.Size = new System.Drawing.Size(252, 191);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 366);
            this.Controls.Add(this.timeSelector1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirpath);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP文件服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel timelabel;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.TextBox dirpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripProgressBar ftpprogressbar;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.DateTimeAdv.TimeSelector timeSelector1;
        private System.Windows.Forms.ToolStripStatusLabel ftplabel;
    }
}

