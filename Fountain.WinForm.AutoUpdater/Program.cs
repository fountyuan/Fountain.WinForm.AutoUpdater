using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fountain.WinForm.AutoUpdater
{
    internal static class Program
    {
        internal static ApplicationContext context = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UpdateChecker checker = new UpdateChecker();
            // 开始检查更新
            Dictionary<string, FileEntity> waitFiles = checker.Execute();
            // 
            if (waitFiles.Count>0)
            {
                MessageBox.Show("");
                context = new ApplicationContext(new FormUpdateList());
                Application.Run(context);
            }
            else
            {
                MessageBox.Show("已经是最新版本。");
            }
        }
    }
}
