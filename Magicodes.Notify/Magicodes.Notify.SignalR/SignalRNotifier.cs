using Magicodes.Notify.SignalR.Builder;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Notify.SignalR
{
    public class SignalRNotifier : INotifier
    {
        /// <summary>
        /// Hub代理
        /// </summary>
        IHubContext _context { get; set; }
        public SignalRNotifier()
        {
            _context = GlobalHost.ConnectionManager.GetHubContext<NotifyHub>();
        }
        public SignalRNotifier(IHubContext _context)
        {
            this._context = _context;
        }
        internal static Func<HubCallerContext, IGroupManager, NotifyGroupInfo> OnConnected = null;
        internal static Action<HubCallerContext, IGroupManager> OnDisconnected = null;
        internal static Action<HubCallerContext, IGroupManager> OnReconnected = null;
        internal static Func<Expression<Func<INotifyInfo, bool>>, int, int, List<INotifyInfo>> GetNofityListByGroupFunc = null;

        /// <summary>
        /// 通知
        /// </summary>
        /// <param name="notify"></param>
        /// <param name="group"></param>
        public void NotifyTo(INotifyInfo notify, string group = null)
        {
            if (group == null)
            {
                _context.Clients.All.Notify(notify);
            }
            else
            {
                _context.Clients.Group(group).Notify(notify);
            }
        }
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="wherePredicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<INotifyInfo> GetNofityList(Expression<Func<INotifyInfo, bool>> wherePredicate = null, int pageIndex = 0, int pageSize = 10)
        {
            if (GetNofityListByGroupFunc == null)
            {
                throw new NotImplementedException("GetNofityListByGroup尚未实现，请使用NotifyBuilder.WithGetNofityListByGroupFunc实现!");
            }
            return GetNofityListByGroupFunc(wherePredicate, pageIndex, pageSize);
        }
    }
}
