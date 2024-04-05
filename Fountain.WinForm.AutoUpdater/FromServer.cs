using System;
using System.IO;
using System.Net;

namespace Fountain.WinForm.AutoUpdater
{
    public class FromServer
    {
        private static WebClient webClient = new WebClient();
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url">文件地址</param>        
        /// <param name="localUpdateTempPath">本地目录</param>
        public static void DownLoad(string url, string localUpdateTempPath)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    throw new Exception("下载地址不能为空!");
                }
                if (!Directory.Exists(localUpdateTempPath))
                {
                    Directory.CreateDirectory(localUpdateTempPath);
                }
                // 连接远程
                Stream stream = webClient.OpenRead(url);
                // 读取
                StreamReader streamReader = new StreamReader(stream);
                byte[] contentByte = new byte[62914560]; //60M 文件最大
                int contentLength = (int)contentByte.Length; 
                int startmbyte = 0;
                while (contentLength > 0)
                {
                    int m = stream.Read(contentByte, startmbyte, contentLength);
                    if (m == 0)
                        break;
                    startmbyte += m;
                    contentLength -= m;
                }
                streamReader.Dispose();
                stream.Dispose();

                string tempPathFile =string.Format("{0}{1}{2}", localUpdateTempPath , Path.DirectorySeparatorChar,Path.GetFileName(url));
                if (!Directory.Exists(localUpdateTempPath))
                {
                    Directory.CreateDirectory(localUpdateTempPath);
                }
                FileStream fileStream = new FileStream(tempPathFile, FileMode.OpenOrCreate, FileAccess.Write);
                fileStream.Write(contentByte, 0, startmbyte);
                fileStream.Flush();
                fileStream.Close();
            }
            catch (WebException webException)
            {
                throw new Exception(webException.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
