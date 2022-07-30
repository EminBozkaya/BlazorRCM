using Blazored.LocalStorage;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;

namespace BlazorRCM.Client.Pages
{
    public partial class Index
    {
        [CascadingParameter]
        public Task<AuthenticationState>? AuthState { get; set; }

        [Inject]
        NavigationManager? NavigationManager { get; set; }

        [Inject]
        public HttpClient? Client { get; set; }

        [Inject]
        ILocalStorageService? LocalStorageService { get; set; }

        private bool arrows = true;
        private bool bullets = true;
        private bool autocycle = false;
        private Transition transition = Transition.Slide;

        private HubConnection? hubConnection;
        private decimal dailyIncome = 0;
        private short dailyIncomeCount = 0;
        private List<SaleDTO> SaleList = new();

        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthState!;

            if (authState.User.Identity!.IsAuthenticated)
            {
                try
                {
                    SaleList = await Client!.GetServiceResponseAsync<List<SaleDTO>>("api/Sale/GetListOfToday", true);
                }
                catch (Exception)
                {
                    dailyIncome = 0;
                    dailyIncomeCount = 0;
                }
                if (SaleList != null)
                {
                    dailyIncomeCount = Convert.ToInt16(SaleList.Count);
                    foreach (SaleDTO dto in SaleList)
                    {
                        dailyIncome = dailyIncome + dto.TotalPrice;
                    }
                }

                autocycle = true;
                await Connect();
                StateHasChanged();
            }
            else
            {
                NavigationManager!.NavigateTo("/login");
            }

        }
        private async Task Connect()
        {
            //string token = await LocalStorageExtension.ApiToken(LocalStorageService!);
            //if (token != null)
            //{
            //hubConnection = new HubConnectionBuilder()
            //.WithUrl(NavigationManager!.ToAbsoluteUri("/dashboarddailyincomehub"), options =>
            //{
            //    //options.AccessTokenProvider = token;
            //    options.AccessTokenProvider = () => Task.FromResult(token)!;
            //})
            //.Build();
            //hubConnection.On<decimal, short>("NewDailyIncome", (Income, Count) =>
            //{
            //    StateHasChanged();
            //});
            //await hubConnection.StartAsync();
            //}


            hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager!.ToAbsoluteUri("/dashboarddailyincomehub"))
            .Build();

            hubConnection.On<decimal, short>("NewDailyIncome", (Income, Count) =>
            {
                dailyIncome = Income;
                dailyIncomeCount = Count;
                StateHasChanged();
            });

            await hubConnection.StartAsync();

        }

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        public async Task Show()
        {
            dailyIncome = 125;
            dailyIncomeCount = 5;
            if (hubConnection != null)
            {
                await hubConnection.SendAsync("RefreshIncome", dailyIncome, dailyIncomeCount);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null) await hubConnection.DisposeAsync();
        }

    }
}
