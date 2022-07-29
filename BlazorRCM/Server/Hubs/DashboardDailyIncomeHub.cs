using Microsoft.AspNetCore.SignalR;

namespace BlazorRCM.Server.Hubs
{
    public class DashboardDailyIncomeHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("bağlı");
            //await RefreshIncome(0, 0);
            await base.OnConnectedAsync();
        }
        public async Task RefreshIncome(decimal total, short count)
        {
            await Clients.All.SendAsync("NewDailyIncome",total,count);
        }
    }
}
