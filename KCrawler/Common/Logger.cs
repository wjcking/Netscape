
namespace KCrawler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    public class Logger
    {

        //     private string taskID;
        public List<LogInfo> Log { get; set; }
        public Logger()
        {
            //       this.taskID = taskID;

            if (Log == null)
                Log = new List<LogInfo>();
        }
        public LogInfo this[int index]
        {
            get
            {
                try
                {
                    if (Log == null || Log.Count == 0)
                        return new LogInfo()
                            {
                                LogTime = DateTime.Now,
                                Message = "no log added",
                                LogType = LogLevel.Fatal
                            };
                    return Log[index];
                }
                catch(Exception e)
                {
                    return new LogInfo() { Message = e.Message, LogType = LogLevel.Fatal };
                }
            }

        }
        public void LogMessage(string message, LogLevel logType)
        {

            Log.Add(new LogInfo()
            {
                LogTime = DateTime.Now,
                Message = message,
                LogType = logType
            });
        }
        public long GetCount(LogLevel logType)
        {
            int total = 0;
            try
            {
                for (int i = 0; i < Log.Count; i++)
                {
                    if (Log[i] == null)
                        continue;
                    if (logType == Log[i].LogType)
                        total++;
                }
            }
            catch (Exception e)
            {
                Fatal("[LogCount]"+e.Message);
                return -1;
            }
            return total;
        }

        public string GetCountText(LogLevel logType)
        {
            long total = GetCount(logType);
            return logType + ":" + total + " ";
        }

        public string LogCountText
        {
            get
            {
                System.Text.StringBuilder t = new System.Text.StringBuilder();
                t.Append("[Total] ");
                t.Append(GetCountText(LogLevel.Saved));
                t.Append(GetCountText(LogLevel.Info));
                t.Append(GetCountText(LogLevel.Error));
                t.Append(GetCountText(LogLevel.Fatal));
                return t.ToString();
            }
        }
        public void Info(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        public void Info(string message)
        {
            LogMessage(message, LogLevel.Info);
        }

        public void Error(string message)
        {
            LogMessage(message, LogLevel.Error);
        }

        public void Error(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        public void Fatal(string message)
        {
            LogMessage(message, LogLevel.Fatal);
        }

        public void Fatal(string format, params object[] args)
        {
            Fatal(string.Format(format, args));
        }
    }
    [Serializable]
    public class LogInfo
    {
        public string LogOut
        {
            get
            {
                return String.Format("[{0}]{1}", LogType.ToString(), Message);
            }
        }
        public string LogOutTime
        {
            get
            {
                return this == null ? String.Empty: String.Format("[{0}]{1} ({2})", LogType.ToString(), Message, LogTime);
            }
        }
        public string Message { get; set; }
        public DateTime LogTime { get; set; }
        public LogLevel LogType { get; set; }
        public Color Color
        {
            get
            {
                switch (LogType)
                {
                    case LogLevel.Saved:
                        return Color.Lime;

                    case LogLevel.Info:
                        return Color.Gold;

                    case LogLevel.Error:
                    case LogLevel.Warn:
                        return Color.Yellow;

                    case LogLevel.Fatal:
                        return Color.Red;

                }

                return Color.Lime;
            }
        }

    }
}
