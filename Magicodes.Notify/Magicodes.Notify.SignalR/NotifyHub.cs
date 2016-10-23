using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Notify.SignalR
{
    public class NotifyHub : Hub<IClientNotify>
    {
        public void Notify(INotifyInfo notifyInfo, string group = null)
        {
            if (group == null)
            {
                Clients.All.Notify(notifyInfo);
            }
            else
            {
                Clients.Group(group).Notify(notifyInfo);
            }
        }
        public override Task OnConnected()
        {
            if (SignalRNotifier.OnConnected != null)
            {
                var groupInfo = SignalRNotifier.OnConnected(Context, Groups);
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
        public override Task OnDisconnected(bool stopCalled)
        {
            if (SignalRNotifier.OnDisconnected != null)
                SignalRNotifier.OnDisconnected(Context, Groups);
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            if (SignalRNotifier.OnReconnected != null)
                SignalRNotifier.OnReconnected(Context, Groups);
            return base.OnReconnected();
        }



    }
}
