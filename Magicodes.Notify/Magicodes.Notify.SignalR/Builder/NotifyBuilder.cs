using Magicodes.Notify.SignalR.Helper;
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
    public class NotifyBuilder<T> where T : INotifyInfo
    {
        Action<HubCallerContext, IGroupManager> OnConnected = null;
        Action<HubCallerContext, IGroupManager> OnDisconnected = null;
        Action<HubCallerContext, IGroupManager> OnReconnected = null;
        Func<Expression<Func<T, bool>>, int, int, List<T>> GetNofityListByGroupFunc = null;
        Func<string,string, HubCallerContext, IGroupManager, INotifyInfo> OnClientNotify = null;

        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static NotifyBuilder<T> Create()
        {
            return new NotifyBuilder<T>();
        }
        /// <summary>
        /// 设置连接时处理逻辑
        /// </summary>
        /// <param name="onConnected"></param>
        /// <returns></returns>
        public NotifyBuilder<T> WithOnConnected(Action<HubCallerContext, IGroupManager> onConnected)
        {
            OnConnected = onConnected;
            return this;
        }
        /// <summary>
        /// 设置连接断开时处理逻辑
        /// </summary>
        /// <param name="onDisconnected"></param>
        /// <returns></returns>
        public NotifyBuilder<T> WithOnDisconnected(Action<HubCallerContext, IGroupManager> onDisconnected)
        {
            OnDisconnected = onDisconnected;
            return this;
        }
        /// <summary>
        /// 设置重连时的处理逻辑
        /// </summary>
        /// <param name="onReconnected"></param>
        /// <returns></returns>
        public NotifyBuilder<T> WithOnReconnected(Action<HubCallerContext, IGroupManager> onReconnected)
        {
            OnReconnected = onReconnected;
            return this;
        }
        /// <summary>
        /// 设置客户端通知事件逻辑
        /// </summary>
        /// <param name="onClientNotify"></param>
        /// <returns></returns>
        public NotifyBuilder<T> WithOnClientNotify(Func<string, string, HubCallerContext, IGroupManager, INotifyInfo> onClientNotify)
        {
            OnClientNotify = onClientNotify;
            return this;
        }

        ///// <summary>
        ///// 设置获取通知列表的处理逻辑
        ///// </summary>
        ///// <param name="getNofityListByGroupFunc"></param>
        ///// <returns></returns>
        //public NotifyBuilder<T> WithGetNofityListByGroupFunc(Func<Expression<Func<T, bool>>, int, int, List<T>> getNofityListByGroupFunc)
        //{
        //    GetNofityListByGroupFunc = getNofityListByGroupFunc;
        //    return this;
        //}

        /// <summary>
        ///     确定设置
        /// </summary>
        public void Build()
        {
            NotifierHelper.OnConnected = OnConnected;
            NotifierHelper.OnDisconnected = OnDisconnected;
            NotifierHelper.OnReconnected = OnReconnected;
            NotifierHelper.OnClientNotify = OnClientNotify;
            //SignalRNotifier<T>.GetNofityListByGroupFunc = GetNofityListByGroupFunc;
        }
    }
}