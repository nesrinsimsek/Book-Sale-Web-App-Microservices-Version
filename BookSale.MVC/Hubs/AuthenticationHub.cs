using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BookSale.MVC.Hubs
{
    public class AuthenticationHub : Hub
    {
        public static Dictionary<string, HashSet<string>> userConnections { get; set; } = new Dictionary<string, HashSet<string>>();
        public Task HandleForceLogout()
        {
            var userId = Context.User.Identity.Name;
            var connectionId = Context.ConnectionId;

            if(userId != null)
            {
                if (!userConnections.ContainsKey(userId)) { userConnections[userId] = new HashSet<string>(); } // user id listede yoksa ekle
                if (!userConnections[userId].Contains(connectionId)) { // user id için bu connection id yoksa
                    if (userConnections[userId].Count >= 1) // ve başka connection varsa diğerlerinden çıkış yapmaya zorla
                    {
                        
                        Clients.Others.SendAsync("ForceLogout");
                        Context.Abort();
                        
                    }
                    else { // hiç connection yoksa connection id'yi  listeye ekle
                        userConnections[userId].Add(connectionId); 
                    }
                }

            }
            return Task.CompletedTask;

        }
    }
}
