using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MyNewChatApplication.Hubs
{
    public class HitCounter : Hub
    {
        private static int clientCounter = 0;
        public void Send()
        {
            string message = "";
            // Call the recalculateOnlineUsers method to update clients
            if (clientCounter < 2)
                message = string.Format("Currently {0} user is online.", clientCounter);
            else
                message = string.Format("Currently {0} users are online.", clientCounter);

            Clients.All.recalculateOnlineUsers(message);
        }

        /// <summary>
        /// register online user
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            clientCounter++;
            return base.OnConnected();
        }

        /// <summary>
        /// unregister disconected user
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            clientCounter--;
            return base.OnDisconnected(stopCalled);
        }
    }
}