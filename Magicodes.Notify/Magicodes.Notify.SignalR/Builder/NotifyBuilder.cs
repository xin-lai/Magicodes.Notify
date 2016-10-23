using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Magicodes.Notify.SignalR.Builder
{
    /// <summary>
    /// 设置
    /// </summary>
    public class NotifyBuilder
    {
        Func<HubCallerContext, IGroupManager, NotifyGroupInfo> OnConnected = null;
        Action<HubCallerContext, IGroupManager> OnDisconnected = null;
        Action<HubCallerContext, IGroupManager> OnReconnected = null;
        Func<Expression<Func<INotifyInfo, bool>>, int, int, List<INotifyInfo>> GetNofityListByGroupFunc = null;

        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static NotifyBuilder Create()
        {
            return new NotifyBuilder();
        }
        /// <summary>
        /// 设置连接时处理逻辑
        /// </summary>
        /// <param name="onConnected"></param>
        /// <returns></returns>
        public NotifyBuilder WithOnConnected(Func<HubCallerContext, IGroupManager, NotifyGroupInfo> onConnected)
        {
            OnConnected = onConnected;
            return this;
        }
        /// <summary>
        /// 设置连接断开时处理逻辑
        /// </summary>
        /// <param name="onDisconnected"></param>
        /// <returns></returns>
        public NotifyBuilder WithOnDisconnected(Action<HubCallerContext, IGroupManager> onDisconnected)
        {
            OnDisconnected = onDisconnected;
            return this;
        }
        /// <summary>
        /// 设置重连时的处理逻辑
        /// </summary>
        /// <param name="onReconnected"></param>
        /// <returns></returns>
        public NotifyBuilder WithOnReconnected(Action<HubCallerContext, IGroupManager> onReconnected)
        {
            OnReconnected = onReconnected;
            return this;
        }
        /// <summary>
        /// 设置获取通知列表的处理逻辑
        /// </summary>
        /// <param name="getNofityListByGroupFunc"></param>
        /// <returns></returns>
        public NotifyBuilder WithGetNofityListByGroupFunc(Func<Expression<Func<INotifyInfo, bool>>, int, int, List<INotifyInfo>> getNofityListByGroupFunc)
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