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
    public class BranchListProcess : ComponentBase
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

        protected bool _elementIsLoading = true;
        protected SfGrid<BranchDTO>? Grid;
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
                BranchList = await Client!.GetServiceResponseAsync<List<BranchDTO>>("api/ManageBranch/GetList", true);
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
        public async Task ActionBeginHandler(ActionEventArgs<BranchDTO> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                BranchDTO newdto = args.Data;
                newdto.ModifiedTime = DateTime.Now;

                if (args.Action == "Add")
                {
                    newdto.CreatedTime = DateTime.Now;
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<BranchDTO, BranchDTO>("api/ManageBranch/Create", newdto, true);
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
                        newdto = await Client!.PostGetServiceResponseAsync<BranchDTO, BranchDTO>("api/ManageBranch/Update", newdto, true);
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
                    BranchDTO dto = args.Data;
                    if (dto == null) await Swal.FireAsync(null, "Silmek için kayıt seçmelisiniz!", "danger");
                    else
                    {
                        try
                        {
                            bool deleted = await Client!.PostGetServiceResponseAsync<bool, BranchDTO>("api/ManageBranch/Delete", dto, true);
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
        public async Task ActionCompleteHandler(ActionEventArgs<BranchDTO> args)
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
            SyncfusionExportation<BranchDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
        }
        public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<BranchDTO> args)
        {
            if (args.Column.Field == "IsActive")
            {
                if (args.Data.IsActive == true)
                    args.Cell.Value = "Aktif";
                else args.Cell.Value = "Pasif";
            }
        }
        public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<BranchDTO> args)
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
