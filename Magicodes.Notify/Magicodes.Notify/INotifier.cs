using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Notify
{
    /// <summary>
    /// 通知者
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// 通知
        /// </summary>
        /// <param name="notify"></param>
        /// <param name="group"></param>
        void NotifyTo(INotifyInfo notify, string group = null);
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        List<INotifyInfo> GetNofityListByGroup(IQueryable<INotifyInfo> query = null, string group = null);
    }
}
