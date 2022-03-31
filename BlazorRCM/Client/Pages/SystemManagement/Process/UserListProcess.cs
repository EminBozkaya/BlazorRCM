using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using BlazorRCM.Client.Utils;

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

                UserList = await Client!.GetServiceResponseAsync<List<UserDTO>>("api/ManageUser/GetList", true);
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
            //if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit || args.RequestType == Syncfusion.Blazor.Grids.Action.Add)
            //{
            //    await Grid!.ShowColumns("Statü");
            //}

            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                UserDTO newdto = args.Data;
                newdto.ModifiedTime = DateTime.Now;

                if (newdto.Phone!.Length == 10) newdto.Phone = "90" + newdto.Phone;
                if (newdto.Phone!.Length == 11) newdto.Phone = "9" + newdto.Phone;

                if (args.Action == "Add")
                {
                    newdto.CreatedTime = DateTime.Now;
                    try
                    {
                        
                        newdto = await Client!.PostGetServiceResponseAsync<UserDTO, UserDTO>("api/ManageUser/Create", newdto, true);
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
                        newdto = await Client!.PostGetServiceResponseAsync<UserDTO, UserDTO>("api/ManageUser/Update", newdto, true);
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
                    ConfirmButtonColor= "#3085d6",
                    CancelButtonColor= "#d33",
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
                            bool deleted = await Client!.PostGetServiceResponseAsync<bool, UserDTO>("api/ManageUser/Delete", dto, true);
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

        public async Task ActionCompleteHandler(ActionEventArgs<UserDTO> args)
        {
            

            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                if (args.Action == "Add") await Swal!.FireAsync("Başarılı", "Yeni kayıt başarıyla oluşturuldu", "success");
                else await Swal!.FireAsync("Başarılı", "Kayıt başarıyla güncelleştirildi", "success");

                //await Grid!.HideColumns("Statü");
                args.Cancel = true;
                await Grid!.CloseEdit();
                await LoadList();
            }

            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
            {
                //await Grid!.HideColumns("Statü");
                args.Cancel = true;
                await Grid!.CloseEdit();
                await Swal!.FireAsync(
                                  "İşlem başarılı",
                                  "Kayıt başarıyla silindi",
                                  SweetAlertIcon.Success
                                  );
            }

            //if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Cancel)) await Grid!.HideColumns("Statü");

        }

        public async Task ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            
            SyncfusionExportation<UserDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
        }

        //public void OnCommandClicked(CommandClickEventArgs<UserDTO> args)
        //{
        //    if (args.CommandColumn.Type == CommandButtonType.Edit)
        //    {
        //        //show your edit dialog here while clicking command buttons to perform edit operation 
        //    }
        //}
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
