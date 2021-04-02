using System;
using System.Collections.Generic;
using System.Text;

namespace KCrawler
{
    public class MimeInfo
    { 
        private string mime;

        /// <summary>
        /// 扩展名，变成小写，没有点，加上
        /// </summary>
        public string DotExtenion
        {
            get { return "."+ Extension.ToLower().Trim(); }
        }
        public string Extension
        {
            get;
            set;
        }
        /// <summary>
        /// 子类使用
        /// </summary>
        public int MimeID
        {
            get;
            set;
        }
        public string Mime
        {
            get { return mime.ToLower().Trim(); }
            set { mime = value; }
        }
        public int RowID
        {
            get;
            set;
        }
        public string Category { get; set; }

        public virtual string Text
        {
            get
            {
                return string.Format("[{0}] {1}", Category, Extension);
            }
        }

        public virtual string EMText
        {
            get
            {

                return string.Format("[{0}] {1}", Extension, mime);
            }
        }

        /// <summary>
        /// 父类mimeid
        /// </summary>
        public int ID { get; set; }
       /// <summary>
       /// 0=普通 1=文件（加入filepool)
       /// </summary>
        public short MType { get; set; }
    }


    public class MCateInfo
    {
        /// <summary>
        /// 主键mime
        /// </summary>		
        private string category;

        public string Category
        {
            get { return category.Trim(); }
            set { category = value.Trim(); }
        }
        public string Desc { get; set; }
        public string DescEn { get; set; }
        public short OrderNumber { get; set; }
    }
    public class PriorityInfo :MimeInfo
    {
        public override string Text
        {
            get
            {

                return string.Format("[Level-{0}]{1}", Priority, DotExtenion);
            }
        }
        public string TaskName { get; set; }
        public short Priority { get; set; }
        public FrontierQueuePriority QueuePriority
        {
            get
            {
                try
                {
                    return (FrontierQueuePriority)Priority;
                }
                catch
                {
                    return FrontierQueuePriority.Normal;
                }
            }
        }
    }


    public class FilterInfo : MimeInfo
    {
        public string TaskName { get; set; }
    } 
}
