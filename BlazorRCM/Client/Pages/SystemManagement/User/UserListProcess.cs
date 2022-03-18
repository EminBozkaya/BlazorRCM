using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;

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

        [Inject]
        IJSRuntime? JSRuntime { get; set; }


        [Inject]
        SweetAlertService? Swal { get; set; }

        protected async override Task OnInitializedAsync()
        {
            
            await LoadList();
            //await JSRuntime!.InvokeAsync<object>("TestDataTablesAdd", ".mud-table-root");

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

        public async Task ActionBegin(ActionEventArgs<UserDTO> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                UserDTO newdto = args.Data;
                try
                {
                    await Task.Delay(2000);
                    newdto = await Client!.PostGetServiceResponseAsync<UserDTO, UserDTO>("api/ManageUser/Create", newdto, true);
                    await Swal!.FireAsync("Başarılı", "Yeni kayıt başarıyla oluşturuldu", "success");
                }
                catch (ApiException ex)
                {
                    await Swal!.FireAsync("Api Exception", ex.Message, "error");
                }
                catch (Exception ex)
                {
                    await Swal!.FireAsync("Exception", ex.Message, "error");
                }


                //from here you can call the AddMethod of you database.            
                // UserBuildingRepository.AddUserBuilding(args.Data);



                //args.Cancel = true;
                //await Grid!.CloseEdit(); // cancel the editing
            }
            else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
            {

                if(args.Data.UserName=="no")
                args.Cancel = true;
                //UserBuildingRepository.RemoveUserBuilding(args.Data);
            }
        }
    }
}
