using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.Notify.SignalR
{
    public interface IClientNotify
    {
        void Notify(INotifyInfo notifyInfo);
    }
}
