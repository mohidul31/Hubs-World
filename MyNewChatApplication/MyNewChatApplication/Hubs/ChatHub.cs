using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MyNewChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        public void SendFromTo(string from, string message, string to)
        {
            //Clients.Client(connId).appendNewMessage(name, message);  
            Clients.All.addNewMessageToPage(from, message, to);
        }
    }
}