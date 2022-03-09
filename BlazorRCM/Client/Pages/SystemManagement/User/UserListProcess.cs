using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorRCM.Client.Pages.SystemManagement.User
{
    public class UserListProcess: ComponentBase
    {
        [Inject]
        public HttpClient? Client { get; set; }

        protected List<UserDTO> UserList = new List<UserDTO>();


        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }

        protected async Task LoadList()
        {
            var serviceResponse = await Client.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/ManageUser/users");

            if (serviceResponse.Success)
                UserList = serviceResponse.Value;
        }
    }
}
