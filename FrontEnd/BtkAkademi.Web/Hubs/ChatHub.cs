using Microsoft.AspNetCore.SignalR;

namespace BtkAkademi.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


        private static List<string> ConnectedUsers = new List<string>();

        public override async Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name; // Kullanıcı adını almanız gerekebilir.

            if (!string.IsNullOrEmpty(userName))
            {
                ConnectedUsers.Add(userName);
                await Clients.All.SendAsync("UserConnected", userName, ConnectedUsers);
            }

            await base.OnConnectedAsync();
        }

        public async Task JoinPrivateChat(string user1, string user2)
        {
            string groupName = GetPrivateGroupName(user1, user2);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendPrivateMessage(string groupName, string user, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceivePrivateMessage", user, message);
        }

        private string GetPrivateGroupName(string user1, string user2)
        {
            // Sıralanmış kullanıcı adlarından özel grup adı oluşturabilirsiniz.
            var users = new List<string> { user1, user2 };
            users.Sort();
            return $"private_{users[0]}_{users[1]}";
        }





    }
}
