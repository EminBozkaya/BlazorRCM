using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using BlazorRCM.Client.Utils;
using Newtonsoft.Json;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.DTOs.ViewDTOs;
using BlazorRCM.Shared.DTOs.TupleDTOs;
using Blazored.LocalStorage;

namespace BlazorRCM.Client.Pages.BillLists
{
    public partial class GeneralBillList
    {
        [Inject]
        public HttpClient? Client { get; set; }

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]
        NavigationManager? NavigationManager { get; set; }

        [Inject]
        ILocalStorageService? LocalStorageService { get; set; }

        protected List<SaleDTO> SaleList = new();
        protected List<InStoreSaleBillDTO> billDTOList = new();

        private IJSObjectReference? _jsPrintModule;
        protected bool _elementIsLoading = true;
        protected SfGrid<SaleDTO>? Grid;
        protected DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "750px" };
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        protected decimal totalPrice = 0;
        protected decimal billTotalPrice = 0;
        protected bool firstClicked;
        protected int saleId;
        protected DateTime saleTime;
        protected async override Task OnInitializedAsync()
        {
            await LoadList();
            _jsPrintModule = await JSRuntime!.InvokeAsync<IJSObjectReference>("import", "./MyScripts/printDisplay.js");
            //_jsInStoreSalePrintModule = await IJSInStoreSale!.InvokeAsync<IJSObjectReference>("import", "./MyScripts/PrintInStoreSaleBill.js");
        }
        protected async Task LoadList()
        {
            try
            {
                SaleList = await Client!.GetServiceResponseAsync<List<SaleDTO>>("api/Sale/GetListOfToday", true);
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
        protected async Task GetListOfDate()
        {
            SaleList = await Client!.GetServiceResponseAsync<List<SaleDTO>>("api/Sale/GetListOfToday", true);
        }
        protected async Task GetListOfDateRange()
        {
            SaleList = await Client!.GetServiceResponseAsync<List<SaleDTO>>("api/Sale/GetListOfToday", true);
        }
        public async Task RowSelectHandler(RowSelectEventArgs<SaleDTO> args)
        {

            billDTOList = new();
            saleId = args.Data.Id;
            saleTime = args.Data.DateTime;

            List<SaleDetailDTO> saleDetailDTOList = new();
            saleDetailDTOList = await Client!.PostGetServiceResponseAsync<List<SaleDetailDTO>, int>("api/SaleDetail/GetListBySaleId", saleId, true);

            foreach (SaleDetailDTO detail in saleDetailDTOList)
            {
                InStoreSaleBillDTO newDTO = new();
                ProductNoteModalResultDTO resultDTO = new();

                newDTO.GuId = Guid.NewGuid();
                newDTO.PId = detail.PId;
                newDTO.ProductName = detail.ProductName;
                newDTO.ProductPrice = detail.Price;
                newDTO.Quantity = detail.Qty;
                newDTO.Portion = detail.Portion;
                newDTO.TotalPrice = detail.Total;

                if (detail.generalProductNote != null)
                    resultDTO.generalProductNote = detail.generalProductNote;
                if (detail.firstProductNote != null)
                    resultDTO.firstProductNote = detail.firstProductNote;
                if (detail.secondProductNote != null)
                    resultDTO.secondProductNote = detail.secondProductNote;
                if (detail.thirdProductNote != null)
                    resultDTO.thirdProductNote = detail.thirdProductNote;


                if (detail.generalProductNote != null || detail.firstProductNote != null || detail.secondProductNote != null || detail.thirdProductNote != null)
                    newDTO.HasNote = true;
                else
                    newDTO.HasNote = false;

                newDTO.ResultDTO = resultDTO;

                billDTOList.Add(newDTO);
            }
            billTotalPrice = args.Data.TotalPrice;

            if (!firstClicked)
                await _jsPrintModule!.InvokeVoidAsync("setPrintElementDisplay", "block");

            firstClicked = true;
        }
        public async Task PassBilltoChangeBillPage()
        {
            PassBillDataToChangeBillPageDTO data = new();
            data.SaleID = saleId;
            data.SaleTime = saleTime;
            data.BillTotalPrice = billTotalPrice;
            data.InStoreSaleBillDTOList = billDTOList;
            await LocalStorageService!.SetItemAsync<PassBillDataToChangeBillPageDTO>("billDataForChange", data);
            NavigationManager!.NavigateTo("/changeBill/" + saleId);
        }
        public async Task ActionBeginHandler(ActionEventArgs<SaleDTO> args)
        {
            if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
            {
                SaleDTO newdto = args.Data;
                if (args.Action == "Add")
                {
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<SaleDTO, SaleDTO>("api/Sale/Create", newdto, true);


                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Sw!.FireAsync("Başarılı", "Kayıt başarıyla oluşturuldu", "success");
                        await LoadList();
                    }
                    catch (ApiException ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Sw!.FireAsync("Api Exception", ex.Message, "error");
                    }
                    catch (Exception ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Sw!.FireAsync("Exception", ex.Message, "error");
                    }
                }
                else
                {
                    try
                    {
                        newdto = await Client!.PostGetServiceResponseAsync<SaleDTO, SaleDTO>("api/Sale/Update", newdto, true);
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Sw!.FireAsync("Başarılı", "Kayıt başarıyla güncellendi", "success");
                        await LoadList();
                    }
                    catch (ApiException ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Sw!.FireAsync("Api Exception", ex.Message, "error");
                    }
                    catch (Exception ex)
                    {
                        args.Cancel = true;
                        await Grid!.CloseEditAsync();
                        await Sw!.FireAsync("Exception", ex.Message, "error");
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
                SweetAlertResult result = await Sw!.FireAsync(new SweetAlertOptions
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
                    SaleDTO dto = args.Data;
                    if (dto == null) await Sw.FireAsync(null, "Silmek için kayıt seçmelisiniz!", "danger");
                    else
                    {
                        try
                        {
                            bool deleted = await Client!.PostGetServiceResponseAsync<bool, SaleDTO>("api/Sale/Delete", dto, true);

                            var res = await Client!.PostGetBaseResponseAsync("api/SaleDetail/DeleteById", args.Data.Id, true);

                            await _jsPrintModule!.InvokeVoidAsync("setPrintElementDisplay", "none");
                            firstClicked = false;

                            await LocalStorageService!.SetItemAsync<PassBillDataToChangeBillPageDTO>("billDataForChange", new());

                            args.Cancel = true;
                            await Grid!.CloseEditAsync();
                            await Sw!.FireAsync(
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
                            await Sw!.FireAsync("Api Exception", ex.Message, "error");
                        }
                        catch (Exception ex)
                        {
                            args.Cancel = true;
                            await Grid!.CloseEditAsync();
                            await Sw!.FireAsync("Exception", ex.Message, "error");
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
        public async Task ActionCompleteHandler(ActionEventArgs<SaleDTO> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                //if (args.Action == "Add") await Sw!.FireAsync("Başarılı", "Yeni kayıt başarıyla oluşturuldu", "success");
                //else await Sw!.FireAsync("Başarılı", "Kayıt başarıyla güncelleştirildi", "success");

                args.Cancel = true;
                await Grid!.CloseEditAsync();
                //await LoadList();
            }

            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
            {
                args.Cancel = true;
                await Grid!.CloseEditAsync();
                //await Sw!.FireAsync(
                //                  "İşlem başarılı",
                //                  "Kayıt başarıyla silindi",
                //                  SweetAlertIcon.Success
                //                  );
            }
        }
        public async Task ActionFailureHandler(FailureEventArgs args)
        {
            var s = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(args.Error));  //get details 
            await Sw!.FireAsync("??", "Tabloda bilinmeyen bir hata oluştu", "error");
            await LoadList();
        }
        public async Task ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            SyncfusionExportation<SaleDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
        }
        public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<SaleDTO> args)
        {
            if (args.Column.Field == "IsActive")
            {
                if (args.Data.IsActive == true)
                    args.Cell.Value = "Aktif";
                else args.Cell.Value = "Pasif";
            }
        }
        public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<SaleDTO> args)
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
