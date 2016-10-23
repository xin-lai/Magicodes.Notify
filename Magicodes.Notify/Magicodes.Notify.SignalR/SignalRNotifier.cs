using Magicodes.Notify.SignalR.Builder;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
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
        internal static Func<IQueryable<INotifyInfo>, string, List<INotifyInfo>> GetNofityListByGroupFunc = null;
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="group">组名称</param>
        /// <returns></returns>
        public List<INotifyInfo> GetNofityListByGroup(IQueryable<INotifyInfo> query = null, string group = null)
        {
            if (GetNofityListByGroupFunc == null)
            {
                throw new NotImplementedException("GetNofityListByGroup尚未实现，请使用NotifyBuilder.WithGetNofityListByGroupFunc实现!");
            }
            return GetNofityListByGroupFunc(query, group);
        }
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
    }
}
