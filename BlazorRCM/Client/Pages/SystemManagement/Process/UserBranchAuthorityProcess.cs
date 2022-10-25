using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using BlazorRCM.Client.Utils;
using System.Dynamic;
using BlazorRCM.Shared.ResponseModels;
using RCMServerData.EFContext;
using RCMServerData.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BlazorRCM.Client.Pages.SystemManagement.Process
{
    public class UserBranchAuthorityListProcess : ComponentBase
    {
        [Inject]
        public HttpClient? Client { get; set; }

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]
        SweetAlertService? Swal { get; set; }

        protected List<BranchDTO> BranchList = new();
        protected List<AuthorityTypeDTO> AuthorityTypeList = new();
        protected List<UserDTO> UserList = new();
        protected List<UserBranchAuthorityDTO> UserBranchAuthorityList = new();
        
        protected List<ExpandoObject> UBA { get; set; } = new List<ExpandoObject>();
        

        protected bool _elementIsLoading = true;
        protected SfGrid<UserBranchAuthorityDTO>? Grid;
        protected DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "750px" };
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        
        protected async override Task OnInitializedAsync()
        {
            
            await LoadList();

            //UBA=Enumerable.Range(1, UserBranchAuthorityList.Count).Select((x) =>
            //{
            //    dynamic d = new ExpandoObject();
            //    //dynamic ubaDTO = new ExpandoObject();
            //    //dynamic userList = new ExpandoObject();
            //    //dynamic branchList = new ExpandoObject();
            //    //dynamic authorityList = new ExpandoObject();
            //    d.FullName = UserBranchAuthorityList[x].UserFullName;
            //    d.BranchName= UserBranchAuthorityList[x].BranchName;
            //    d.AuthorityType= UserBranchAuthorityList[x].AuthorityType;
            //    //d.UserList= UserList;
            //    //d.BranchList= BranchList;
            //    //d.AuthorityList = AuthorityTypeList;
            //    return d;
            //}).Cast<ExpandoObject>().ToList<ExpandoObject>();
        }

        protected async Task LoadList()
        {
            try
            {
                FiltersAndIncludesModel<UserBranchAuthorityDTO> model = new();
                //model.filter = null;
                model.filter = "x => x.ATId < 4";
                model.includeList=null;
                //model.includeList=new string[]{ "User", "Branch", "AuthorityType" };
                //string[] includeList = {"UserDTO","BranchDTO","AuthorityTypeDTO"}

                UserBranchAuthorityList = await Client!.GetServiceResponseAsync<List<UserBranchAuthorityDTO>>("api/UserBranchAuthority/GetList", true);

                //UserBranchAuthorityList = await Client!.PostGetServiceResponseAsync<List<UserBranchAuthorityDTO>, FiltersAndIncludesModel<UserBranchAuthorityDTO>>("api/UserBranchAuthority/UserBranchAuthorities", model, true);

                UserList = await Client!.GetServiceResponseAsync<List<UserDTO>>("api/User/GetList", true);
                BranchList = await Client!.GetServiceResponseAsync<List<BranchDTO>>("api/Branch/GetList", true);
                AuthorityTypeList = await Client!.GetServiceResponseAsync<List<AuthorityTypeDTO>>("api/AuthorityType/GetList", true);
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

        public async Task ActionBeginHandler(ActionEventArgs<UserBranchAuthorityDTO> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                UserBranchAuthorityDTO newdto = args.Data;
                if (args.Action == "Add")
                {
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<UserBranchAuthorityDTO, UserBranchAuthorityDTO>("api/UserBranchAuthority/Create", newdto, true);


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
                        
                        newdto = await Client!.PostGetServiceResponseAsync<UserBranchAuthorityDTO, UserBranchAuthorityDTO>("api/UserBranchAuthority/UpdateUBA", newdto, true);
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
                    UserBranchAuthorityDTO dto = args.Data;
                    if (dto == null) await Swal.FireAsync(null, "Silmek için kayıt seçmelisiniz!", "danger");
                    else
                    {
                        try
                        {
                            bool deleted = await Client!.PostGetServiceResponseAsync<bool, UserBranchAuthorityDTO>("api/UserBranchAuthority/Delete", dto, true);

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
        public async Task ActionCompleteHandler(ActionEventArgs<UserBranchAuthorityDTO> args)
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

            SyncfusionExportation<UserBranchAuthorityDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
        }
        //public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<UserBranchAuthorityDTO> args)
        //{
        //    if (args.Column.Field == "IsActive")
        //    {
        //        if (args.Data.IsActive == true)
        //            args.Cell.Value = "Aktif";
        //        else args.Cell.Value = "Pasif";
        //    }
        //}
        //public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<UserBranchAuthorityDTO> args)
        //{
        //    if (args.Column.Field == "IsActive")
        //    {
        //        if (args.Data.IsActive == true)
        //            args.Cell.Value = "Aktif";
        //        else args.Cell.Value = "Pasif";
        //    }
        //}

    }
}
