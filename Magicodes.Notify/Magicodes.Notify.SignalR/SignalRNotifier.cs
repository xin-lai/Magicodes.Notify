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
    /// <summary>
    /// 
    /// </summary>
    public class SignalRNotifier<T> : INotifier<T> where T : INotifyInfo
    {
        /// <summary>
        /// Hub代理
        /// </summary>
        IHubContext _context { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SignalRNotifier()
        {
            _context = GlobalHost.ConnectionManager.GetHubContext<NotifyHub>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public SignalRNotifier(IHubContext _context)
        {
            this._context = _context;
        }
        
        internal static Func<Expression<Func<T, bool>>, int, int, List<T>> GetNofityListByGroupFunc = null;

        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <param name="wherePredicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<T> GetNofityList(Expression<Func<T, bool>> wherePredicate = null, int pageIndex = 0, int pageSize = 10)
        {
            if (GetNofityListByGroupFunc == null)
            {
                throw new NotImplementedException("GetNofityListByGroup尚未实现，请使用NotifyBuilder.WithGetNofityListByGroupFunc实现!");
            }
            return GetNofityListByGroupFunc(wherePredicate, pageIndex, pageSize);
        }
        /// <summary>
        /// 通知
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="notify"></param>
        /// <param name="group"></param>
        public void NotifyTo(T notify, string group = null)
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
        /// 通知
        /// </summary>
        /// <param name="notifies"></param>
        /// <param name="group"></param>
        public void NotifyTo(List<T> notifies, string group = null)
        {
            if (group == null)
            {
                _context.Clients.All.Notify(notifies);
            }
            else
            {
                _context.Clients.Group(group).Notify(notifies);
            }
        }
    }
}
