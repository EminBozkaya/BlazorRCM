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

        protected List<UserDTO> UserList = new ();
        //protected bool _processing = true;
        //protected string visibility = "invisible";
        protected bool _elementIsLoading = true;
        



        protected async override Task OnInitializedAsync()
        {
            
            await LoadList();

            //StateHasChanged();
        }

        protected async Task LoadList()
        {
            try
            {
               

                
                await Task.Delay(3000);

                var serviceResponse = await Client!.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/ManageUser/users");

                if (serviceResponse!.Success)
                    UserList = serviceResponse.Value!;
            }
            catch (Exception ex)
            {
                throw new Exception("kayıt yok" + ex.Message);
            }
            finally
            {
                _elementIsLoading = false;
                StateHasChanged();
            }

            
        }

        
    }
}
