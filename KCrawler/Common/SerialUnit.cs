
namespace KCrawler
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    public class SerialUnit
    {
        /// <summary>  
        /// 把对象序列化为字节数组  
        /// </summary>  
        private static byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }
        /// <summary>  
        /// 把字节数组反序列化成对象  
        /// </summary>  
        private static object DeserializeObject(byte[] bytes)
        {
            object obj = null;
            if (bytes == null)
                return obj;
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms);
            ms.Close();
            return obj;
        }
 

        
        // 把对象保存成二进制文件
        public static void Save(object obj, string fileName)
        {

            byte[] buffer = SerializeObject(obj);
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
        }

        
        // 把二进制文件转换成对象
        public static object Open(string fileName)
        {
            if (!File.Exists(fileName))
                return null;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (stream.Length == 0)
                return null;
            object o = formatter.Deserialize(stream);
            stream.Close();
            return o;
        }
      
    }
}