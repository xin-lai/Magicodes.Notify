using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Magicodes.Notify.SignalR.Builder
{
    internal class NotifyBuilder
    {
        Func<HubCallerContext, IGroupManager, NotifyGroupInfo> OnConnected = null;
        Action<HubCallerContext, IGroupManager> OnDisconnected = null;
        Action<HubCallerContext, IGroupManager> OnReconnected = null;
        Func<IQueryable<INotifyInfo>, string, List<INotifyInfo>> GetNofityListByGroupFunc = null;

        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static NotifyBuilder Create()
        {
            return new NotifyBuilder();
        }

        public NotifyBuilder WithOnConnected(Func<HubCallerContext, IGroupManager, NotifyGroupInfo> onConnected)
        {
            OnConnected = onConnected;
            return this;
        }
        public NotifyBuilder WithOnDisconnected(Action<HubCallerContext, IGroupManager> onDisconnected)
        {
            OnDisconnected = onDisconnected;
            return this;
        }

        public NotifyBuilder WithOnReconnected(Action<HubCallerContext, IGroupManager> onReconnected)
        {
            OnReconnected = onReconnected;
            return this;
        }
        public NotifyBuilder WithGetNofityListByGroupFunc(Func<IQueryable<INotifyInfo>, string, List<INotifyInfo>> getNofityListByGroupFunc)
        {
            GetNofityListByGroupFunc = getNofityListByGroupFunc;
            return this;
        }

        /// <summary>
        ///     确定设置
        /// </summary>
        public void Build()
        {
            SignalRNotifier.OnConnected = OnConnected;
            SignalRNotifier.OnDisconnected = OnDisconnected;
            SignalRNotifier.OnReconnected = OnReconnected;
            SignalRNotifier.GetNofityListByGroupFunc = GetNofityListByGroupFunc;
        }
    }
}