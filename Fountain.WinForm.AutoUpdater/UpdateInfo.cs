using System;
using System.Collections.Generic;
using System.Xml;

namespace Fountain.WinForm.AutoUpdater
{
    /// <summary>
    /// 更新信息
    /// </summary>
    public class UpdateInfo
    {
        /// <summary>
        /// 应用程序
        /// </summary>
        public string EntryPoint { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 文件列表
        /// </summary>
        public Dictionary<string, FileEntity> Files{ get; set; }
        /// <summary>
        /// 加载
        /// </summary>
        public void Load(string xmlFile)
        {
            try
            {
                Files=new Dictionary<string, FileEntity>();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlFile);
                XmlNode rootNode = xmlDocument.DocumentElement;
                // 获取主信息 
                XmlNodeList xmlNodeList = rootNode.SelectNodes("Updater");
                foreach (XmlNode xmlNodeUpdate in xmlNodeList)
                {
                    XmlNodeList xmlNodeMainInfo = xmlNodeUpdate.ChildNodes;
                    foreach (XmlNode xmlMainInfo in xmlNodeMainInfo)
                    {
                        switch (xmlMainInfo.Name.ToLower())
                        {
                            case "url":
                                this.Url = xmlMainInfo.InnerText;
                                break;
                            case "entrypoint":
                                this.EntryPoint = xmlMainInfo.InnerText;
                                break;
                            case "version":
                                this.Version = xmlMainInfo.InnerText;
                                break;
                            default:
                                break;
                        }
                    }
                }
                // 获取文件信息
                XmlNodeList xmlNodeFileList = rootNode.SelectNodes("Files");
                foreach (XmlNode xmlNodeFile in xmlNodeFileList)
                {
                    XmlNodeList xmlNodeFilexxx = xmlNodeFile.ChildNodes;
                    foreach (XmlNode item in xmlNodeFilexxx)
                    {
                        FileEntity fileEntity = new FileEntity();
                        for (int i = 0; i < item.Attributes.Count; i++)
                        {
                            switch (item.Attributes[i].Name.ToLower())
                            {
                                case "version":
                                    fileEntity.Version= item.Attributes[i].Value;
                                    break;
                                case "name":
                                    fileEntity.Name= item.Attributes[i].Value;
                                    break;
                                case "datetime":
                                    fileEntity.UpdateDateTime= item.Attributes[i].Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (fileEntity.Name.Length> 0)
                        {
                            if (!this.Files.ContainsKey(fileEntity.Name))
                            {
                                this.Files.Add(fileEntity.Name, fileEntity);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
            }
        }
    }
}
