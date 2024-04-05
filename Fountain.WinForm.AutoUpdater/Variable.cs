using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fountain.WinForm.AutoUpdater
{
    public class Variable
    {
        /// <summary>
        /// 主应用程序
        /// </summary>
        public static string EntryPoint = "FountainWinForm.exe";
        /// <summary>
        /// 服务器地址
        /// </summary>
        public static string Url = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public const string LOCAL_VERSION_FILE = "Version.xml";
        /// <summary>
        /// 更新文件存储路径
        /// </summary>
        public static string LocalUpdateTempPath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "utemp");
    }
}
