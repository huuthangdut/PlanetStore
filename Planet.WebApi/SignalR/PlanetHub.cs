using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Planet.WebApi.Dtos.Notification;
using System.Linq;
using System.Threading.Tasks;

namespace Planet.WebApi.SignalR
{
    [Authorize]
    public class PlanetHub : Hub
    {
        private static readonly ConnectionMapping<string> _connections = new ConnectionMapping<string>();


        public static void PushToAllUsers(AnnouncementDto message, PlanetHub hub)
        {
            IHubConnectionContext<dynamic> clients = GetClients(hub);
            clients.All.addAnnouncement(message);
        }


        public static void PushToUser(string who, AnnouncementDto message, PlanetHub hub)
        {
            IHubConnectionContext<dynamic> clients = GetClients(hub);
            foreach (var connectionId in _connections.GetConnections(who))
            {
                clients.Client(connectionId).addChatMessage(message);
            }
        }

        public static void PushToUsers(string[] whos, AnnouncementDto message, PlanetHub hub)
        {
            IHubConnectionContext<dynamic> clients = GetClients(hub);
            for (int i = 0; i < whos.Length; i++)
            {
                var who = whos[i];
                foreach (var connectionId in _connections.GetConnections(who))
                {
                    clients.Client(connectionId).addChatMessage(message);
                }
            }

        }
        private static IHubConnectionContext<dynamic> GetClients(PlanetHub planetHub)
        {
            if (planetHub == null)
                return GlobalHost.ConnectionManager.GetHubContext<PlanetHub>().Clients;

            return planetHub.Clients;
        }

        public override Task OnConnected()
        {
            _connections.Add(Context.User.Identity.Name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _connections.Remove(Context.User.Identity.Name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            if (!_connections.GetConnections(Context.User.Identity.Name).Contains(Context.ConnectionId))
            {
                _connections.Add(Context.User.Identity.Name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

    }
}