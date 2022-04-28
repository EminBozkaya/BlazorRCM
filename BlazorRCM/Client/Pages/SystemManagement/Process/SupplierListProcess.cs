using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using BlazorRCM.Client.Utils;
using Newtonsoft.Json;

namespace BlazorRCM.Client.Pages.SystemManagement.Process
{
    public class SupplierListProcess : ComponentBase
    {
        
        [Inject]
        public HttpClient? Client { get; set; }

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]
        SweetAlertService? Swal { get; set; }


        //protected AddNewSupplierDTO AddNewSupplierDTO = new();
        //protected List<BranchDTO> BranchList = new();
        //protected List<AuthorityTypeDTO> AuthorityTypeList = new();
        protected List<SupplierDTO> SupplierList = new();


        protected bool _elementIsLoading = true;
        protected SfGrid<SupplierDTO>? Grid;
        protected DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "750px" };
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        //public List<ExpandoObject> Suppliers { get; set; } = new List<ExpandoObject>();
        protected async override Task OnInitializedAsync()
        {

            await LoadList();

            //AddNewSupplierDTO.SupplierDTOList = SupplierList;
            //AddNewSupplierDTO.BranchDTOList = BranchList;
            //AddNewSupplierDTO.AuthorityTypeDTOList = AuthorityTypeList;

            //Suppliers = Enumerable.Range(1, SupplierList.Count()).Select((x) => 
            //{
            //    dynamic d = new ExpandoObject();
            //    dynamic Supplier = new ExpandoObject();
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

                SupplierList = await Client!.GetServiceResponseAsync<List<SupplierDTO>>("api/Supplier/GetList", true);
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

        public async Task ActionBeginHandler(ActionEventArgs<SupplierDTO> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                SupplierDTO newdto = args.Data;
                if (args.Action == "Add")
                {
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<SupplierDTO, SupplierDTO>("api/Supplier/Create", newdto, true);


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
                        newdto = await Client!.PostGetServiceResponseAsync<SupplierDTO, SupplierDTO>("api/Supplier/Update", newdto, true);
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
                    SupplierDTO dto = args.Data;
                    if (dto == null) await Swal.FireAsync(null, "Silmek için kayıt seçmelisiniz!", "danger");
                    else
                    {
                        try
                        {
                            bool deleted = await Client!.PostGetServiceResponseAsync<bool, SupplierDTO>("api/Supplier/Delete", dto, true);

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
        public async Task ActionCompleteHandler(ActionEventArgs<SupplierDTO> args)
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
            
            SyncfusionExportation<SupplierDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
        }
        public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<SupplierDTO> args)
        {
            if (args.Column.Field == "IsActive")
            {
                if (args.Data.IsActive == true)
                    args.Cell.Value = "Aktif";
                else args.Cell.Value = "Pasif";
            }
        }
        public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<SupplierDTO> args)
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
