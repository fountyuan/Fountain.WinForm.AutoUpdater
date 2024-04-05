using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Fountain.WinForm.AutoUpdater
{
    public partial class FormUpdateList : Form
    {
        /// <summary>
        /// 待更新文件
        /// </summary>
        public Dictionary<string, FileEntity> WaitFiles { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public FormUpdateList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public FormUpdateList(Dictionary<string, FileEntity> waitFiles)
        {
            this.InitializeComponent();
            this.WaitFiles = waitFiles;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormUpdateList_Load(object sender, EventArgs e)
        {
            try
            {
                this.ProgressBarUpdate.Visible = false;
                this.ButtonUpdate.Visible = false;
                foreach (string fileItem in WaitFiles.Keys)
                {
                    ListViewItem listViewItem = new ListViewItem(fileItem);
                    listViewItem.SubItems.Add(WaitFiles[fileItem].Version);
                    listViewItem.SubItems.Add(WaitFiles[fileItem].UpdateDateTime);
                    this.ListViewFiles.Items.Add(listViewItem);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //弹出提示
                DialogResult result = MessageBox.Show("你确定取消更新?","更新", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //如果确定取消
                if (result == DialogResult.OK)
                {
                    //如果临时目录已经存在,则删除
                    if (Directory.Exists(Variable.LocalUpdateTempPath))
                    {
                        //删除临时目录
                        Directory.Delete(Variable.LocalUpdateTempPath, true);
                    }
                    //退出线程
                    Application.ExitThread();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "更新", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 退出主应用程序
        /// </summary>
        internal void ExitEntryPoint()
        {
            try
            {
                if (!string.IsNullOrEmpty(Variable.EntryPoint))
                {
                    string mainAppExe = Variable.EntryPoint;
                    Process[] allProcess = Process.GetProcesses();
                    foreach (Process processItem in allProcess)
                    {
                        if (processItem.ProcessName.Equals(mainAppExe.Replace(".exe", ""), StringComparison.OrdinalIgnoreCase))
                        {
                            for (int i = 0; i < processItem.Threads.Count; i++)
                            {
                                processItem.Threads[i].Dispose();
                            }
                            processItem.Kill();
                        }
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                this.LabelNext.Text = "正从服务器下载更新文件,请耐心等待......";
                if (this.ListViewFiles.Items.Count > 0)
                {
                    this.ExitEntryPoint();
                    Thread.Sleep(100);
                    Thread downLadInvoicehandler = new Thread((ThreadStart)(() =>
                    {
                        // 下载
                        this.Download();
                    }));
                    downLadInvoicehandler.SetApartmentState(ApartmentState.STA);
                    downLadInvoicehandler.Start();
                }
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                    MessageBox.Show(exception.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                this.ProgressBarUpdate.Visible = false;
            }
        }
        /// <summary>
        /// 从服务器下载文件到本地临时目录
        /// </summary>
        private void Download()
        {
            try
            {
                //显示进度条
                this.ProgressBarUpdate.Visible = true;
                this.ButtonDownload.Enabled = false;

                string downFileName = string.Empty;
                this.ProgressBarUpdate.Maximum = this.ListViewFiles.Items.Count;
                //根据查检出的差导文件,循环从指定服务器下载文件
                for (int i = 0; i < this.ListViewFiles.Items.Count; i++)
                {
                    try
                    {
                        this.ListViewFiles.TopItem = this.ListViewFiles.Items[i];
                        ListViewFiles.Items[i].UseItemStyleForSubItems = true;
                        downFileName = this.ListViewFiles.Items[i].Text.Trim();

                        int spcharstart = downFileName.LastIndexOf("\\");

                        string downTempPath = Variable.LocalUpdateTempPath;

                        if (spcharstart > 0)
                        {
                            downTempPath = Variable.LocalUpdateTempPath + downFileName.Substring(0, spcharstart + 1);
                        }
                        // 下载
                        FromServer.DownLoad(Variable.Url + "/" + downFileName.Replace("\\", "/"), downTempPath);
                        this.ProgressBarUpdate.Value = i;
                        this.ListViewFiles.Items[i].SubItems[3].Text = "100%";
                    }
                    catch
                    {
                    }
                }
                //隐藏进度条
                this.LabelNext.Text = string.Empty;
                this.ButtonDownload.Visible = false;
                this.ProgressBarUpdate.Visible = false;
                this.ButtonUpdate.Visible = true;
                this.ProgressBarUpdate.Value = 0;
            }
            catch (Exception exception)
            {
                this.ButtonUpdate.Visible = true;
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 更新文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExitEntryPoint();
                Thread.Sleep(100);
                this.ButtonUpdate.Enabled = false;
                this.ProgressBarUpdate.Visible = true;
                this.LabelNext.Text ="正在更新本地文件,请耐心等待......";
                this.Progressbar.Width = 0;
                // 清空下载进度%比
                for (int i = 0; i < this.ListViewFiles.Items.Count; i++)
                {
                    this.ListViewFiles.Items[i].SubItems[3].Text =string.Empty;
                }
                //列表定位到第一行
                this.ListViewFiles.TopItem = this.ListViewFiles.Items[0];

                this.UpdateReplace(Variable.LocalUpdateTempPath, Application.StartupPath);
                //更新配置文件列表
                System.IO.File.Copy(Variable.LocalUpdateTempPath + Variable.LOCAL_VERSION_FILE, Application.StartupPath + Path.DirectorySeparatorChar+ Variable.LOCAL_VERSION_FILE, true);
                
                //显示完成按钮
                this.LabelNext.Text = "成功升级,重新登录系统体验新版本功能";
                this.ButtonUpdate.Visible = false;
                this.ButtonFinish.Visible = true;
                this.ButtonCancel.Enabled = false;
                Thread.Sleep(2000);
            }
            catch
            {
            }
            finally
            {
                this.ProgressBarUpdate.Visible = false;
            }
        }
        /// <summary>
        /// 将原目录的文件复制到目标文件
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public void UpdateReplace(string sourcePath, string targetPath)
        {
            try
            {
                // 判断更新目录是否存在
                if (Directory.Exists(sourcePath))
                {
                    // 判断目标目录是否存在
                    if (!Directory.Exists(targetPath))
                    {
                        //如果不存在则创建该目录
                        Directory.CreateDirectory(targetPath);
                    }
                    // 根据源目录提取该目录下的所有文件
                    string[] files = Directory.GetFiles(sourcePath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        string[] childFiles = files[i].Split('\\');
                        File.Copy(files[i], targetPath + @"\" + childFiles[childFiles.Length - 1], true);
                    }
                    string[] subDirectory = Directory.GetDirectories(sourcePath);
                    for (int i = 0; i < subDirectory.Length; i++)
                    {
                        string[] childdir = subDirectory[i].Split('\\');
                        UpdateReplace(subDirectory[i], targetPath + @"\" + childdir[childdir.Length - 1]);
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Variable.LocalUpdateTempPath))
                {
                    //删除临时目录
                    Directory.Delete(Variable.LocalUpdateTempPath, true);
                }
                if (!string.IsNullOrEmpty(Variable.EntryPoint))
                {
                    Process.Start(Variable.EntryPoint);
                }
                Environment.Exit(0);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "更新", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}