using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using BlazorRCM.Client.Utils;
using Newtonsoft.Json;
using FluentValidation;
using BlazorRCM.Shared.ValidationRules.FluentValidation.DTOs.ModelDTOs;
using BlazorRCM.Shared.Utils;

namespace BlazorRCM.Client.Pages.SystemManagement.Process
{
    public class UserListProcess : ComponentBase
    {
        
        [Inject]
        public HttpClient? Client { get; set; }

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]
        SweetAlertService? Swal { get; set; }

        //UserDTOValidator validator=new();

        //protected AddNewUserDTO AddNewUserDTO = new();
        //protected List<BranchDTO> BranchList = new();
        //protected List<AuthorityTypeDTO> AuthorityTypeList = new();
        protected List<UserDTO> UserList = new();


        protected bool _elementIsLoading = true;
        protected SfGrid<UserDTO>? Grid;
        protected DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "750px" };
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        //public List<ExpandoObject> Users { get; set; } = new List<ExpandoObject>();
        protected async override Task OnInitializedAsync()
        {

            await LoadList();

            //AddNewUserDTO.UserDTOList = UserList;
            //AddNewUserDTO.BranchDTOList = BranchList;
            //AddNewUserDTO.AuthorityTypeDTOList = AuthorityTypeList;

            //Users = Enumerable.Range(1, UserList.Count()).Select((x) => 
            //{
            //    dynamic d = new ExpandoObject();
            //    dynamic user = new ExpandoObject();
            //    dynamic branch = new ExpandoObject();
            //    dynamic authorityType = new ExpandoObject();

                
            //    return d;
            //}).Cast<ExpandoObject>().ToList<ExpandoObject>();



            //await JSRuntime!.InvokeAsync<object>("TestDataTablesAdd", ".mud-table-root");

            //StateHasChanged();
        }

        protected async Task LoadList()
        {
            try
            {
                //await Task.Delay(2000);

                UserList = await Client!.GetServiceResponseAsync<List<UserDTO>>("api/User/GetList", true);
                //BranchList = await Client!.GetServiceResponseAsync<List<BranchDTO>>("api/ManageBranch/Branches", true);
                //AuthorityTypeList = await Client!.GetServiceResponseAsync<List<AuthorityTypeDTO>>("api/ManageAuthorityType/AuthorityTypes", true);

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

        public async Task ActionBeginHandler(ActionEventArgs<UserDTO> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {

                UserDTO newdto = args.Data;
                //var validatorResult = validator.Validate(newdto);
                //if (validatorResult.IsValid) { }
                //else { }
                    if (args.Action == "Add")
                {
                    newdto.Password= PasswordEncrypter.Encrypt(newdto.Password!);
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<UserDTO, UserDTO>("api/User/Create", newdto, true);


                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Swal!.FireAsync("Başarılı", "Kayıt başarıyla oluşturuldu", "success");
                        await LoadList();
                    }
                    catch (ApiException ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Swal!.FireAsync("Api Exception", ex.Message, "error");
                    }
                    catch (Exception ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Swal!.FireAsync("Exception", ex.Message, "error");
                    }
                    finally
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                    }
                }
                else
                {
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<UserDTO, UserDTO>("api/User/Update", newdto, true);
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Swal!.FireAsync("Başarılı", "Kayıt başarıyla güncellendi", "success");
                        await LoadList();
                    }
                    catch (ApiException ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Swal!.FireAsync("Api Exception", ex.Message, "error");
                    }
                    catch (Exception ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Swal!.FireAsync("Exception", ex.Message, "error");
                    }
                    finally
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
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
                    UserDTO dto = args.Data;
                    if (dto == null) await Swal.FireAsync(null, "Silmek için kayıt seçmelisiniz!", "danger");
                    else
                    {
                        try
                        {
                            bool deleted = await Client!.PostGetServiceResponseAsync<bool, UserDTO>("api/User/Delete", dto, true);

                            args.Cancel = true;
                            await Grid!.CloseEditAsync();
                            await Swal!.FireAsync(
                                              "İşlem başarılı",
                                              "Kayıt silindi",
                                              SweetAlertIcon.Success
                                              );
                            await LoadList();
                        }
                        catch (ApiException ex)
                        {
                            args.Cancel = true;
                            await Grid!.CloseEditAsync();
                            await Swal!.FireAsync("Api Exception", ex.Message, "error");
                        }
                        catch (Exception ex)
                        {
                            args.Cancel = true;
                            await Grid!.CloseEditAsync();
                            await Swal!.FireAsync("Exception", ex.Message, "error");
                        }
                        finally
                        {
                            args.Cancel = true;
                            await Grid!.CloseEditAsync();
                        }
                    }
                }
                else if (result.Dismiss == DismissReason.Cancel)
                {
                    args.Cancel = true;
                    await Grid!.CloseEditAsync();
                }
            }
        }
        public async Task ActionCompleteHandler(ActionEventArgs<UserDTO> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                //if (args.Action == "Add") await Swal!.FireAsync("Başarılı", "Yeni kayıt başarıyla oluşturuldu", "success");
                //else await Swal!.FireAsync("Başarılı", "Kayıt başarıyla güncelleştirildi", "success");

                args.Cancel = true;
                await Grid!.CloseEditAsync();
                //await LoadList();
            }

            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
            {
                args.Cancel = true;
                await Grid!.CloseEditAsync();
                //await Swal!.FireAsync(
                //                  "İşlem başarılı",
                //                  "Kayıt başarıyla silindi",
                //                  SweetAlertIcon.Success
                //                  );
            }
        }
        public async Task ActionFailureHandler(FailureEventArgs args)
        {
            var s = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(args.Error));  //get details 
            await Swal!.FireAsync("??", "Tabloda bilinmeyen bir hata oluştu", "error");
            await LoadList();
        }
        public async Task ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {

            SyncfusionExportation<UserDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
        }
        public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<UserDTO> args)
        {
            if (args.Column.Field == "IsActive")
            {
                if (args.Data.IsActive == true)
                    args.Cell.Value = "Aktif";
                else args.Cell.Value = "Pasif";
            }
        }
        public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<UserDTO> args)
        {
            if (args.Column.Field == "IsActive")
            {
                if (args.Data.IsActive == true)
                    args.Cell.Value = "Aktif";
                else args.Cell.Value = "Pasif";
            }
        }
    }
}
