using Magicodes.Notify.SignalR.Helper;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Notify.SignalR
{
    /// <summary>
    /// 
    /// </summary>
    public class NotifyHub : Hub<IClientNotify>
    {
        /// <summary>
        /// 通知相关组
        /// </summary>
        /// <param name="notifyInfo"></param>
        /// <param name="group"></param>
        public void Notify(object notifyInfo, string group)
        {
            if (NotifierHelper.OnClientNotify != null && notifyInfo != null)
            {
                var notify = NotifierHelper.OnClientNotify(notifyInfo.ToString());
                if (string.IsNullOrEmpty(group))
                {
                    Clients.All.Notify(notify);
                }
                else
                {
                    Clients.Group(group).Notify(notify);
                }
            }
        }
        /// <summary>
        /// 成功连接
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            if (NotifierHelper.OnConnected != null)
            {
                var groupInfo = NotifierHelper.OnConnected(Context, Groups);
                if (groupInfo != null)
                {
                    foreach (var item in groupInfo.GroupNames)
                    {
                        Groups.Add(this.Context.ConnectionId, item);
                    }
                }
            }
            return base.OnConnected();
        }
        /// <summary>
        /// 连接断开
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            NotifierHelper.OnDisconnected?.Invoke(Context, Groups);
            return base.OnDisconnected(stopCalled);
        }
        /// <summary>
        /// 重连
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            NotifierHelper.OnReconnected?.Invoke(Context, Groups);
            return base.OnReconnected();
        }



    }
}
