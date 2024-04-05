using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Fountain.WinForm.AutoUpdater
{
    /// <summary>
    /// 检查更新
    /// </summary>
    public class UpdateChecker
    { 
        /// <summary>
        /// 检查更新版本
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,FileEntity> Execute()
        {
            Dictionary<string, FileEntity> waitFiles = new Dictionary<string, FileEntity>();
            try
            {
                Variable.LocalUpdateTempPath= string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory,"utemp");
                // 获取本地程序版本信息
                string localVersionFilePath = string.Format("{0}{1}{2}",Application.StartupPath,Path.DirectorySeparatorChar, Variable.LOCAL_VERSION_FILE);
                //如果临时目录已经存在,则删除
                if (Directory.Exists(Variable.LocalUpdateTempPath))
                {
                    // 删除临时目录
                    Directory.Delete(Variable.LocalUpdateTempPath, true);
                }
                // 获取本地版本信息
                UpdateInfo updateInfoLocal = new UpdateInfo();
                // 加载
                updateInfoLocal.Load(localVersionFilePath);
                // 本地版本文件信息
                Dictionary<string, FileEntity> localVersionFiles = updateInfoLocal.Files;

                // 远端获取版本文件信息
                FromServer.DownLoad(string.Format("{0}{1}", updateInfoLocal.Url, Variable.LOCAL_VERSION_FILE), Variable.LocalUpdateTempPath);
                
                Variable.Url = updateInfoLocal.Url;
                Variable.EntryPoint= updateInfoLocal.EntryPoint;

                // 服务器版本信息
                UpdateInfo updateInfoServer = new UpdateInfo();
                updateInfoServer.Load(string.Format("{0}{1}{2}", Variable.LocalUpdateTempPath, Path.DirectorySeparatorChar, Variable.LOCAL_VERSION_FILE));
                // 服务器版本文件信息
                Dictionary<string, FileEntity> serverVersionFiles = updateInfoServer.Files;

                // 文件版本比较
                foreach (string fileItem in serverVersionFiles.Keys)
                {
                    if (localVersionFiles.ContainsKey(fileItem)) 
                    {
                        if (!serverVersionFiles[fileItem].Version.Equals(localVersionFiles[fileItem].Version,StringComparison.OrdinalIgnoreCase))
                        {
                            waitFiles.Add(fileItem, serverVersionFiles[fileItem]);
                        }
                    }
                    else
                    {
                        waitFiles.Add(fileItem, serverVersionFiles[fileItem]);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return waitFiles;
        }
    }
}
