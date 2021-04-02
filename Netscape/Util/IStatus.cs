using System;
using System.Collections.Generic;
using System.Text;

namespace Netscape
{
    /// <summary>
    /// 状态栏公共约束函数，方便发送信息改变颜色
    /// </summary>
    public interface IStatus
    {
        void Done();
        void Done(string doneString);
        void Error(string error);
        void Start(string text);
    }
}
