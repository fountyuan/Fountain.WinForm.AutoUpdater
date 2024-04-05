using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fountain.WinForm.AutoUpdater
{
    public class FileEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }    
        /// <summary>
        /// 时间
        /// </summary>
        public string UpdateDateTime { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
    }
}
