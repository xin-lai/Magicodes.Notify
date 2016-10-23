using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Notify
{
    /// <summary>
    /// 通知内容
    /// </summary>
    public interface INotifyInfo
    {
        /// <summary>
        /// 图标
        /// </summary>
        string IconCls { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        string Href { get; set; }
        
        /// <summary>
        /// 任务是否已完成
        /// </summary>
        bool IsTaskFinish { get; set; }
        /// <summary>
        /// 百分比
        /// </summary>
        int? TaskPercentage { get; set; }
    }
}
