using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace KCrawler
 
  
{
    /// <summary>
    /// IniFiles的类
    /// </summary>
    public class IniFiles
    {
        public string FileName; //INI文件名
        //声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        //类的构造函数，传递INI文件名
    
        public IniFiles(string AFileName)
        {
            // 判断文件是否存在
            FileInfo fileInfo = new FileInfo(AFileName);
            //Todo:搞清枚举的用法
            if ((!fileInfo.Exists))
            { //|| (FileAttributes.Directory in fileInfo.Attributes))
                //文件不存在，建立文件
                StreamWriter sw = new StreamWriter(AFileName, false, System.Text.Encoding.Default);
                try
                {
                    sw.Write("#该配置文档可自行编写");
                    sw.Close();
                }
                catch
                {
                    throw (new ApplicationException("Ini文件不存在"));
                }
            }
            //必须是完全路径，不能是相对路径
            FileName = fileInfo.FullName;
        }
       
        //写INI文件
        public void WriteString(string Section, string key, string Value)
        {
            if (!WritePrivateProfileString(Section, key, Value, FileName))
            {
                throw (new ApplicationException("写Ini文件出错"));
            }
        }
          
        public List<string> GetList(string Section, string key)
        {
            string val = GetString(Section, key);
            int pos =val.IndexOf(',');
            if (val.Length > 0 && pos > -1)            
                return new List<string>(val.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            return new List<string>() { val };
        }
 
        public string GetString(string Section, string key, string Default)
        {
            Byte[] Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, key, Default, Buffer, Buffer.GetUpperBound(0), FileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            return s.Trim().Replace("\0",String.Empty);
        }
        public string GetString(string Section, string key )
        {
            Byte[] Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, key, String.Empty, Buffer, Buffer.GetUpperBound(0), FileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            return s.Trim().Replace("\0", String.Empty);
        }
        //读整数
        public int GetInteger(string Section, string key, int Default)
        {
            string intStr = GetString(Section, key, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);
            }
            catch  
            {
                return Default;
            }
        }
 
        //写整数
        public void WriteInteger(string Section, string key, int Value)
        {
           WriteString(Section, key, Value.ToString());
        }
 
        //读布尔
        public bool GetBoolean(string Section, string key, bool Default)
        {
            try
            {
                return Convert.ToBoolean(GetString(Section, key, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }
 
        //写Bool
        public void SetBoolean(string Section, string Ident, bool Value)
        {
            WriteString(Section, Ident, Convert.ToString(Value));
        }
 
        //从Ini文件中，将指定的Section名称中的所有Ident添加到列表中
        public List<string> ReadSection(string Section)
        {
            Byte[] Buffer = new Byte[16384];
            //Idents.Clear();
 
            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
                  FileName);
            //对Section进行解析
            return GetStringsFromBuffer(Buffer, bufLen);
        }

        private List<string> GetStringsFromBuffer(Byte[] Buffer, int bufLen)
        {
            List<string> strings = new List<string>();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        strings.Add(s);
                        start = i + 1;
                    }
                }
            }

            return strings;
        }
        //从Ini文件中，读取所有的Sections的名称
        public List<string> GetSectionList()
        {
         
            //Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section
            byte[] Buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, Buffer,
             Buffer.GetUpperBound(0), FileName);
            return GetStringsFromBuffer(Buffer, bufLen);
        }
        //读取指定的Section的所有Value到列表中
        //public void ReadSectionValues(string Section, NameValueCollection Values)
        //{
        //    List<string> KeyList = new List<string>();
      
        //    Values.Clear();
        //    foreach (string key in KeyList)
        //    {
        //        Values.Add(key, ReadString(Section, key, ""));
        //    }
        //}
        ////读取指定的Section的所有Value到列表中，
        //public void ReadSectionValues(string Section, NameValueCollection Values,char splitString)
        //{　 string sectionValue;
        //　　string[] sectionValueSplit;
        //　　List<string> KeyList = new List<string>();
        //　　ReadSection(Section, KeyList);
        //　　Values.Clear();
        //　　foreach (string key in KeyList)
        //　　{
        //　　　　sectionValue=ReadString(Section, key, "");
        //　　　　sectionValueSplit=sectionValue.Split(splitString);
        //　　　　Values.Add(key, sectionValueSplit[0].ToString(),sectionValueSplit[1].ToString());
 
        //　　}
        //}
        //清除某个Section
        public bool EraseSection(string Section)
        {
            if (!WritePrivateProfileString(Section, null, null, FileName))
            {
                return false;
            }

            return true;
        }
        //删除某个Section下的键
        public void DeleteKey(string Section, string Ident)
        {
            WritePrivateProfileString(Section, Ident, null, FileName);
        }
        //Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件
        //在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile
        //执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName);
        }
 
        //检查某个Section下的某个键值是否存在
        public bool ValueExists(string Section, string Ident)
        {
            //List<string> Idents = new List<string>();
            //ReadSection(Section, Idents);
            //return Idents.IndexOf(Ident) > -1;
            return false;
        }
 
        //确保资源的释放
        ~IniFiles()
        {
            UpdateFile();
        }
    }
}