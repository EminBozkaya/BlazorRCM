using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using BlazorRCM.Client.Utils;
using BlazorRCM.Shared.ResponseModels;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace BlazorRCM.Client.Pages.SystemManagement.Process
{
    public class AuthorityTypeListProcess : ComponentBase
    {
        [Inject]
        public HttpClient? Client { get; set; }

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]
        SweetAlertService? Swal { get; set; }

        protected List<AuthorityTypeDTO> AuthorityTypeList = new();

        protected bool _elementIsLoading = true;
        protected SfGrid<AuthorityTypeDTO>? Grid;
        protected DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "750px" };
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }

        protected async Task LoadList()
        {
            try
            {
                FiltersAndIncludesModel<AuthorityTypeDTO> model = new();
                model.filter = "x => x.ATId<4";
                model.includeList = null;
                string[] includeList = { "UserDTO", "BranchDTO", "AuthorityTypeDTO" };
                //AuthorityTypeList = await Client!.PostGetServiceResponseAsync<List<AuthorityTypeDTO>>("api/ManageAuthorityType/AuthorityTypes", true);

                Expression <Func<AuthorityTypeDTO, bool>> filter=x => x.ATId<4;


                //AuthorityTypeList = (await Client!.GetFromJsonAsync<List<AuthorityTypeDTO>>("api/ManageAuthorityType/AuthorityTypes"))!;
                //AuthorityTypeList = response;
                //string deneme = "hey";

                //var response = await Client!.PostAsJsonAsync("api/ManageAuthorityType/AuthorityTypess", includeList);

                //var value = await response.Content.ReadFromJsonAsync<List<AuthorityTypeDTO>>();
                //AuthorityTypeList = value;

                //AuthorityTypeList = await response.Content.ReadFromJsonAsync<List<AuthorityTypeDTO>>();

                //AuthorityTypeList = await Client!.PostGetBaseResponseAsync<AuthorityTypeDTO>("api/ManageAuthorityType/AuthorityTypes", model, true);


                AuthorityTypeList = await Client!.GetServiceResponseAsync<List<AuthorityTypeDTO>>("api/ManageAuthorityType/GetList", true);
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

        public async Task ActionBeginHandler(ActionEventArgs<AuthorityTypeDTO> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                AuthorityTypeDTO newdto = args.Data;
                //newdto.Type = null;
                if (args.Action == "Add")
                {
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<AuthorityTypeDTO, AuthorityTypeDTO>("api/ManageAuthorityType/Create", newdto, true);
                    }
                    catch (ApiException ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEdit();
                        await Swal!.FireAsync("Api Exception", ex.Message, "error");
                    }
                    catch (Exception ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEdit();
                        await Swal!.FireAsync("Exception", ex.Message, "error");
                    }
                }
                else
                {
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<AuthorityTypeDTO, AuthorityTypeDTO>("api/ManageAuthorityType/Update", newdto, true);
                    }
                    catch (ApiException ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEdit();
                        await Swal!.FireAsync("Api Exception", ex.Message, "error");
                    }
                    catch (Exception ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEdit();
                        await Swal!.FireAsync("Exception", ex.Message, "error");
                    }
                }
            }
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
            {
                SweetAlertResult result = await Swal!.FireAsync(new SweetAlertOptions
                {
                    Title = "DİKKAT",
                    Text = "Emin misiniz, Sildiğiniz takdirde işlemi geri alamazsınız!",
                    Icon = SweetAlertIcon.Warning,
                    ShowCancelButton = true,
                    ConfirmButtonColor = "#3085d6",
                    CancelButtonColor = "#d33",
                    ConfirmButtonText = "Evet sil!",
                    CancelButtonText = "Vazgeç"
                });

                if (!string.IsNullOrEmpty(result.Value))
                {
                    AuthorityTypeDTO dto = args.Data;
                    if (dto == null) await Swal.FireAsync(null, "Silmek için kayıt seçmelisiniz!", "danger");
                    else
                    {
                        try
                        {
                            bool deleted = await Client!.PostGetServiceResponseAsync<bool, AuthorityTypeDTO>("api/ManageAuthorityType/Delete", dto, true);
                        }
                        catch (ApiException ex)
                        {
                            args.Cancel = true;
                            await Grid!.CloseEdit();
                            await Swal!.FireAsync("Api Exception", ex.Message, "error");
                        }
                        catch (Exception ex)
                        {
                            args.Cancel = true;
                            await Grid!.CloseEdit();
                            await Swal!.FireAsync("Exception", ex.Message, "error");
                        }
                    }
                }
                else if (result.Dismiss == DismissReason.Cancel)
                {
                    args.Cancel = true;
                }
            }
        }
        public async Task ActionCompleteHandler(ActionEventArgs<AuthorityTypeDTO> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                if (args.Action == "Add") await Swal!.FireAsync("Başarılı", "Yeni kayıt başarıyla oluşturuldu", "success");
                else await Swal!.FireAsync("Başarılı", "Kayıt başarıyla güncelleştirildi", "success");

                args.Cancel = true;
                await Grid!.CloseEdit();
                await LoadList();
            }

            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
            {
                args.Cancel = true;
                await Grid!.CloseEdit();
                await Swal!.FireAsync(
                                  "İşlem başarılı",
                                  "Kayıt başarıyla silindi",
                                  SweetAlertIcon.Success
                                  );
            }
        }

        public async Task ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            SyncfusionExportation<AuthorityTypeDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
        }
        
    }
}
