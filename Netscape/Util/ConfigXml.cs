using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Netscape
{

    public class ConfigXml
    {
        protected XmlDocument xmlDoc = new XmlDocument();
        protected XmlNodeList childNodes;
        protected string singleNodeInfo = "Netscape";
        protected string fileName; 
        /// <summary>
        /// load xml file
        /// </summary>
        /// <param name="fileName"></param>
        public ConfigXml(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("文件名不能为空"); ;

            if (!System.IO.File.Exists(fileName))
                throw new Exception("文件不存在");
            this.fileName = fileName;
            xmlDoc.Load(fileName);

        }

        /// <summary>
        /// Read settings' file values
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValue(string name)
        {
            childNodes = xmlDoc.DocumentElement.ChildNodes;
            return childNodes.Item(0)[name] == null ? string.Empty : childNodes.Item(0)[name].InnerText;
        }
        /// <summary>
        /// Write settings' file values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue(string name, string value)
        {
            childNodes = xmlDoc.DocumentElement.ChildNodes;
            childNodes.Item(0)[name].InnerText = value;
            xmlDoc.Save(fileName);
        }
    }
}
