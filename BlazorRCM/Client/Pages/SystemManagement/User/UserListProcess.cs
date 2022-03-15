using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;

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
        
        [Inject]
        public SweetAlertService? Sw { get; set; }



        protected async override Task OnInitializedAsync()
        {
            
            await LoadList();

            //StateHasChanged();
        }

        protected async Task LoadList()
        {
            try
            {
                await Task.Delay(2000);

                UserList = await Client!.GetServiceResponseAsync<List<UserDTO>>("api/ManageUser/users", true);

            }
            catch (ApiException ex)
            {
                await Sw!.FireAsync("Api Exception", ex.Message, "error");
            }
            catch (Exception ex)
            {
                await Sw!.FireAsync("Exception", ex.Message, "error");

            }
            finally
            {
                _elementIsLoading = false;
                StateHasChanged();
            }

            
        }

        
    }
}
