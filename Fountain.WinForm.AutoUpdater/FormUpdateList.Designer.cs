namespace Fountain.WinForm.AutoUpdater
{
    partial class FormUpdateList
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSpace = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonDownload = new System.Windows.Forms.Button();
            this.ButtonFinish = new System.Windows.Forms.Button();
            this.ListViewFiles = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpdateFileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Progressbar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProgressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.LabelNext = new System.Windows.Forms.Label();
            this.PanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelButtons
            // 
            this.PanelButtons.BackColor = System.Drawing.Color.LightGray;
            this.PanelButtons.Controls.Add(this.lblSpace);
            this.PanelButtons.Controls.Add(this.ButtonCancel);
            this.PanelButtons.Controls.Add(this.ButtonUpdate);
            this.PanelButtons.Controls.Add(this.ButtonDownload);
            this.PanelButtons.Controls.Add(this.ButtonFinish);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.PanelButtons.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PanelButtons.Location = new System.Drawing.Point(0, 441);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(594, 30);
            this.PanelButtons.TabIndex = 9;
            // 
            // lblSpace
            // 
            this.lblSpace.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSpace.Location = new System.Drawing.Point(585, 0);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(6, 27);
            this.lblSpace.TabIndex = 3;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(506, 3);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 8;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(429, 3);
            this.ButtonUpdate.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(75, 23);
            this.ButtonUpdate.TabIndex = 7;
            this.ButtonUpdate.Text = "更新";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // ButtonDownload
            // 
            this.ButtonDownload.Location = new System.Drawing.Point(352, 3);
            this.ButtonDownload.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.ButtonDownload.Name = "ButtonDownload";
            this.ButtonDownload.Size = new System.Drawing.Size(75, 23);
            this.ButtonDownload.TabIndex = 6;
            this.ButtonDownload.Text = "下载";
            this.ButtonDownload.UseVisualStyleBackColor = true;
            this.ButtonDownload.Click += new System.EventHandler(this.ButtonDownload_Click);
            // 
            // ButtonFinish
            // 
            this.ButtonFinish.Location = new System.Drawing.Point(275, 3);
            this.ButtonFinish.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.ButtonFinish.Name = "ButtonFinish";
            this.ButtonFinish.Size = new System.Drawing.Size(75, 23);
            this.ButtonFinish.TabIndex = 5;
            this.ButtonFinish.Text = "完成";
            this.ButtonFinish.UseVisualStyleBackColor = true;
            this.ButtonFinish.Visible = false;
            this.ButtonFinish.Click += new System.EventHandler(this.ButtonFinish_Click);
            // 
            // ListViewFiles
            // 
            this.ListViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.Version,
            this.UpdateFileDate,
            this.Progressbar});
            this.ListViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewFiles.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListViewFiles.GridLines = true;
            this.ListViewFiles.HideSelection = false;
            this.ListViewFiles.Location = new System.Drawing.Point(0, 0);
            this.ListViewFiles.MultiSelect = false;
            this.ListViewFiles.Name = "ListViewFiles";
            this.ListViewFiles.Size = new System.Drawing.Size(594, 405);
            this.ListViewFiles.TabIndex = 11;
            this.ListViewFiles.UseCompatibleStateImageBehavior = false;
            this.ListViewFiles.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "文件名";
            this.FileName.Width = 310;
            // 
            // Version
            // 
            this.Version.Text = "版本号";
            this.Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Version.Width = 100;
            // 
            // UpdateFileDate
            // 
            this.UpdateFileDate.Text = "日期";
            this.UpdateFileDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpdateFileDate.Width = 100;
            // 
            // Progressbar
            // 
            this.Progressbar.Text = "进度";
            this.Progressbar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Progressbar.Width = 65;
            // 
            // ProgressBarUpdate
            // 
            this.ProgressBarUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBarUpdate.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ProgressBarUpdate.Location = new System.Drawing.Point(0, 405);
            this.ProgressBarUpdate.Name = "ProgressBarUpdate";
            this.ProgressBarUpdate.Size = new System.Drawing.Size(594, 16);
            this.ProgressBarUpdate.TabIndex = 8;
            // 
            // LabelNext
            // 
            this.LabelNext.BackColor = System.Drawing.Color.LightGray;
            this.LabelNext.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelNext.Location = new System.Drawing.Point(0, 421);
            this.LabelNext.Name = "LabelNext";
            this.LabelNext.Size = new System.Drawing.Size(594, 20);
            this.LabelNext.TabIndex = 10;
            this.LabelNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormUpdateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 471);
            this.ControlBox = false;
            this.Controls.Add(this.ListViewFiles);
            this.Controls.Add(this.ProgressBarUpdate);
            this.Controls.Add(this.LabelNext);
            this.Controls.Add(this.PanelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新文件列表";
            this.Load += new System.EventHandler(this.FormUpdateList_Load);
            this.PanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelButtons;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonDownload;
        private System.Windows.Forms.Button ButtonFinish;
        private System.Windows.Forms.ListView ListViewFiles;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ColumnHeader UpdateFileDate;
        private System.Windows.Forms.ColumnHeader Progressbar;
        private System.Windows.Forms.ProgressBar ProgressBarUpdate;
        private System.Windows.Forms.Label LabelNext;
    }
}

