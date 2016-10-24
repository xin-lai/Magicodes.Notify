using Magicodes.Notify.SignalR.Builder;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Notify.SignalR.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class NotifierHelper
    {
        internal static Func<HubCallerContext, IGroupManager, NotifyGroupInfo> OnConnected = null;
        internal static Action<HubCallerContext, IGroupManager> OnDisconnected = null;
        internal static Action<HubCallerContext, IGroupManager> OnReconnected = null;
        internal static Func<string, INotifyInfo> OnClientNotify = null;
    }
}
