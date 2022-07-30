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
using BlazorRCM.Shared.DTOs.ViewDTOs;
using MudBlazor;
using BlazorRCM.Client.CustomComponents.ModalComponents;
using System.Globalization;
using Blazored.LocalStorage;
using System.Text;
using Append.Blazor.Printing;
using System.Drawing.Printing;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorRCM.Client.Pages.Sales.InStoreSales
{
    public partial class InStoreSale
    {
        [Inject]
        public IDialogService? DialogService { get; set; }

        [Inject]
        ILocalStorageService? LocalStorageService { get; set; }

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        public HttpClient? Client { get; set; }

        [CascadingParameter]
        public int IntValue { get; set; }

        [Inject]
        public IJSRuntime? _jsPrintRuntime { get; set; }

        [Inject]
        public IJSRuntime? IJS { get; set; }

        [Inject]
        public IJSRuntime? IJSInStoreSale { get; set; }

        [Inject]
        NavigationManager? NavigationManager { get; set; }

        private IJSObjectReference? _jsPrintModule;
        private IJSObjectReference? _jsInStoreSalePrintModule;

        protected List<BranchProductPriceDTO> BranchProductPriceList = new();
        protected List<BranchProductPriceDTO> FavList = new();
        protected List<BranchProductPriceDTO> FoodList = new();
        protected List<BranchProductPriceDTO> MenuList = new();
        protected List<BranchProductPriceDTO> DrinkList = new();
        protected List<BranchProductPriceDTO> OtherList = new();

        protected List<ProductSaleNoteDTO> ProductSaleNoteList = new();

        protected decimal totalPrice = 0;
        protected bool skipLastIndex = true;
        protected List<InStoreSaleBillDTO>? GridBillData = new();
        protected List<InStoreSaleBillDTO>? PrintGridBillData = null;
        protected string searchKey = @"\n";

        protected short ActiveBranchId;
        protected int ActiveUserId;

        protected bool _elementIsLoading = true;
        protected SfGrid<InStoreSaleBillDTO>? Grid;
        protected ActionEventArgs<InStoreSaleBillDTO>? Args;
        public static Guid Pkey { get; set; }

        protected bool setAggregate = true;
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        protected int billOrder;
        private HubConnection? hubConnection;
        
        private List<SaleDTO> SaleList = new();


        protected async override Task OnInitializedAsync()
        {
            await LoadList();
            await Connect();
            _jsPrintModule = await _jsPrintRuntime!.InvokeAsync<IJSObjectReference>("import", "./MyScripts/printDisplay.js");
            _jsInStoreSalePrintModule = await IJSInStoreSale!.InvokeAsync<IJSObjectReference>("import", "./MyScripts/PrintInStoreSaleBill.js");
            StateHasChanged();
        }
        protected async Task LoadList()
        {
            ActiveUserId = await LocalStorageExtension.GetActiveUserID(LocalStorageService!);
            ActiveBranchId = await LocalStorageExtension.GetActiveBranchID(LocalStorageService!);

            BranchProductPriceList = await LocalStorageExtension.BranchProductPriceList(LocalStorageService!);
            foreach (BranchProductPriceDTO item in BranchProductPriceList)
            {
                if (item.IsFavorite == true) FavList.Add(item);
                if (item.MenuListId == 1) FoodList.Add(item);
                if (item.MenuListId == 2) MenuList.Add(item);
                if (item.MenuListId == 3) DrinkList.Add(item);
                if (item.MenuListId == 4) OtherList.Add(item);
            }
            ProductSaleNoteList = await LocalStorageExtension.ProductSaleNoteList(LocalStorageService!);
            
            _elementIsLoading = false;
        }
        private async Task Connect()
        {
            //string token = await LocalStorageExtension.ApiToken(LocalStorageService!);
            //if (token != null)
            //{
            //hubConnection = new HubConnectionBuilder()
            //.WithUrl(NavigationManager!.ToAbsoluteUri("/dashboarddailyincomehub"), options =>
            //{
            //    //options.AccessTokenProvider = token;
            //    options.AccessTokenProvider = () => Task.FromResult(token)!;
            //})
            //.Build();
            //hubConnection.On<decimal, short>("NewDailyIncome", (Income, Count) =>
            //{
            //    StateHasChanged();
            //});
            //await hubConnection.StartAsync();
            //}

            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager!.ToAbsoluteUri("/dashboarddailyincomehub"))
                .Build();

            hubConnection.On<decimal, short>("NewDailyIncome", (Income, Count) =>
            {
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }
        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null) await hubConnection.DisposeAsync();
        }
        public void ActionBegin(ActionEventArgs<InStoreSaleBillDTO> args)
        {
            if ((args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save) && args.Action == "Add"))
            {
                args.Index = GridBillData!.Count();
                //args.Index = (Grid!.PageSettings.CurrentPage * Grid.PageSettings.PageSize) - 1;
            }
            if (args.RequestType.ToString() == "Save")
            {
                Pkey = args.Data.GuId;           //get primary key value of newly added record 
            }
        }
        public async Task AddToBill(BranchProductPriceDTO item)
        {
            InStoreSaleBillDTO dto = new();
            dto.GuId = Guid.NewGuid();
            dto.PId = item.PId;
            dto.Quantity = 1;
            dto.Portion = 1;
            dto.ProductPrice = decimal.Round((item.BranchPrice), 2, MidpointRounding.AwayFromZero);
            dto.ProductName = item.ProductName;
            dto.TotalPrice = decimal.Round((dto.ProductPrice * dto.Portion * dto.Quantity), 2, MidpointRounding.AwayFromZero);
            dto.ResultDTO = new ProductNoteModalResultDTO();

            await this.Grid!.AddRecord(dto);
            var Idx = this.Grid!.TotalItemCount - 1;
            await this.Grid.SelectRowAsync(Convert.ToDouble(Idx));
        }
        public void ClearBill()
        {
            setAggregate = false;
            GridBillData = new List<InStoreSaleBillDTO>();
            setAggregate = true;
        }
        public async Task RemoveFromBill()
        {
            var temp = await Grid!.GetSelectedRecordsAsync();

            if (temp.Count != 0)
            {
                await this.Grid!.DeleteRecordAsync();
                var Idx = this.Grid!.TotalItemCount - 1;
                await this.Grid.SelectRowAsync(Convert.ToDouble(Idx));
            }
        }
        public async Task ChangeQtyOfProduct(int q)
        {
            var temp = await Grid!.GetSelectedRecordsAsync();
            //double index = Grid.SelectedRowIndexes[0];
            if (temp.Count != 0)
            {
                skipLastIndex = false;
                var rowData = temp[0];

                if ((q == -2 && rowData.Quantity > 1) || q == 0)
                {
                    rowData.Quantity = Convert.ToInt16(rowData.Quantity + (q + 1));
                }
                if (q > 0)
                {
                    rowData.Quantity = Convert.ToInt16(q);
                }
                if (q == -1)
                {
                    DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium };
                    string? title = "Ürün Adeti Girin:";
                    var parameters = new DialogParameters();
                    parameters.Add("IntValue", Convert.ToInt32(rowData.Quantity));
                    parameters.Add("Max", 100);
                    parameters.Add("title", title);

                    var dialog = DialogService!.Show<BaseMudDialogNumeric>(title, parameters, closeOnEscapeKey);
                    var result = await dialog.Result;
                    if (!result.Cancelled)
                        rowData.Quantity = Convert.ToInt16(result.Data.ToString());
                }


                rowData.TotalPrice = decimal.Round((rowData.ProductPrice * rowData.Portion * rowData.Quantity), 2, MidpointRounding.AwayFromZero);
                double index = Grid.SelectedRowIndexes[0];
                await this.Grid.UpdateRow(index, rowData);
                await this.Grid.SelectRowAsync(index);
            }
        }
        public async Task SetProductNote()
        {
            var temp = await Grid!.GetSelectedRecordsAsync();

            if (temp.Count != 0)
            {
                var rowData = temp[0];
                //string product = rowData.ProductName!;
                //int qty = rowData.Quantity;
                ProductNoteModalResultDTO? resultDTO = rowData.ResultDTO;
                DialogOptions ProductNoteOptions = new DialogOptions() { CloseOnEscapeKey = true, FullScreen = true, CloseButton = true, NoHeader = true };
                var parameters = new DialogParameters();
                //parameters.Add("ProductSaleNoteList", ProductSaleNoteList);
                //parameters.Add("LittleList", LittleList);
                //parameters.Add("LotsOfList", LotsOfList);
                //parameters.Add("RemoveList", RemoveList);
                //parameters.Add("IncludeList", IncludeList);
                //parameters.Add("LavashList", LavashList);
                //parameters.Add("OtherNoteList", OtherNoteList);
                parameters.Add("productName", rowData.ProductName!);

                //parameters.Add("ResultDTO", rowData.ResultDTO);
                parameters.Add("generalProductNote", resultDTO!.generalProductNote);
                parameters.Add("firstProductNote", resultDTO!.firstProductNote);
                parameters.Add("secondProductNote", resultDTO!.secondProductNote);
                parameters.Add("thirdProductNote", resultDTO!.thirdProductNote);

                var dialog = DialogService!.Show<ProductNoteList>("Not Girin:", parameters, ProductNoteOptions);
                var result = await dialog.Result;
                if (!result.Cancelled)
                    rowData.ResultDTO = (result.Data) as ProductNoteModalResultDTO;

                if (rowData.ResultDTO!.generalProductNote != null || rowData.ResultDTO!.firstProductNote != null || rowData.ResultDTO!.secondProductNote != null || rowData.ResultDTO!.thirdProductNote != null)
                    rowData.HasNote = true;
                else
                    rowData.HasNote = false;

                double index = Grid.SelectedRowIndexes[0];
                await this.Grid.UpdateRow(index, rowData);
                await this.Grid.SelectRowAsync(index);
            }


        }
        public async Task ChangePrsOfProduct(decimal p)
        {
            var temp = await Grid!.GetSelectedRecordsAsync();
            //double index = Grid.SelectedRowIndexes[0];
            if (temp.Count != 0)
            {
                var rowData = temp[0];

                rowData.Portion = p;

                rowData.TotalPrice = decimal.Round((rowData.ProductPrice * rowData.Portion * Convert.ToDecimal(rowData.Quantity)), 2, MidpointRounding.AwayFromZero);
                double index = Grid.SelectedRowIndexes[0];
                await this.Grid.UpdateRow(index, rowData);
                await this.Grid.SelectRowAsync(index);
            }
        }
        public decimal GetTotalPrice()
        {
            decimal total = 0;
            decimal zero = 0;
            foreach (InStoreSaleBillDTO item in GridBillData!)
            {
                total = total + item.TotalPrice;
            }
            return setAggregate ? decimal.Round(total, 2, MidpointRounding.AwayFromZero) : zero;

        }

        public async Task SaveAndPrint()
        {
            if (GridBillData!.Count != 0)
            {
                PrintGridBillData = GridBillData;
                //DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
                //string? title = "Adisyon Onayı!";
                //var parameters = new DialogParameters();
                //parameters.Add("title", title);
                //parameters.Add("ContentText", "Adisyon sisteme kaydedilsin mi?");
                //var dialog = DialogService!.Show<BasicYesNoMudDialog>(title, parameters, closeOnEscapeKey);
                //var result = await dialog.Result;
                //if (!result.Cancelled)
                //{}

                SweetAlertResult result = await Sw!.FireAsync(new SweetAlertOptions
                {
                    Title = "Emin misiniz",
                    Text = "Adisyon sisteme kaydedilsin mi?",
                    Icon = SweetAlertIcon.Warning,
                    ShowCancelButton = true,
                    ConfirmButtonColor = "#3085d6",
                    CancelButtonColor = "#d33",
                    ConfirmButtonText = "Kaydet ve Yazdır",
                    CancelButtonText = "Vazgeç"
                });
                if (!string.IsNullOrEmpty(result.Value))
                {
                    await _jsPrintModule!.InvokeVoidAsync("setPrintElementDisplay", "block");

                    //await PrintingService!.Print("billPrintView", PrintType.Html);
                    //this.Grid!.Print();
                    //await Task.Delay(1000);

                    //await IJS!.InvokeAsync<object>("open", new object[] { "/BillPrint", "_blank" });

                    _jsInStoreSalePrintModule = await IJSInStoreSale!.InvokeAsync<IJSObjectReference>("import", "./MyScripts/PrintInStoreSaleBill.js");
                    await _jsInStoreSalePrintModule!.InvokeVoidAsync("print");

                    await _jsPrintModule!.InvokeVoidAsync("setPrintElementDisplay", "none");
                    PrintGridBillData = null;

                    //--------saving database---------
                    SaleDTO newSaleDTO = new();

                    newSaleDTO.BId = ActiveBranchId;
                    newSaleDTO.UId = ActiveUserId;
                    newSaleDTO.IsActive = true;
                    newSaleDTO.TotalPrice = totalPrice;
                    newSaleDTO.STId = 1;
                    newSaleDTO.ModifiedBy = 1;
                    newSaleDTO.DeletedBy = 1;
                    newSaleDTO.ModifiedTime = new DateTime(1,1,1);
                    newSaleDTO.DeletedTime = new DateTime(1,1,1);

                    try
                    {
                        newSaleDTO = await Client!.PostGetServiceResponseAsync<SaleDTO, SaleDTO>("api/Sale/Create", newSaleDTO, true);
                        billOrder = newSaleDTO.DailyBillOrder;
                    }
                    catch (ApiException ex)
                    {

                        await Sw!.FireAsync("Api Exception", "Adisyon Sisteme Kaydedilemedi: " + ex.Message, "error");
                    }
                    catch (Exception ex)
                    {

                        await Sw!.FireAsync("Exception", "Adisyon Sisteme Kaydedilemedi: " + ex.Message, "error");
                    }

                    try
                    {
                        short order = 0;
                        foreach (InStoreSaleBillDTO bill in GridBillData)
                        {
                            SaleDetailDTO dto = new();
                            dto.SId = newSaleDTO.Id;
                            dto.BillOrder = ++order;
                            dto.PId = bill.PId;
                            dto.ProductName = bill.ProductName;
                            dto.Price = bill.ProductPrice;
                            dto.Portion = bill.Portion;
                            dto.Qty = bill.Quantity;
                            dto.Total = bill.TotalPrice;
                            dto.IsActive = true;
                            dto.generalProductNote = bill.ResultDTO!.generalProductNote;
                            dto.firstProductNote = bill.ResultDTO.firstProductNote;
                            dto.secondProductNote = bill.ResultDTO.secondProductNote;
                            dto.thirdProductNote = bill.ResultDTO.thirdProductNote;

                            StringBuilder sb = new();

                            if (bill.ResultDTO!.generalProductNote != null && bill.ResultDTO.generalProductNote != "")
                            {
                                if (bill.ResultDTO!.generalProductNote.IndexOf("\n") != -1)
                                    sb.AppendLine("-" + bill.ResultDTO.generalProductNote.Trim().Replace("\n", ", "));
                                else
                                    sb.AppendLine("-" + bill.ResultDTO!.generalProductNote);
                            }
                            if (bill.ResultDTO!.firstProductNote != null && bill.ResultDTO.firstProductNote != "")
                            {
                                if (bill.ResultDTO!.firstProductNote.IndexOf("\n") != -1)
                                    sb.AppendLine("  1 x " + bill.ResultDTO.firstProductNote.Trim().Replace("\n", ", "));
                                else
                                    sb.AppendLine("  1 x " + bill.ResultDTO!.firstProductNote);
                            }
                            if (bill.ResultDTO!.secondProductNote != null && bill.ResultDTO.secondProductNote != "")
                            {
                                if (bill.ResultDTO!.secondProductNote.IndexOf("\n") != -1)
                                    sb.AppendLine("  1 x " + bill.ResultDTO.secondProductNote.Trim().Replace("\n", ", "));
                                else
                                    sb.AppendLine("  1 x " + bill.ResultDTO!.secondProductNote);
                            }
                            if (bill.ResultDTO!.thirdProductNote != null && bill.ResultDTO.thirdProductNote != "")
                            {
                                if (bill.ResultDTO!.thirdProductNote.IndexOf("\n") != -1)
                                    sb.AppendLine("  1 x " + bill.ResultDTO.thirdProductNote.Trim().Replace("\n", ", "));
                                else
                                    sb.AppendLine("  1 x " + bill.ResultDTO!.thirdProductNote);
                            }

                            dto.Note = sb.ToString();


                            dto = await Client!.PostGetServiceResponseAsync<SaleDetailDTO, SaleDetailDTO>("api/SaleDetail/Create", dto, true);
                        }
                        order = 0;
                        setAggregate = false;
                        GridBillData = new List<InStoreSaleBillDTO>();
                        setAggregate = true;
                        await Send();

                    }
                    catch (ApiException ex)
                    {
                        bool deleted = await Client!.PostGetServiceResponseAsync<bool, SaleDTO>("api/Sale/Delete", newSaleDTO, true);

                        if (deleted)
                        {
                            var res = await Client!.PostGetBaseResponseAsync("api/SaleDetail/DeleteById", newSaleDTO.Id, true);
                        }

                        await Sw!.FireAsync("Api Exception", "Adisyon Sisteme Kaydedilemedi: " + ex.Message, "error");
                    }
                    catch (Exception ex)
                    {
                        bool deleted = await Client!.PostGetServiceResponseAsync<bool, SaleDTO>("api/Sale/Delete", newSaleDTO, true);

                        if (deleted)
                        {
                            var res = await Client!.PostGetBaseResponseAsync("api/SaleDetail/DeleteById", newSaleDTO.Id);
                        }

                        await Sw!.FireAsync("Exception", "Adisyon Sisteme Kaydedilemedi: " + ex.Message, "error");
                    }

                }

            }


        }
        private async Task Send()
        {
            decimal dailyIncome=0;
        short dailyIncomeCount=0;
        SaleList = await Client!.GetServiceResponseAsync<List<SaleDTO>>("api/Sale/GetListOfToday", true);
            dailyIncomeCount = Convert.ToInt16(SaleList.Count);
            foreach(SaleDTO dto in SaleList)
            {
                dailyIncome = dailyIncome + dto.TotalPrice;
            }
            if (hubConnection != null)
            {
                Console.WriteLine(dailyIncome.ToString());
                Console.WriteLine(dailyIncomeCount.ToString());

                await hubConnection.SendAsync("RefreshIncome", dailyIncome, dailyIncomeCount);
            }
        }

        #region other datagrid func
        //public async Task ActionBeginHandler(ActionEventArgs<BranchProductPriceDTO> args)
        //{
        //    if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
        //    {

        //        BranchProductPriceDTO newdto = args.Data;
        //        //var validatorResult = validator.Validate(newdto);
        //        //if (validatorResult.IsValid) { }
        //        //else { }
        //        if (args.Action == "Add")
        //        {
        //            try
        //            {
        //                newdto = await Client!.PostGetServiceResponseAsync<BranchProductPriceDTO, BranchProductPriceDTO>("api/ManageBranchProductPrice/Create", newdto, true);


        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //                await Swal!.FireAsync("Başarılı", "Kayıt başarıyla oluşturuldu", "success");
        //                await LoadList();
        //            }
        //            catch (ApiException ex)
        //            {
        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //                await Swal!.FireAsync("Api Exception", ex.Message, "error");
        //            }
        //            catch (Exception ex)
        //            {
        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //                await Swal!.FireAsync("Exception", ex.Message, "error");
        //            }
        //            finally
        //            {
        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                newdto = await Client!.PostGetServiceResponseAsync<BranchProductPriceDTO, BranchProductPriceDTO>("api/ManageBranchProductPrice/Update", newdto, true);
        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //                await Swal!.FireAsync("Başarılı", "Kayıt başarıyla güncellendi", "success");
        //                await LoadList();
        //            }
        //            catch (ApiException ex)
        //            {
        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //                await Swal!.FireAsync("Api Exception", ex.Message, "error");
        //            }
        //            catch (Exception ex)
        //            {
        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //                await Swal!.FireAsync("Exception", ex.Message, "error");
        //            }
        //            finally
        //            {
        //                args.Cancel = true;
        //                await Grid!.CloseEditAsync();
        //            }
        //        }
        //    }
        //    if (args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
        //    {
        //        SweetAlertResult result = await Swal!.FireAsync(new SweetAlertOptions
        //        {
        //            Title = "DİKKAT",
        //            Text = "Emin misiniz, Sildiğiniz takdirde işlemi geri alamazsınız!",
        //            Icon = SweetAlertIcon.Warning,
        //            ShowCancelButton = true,
        //            ConfirmButtonColor = "#3085d6",
        //            CancelButtonColor = "#d33",
        //            ConfirmButtonText = "Evet sil!",
        //            CancelButtonText = "Vazgeç"
        //        });

        //        if (!string.IsNullOrEmpty(result.Value))
        //        {
        //            BranchProductPriceDTO dto = args.Data;
        //            if (dto == null) await Swal.FireAsync(null, "Silmek için kayıt seçmelisiniz!", "danger");
        //            else
        //            {
        //                try
        //                {
        //                    bool deleted = await Client!.PostGetServiceResponseAsync<bool, BranchProductPriceDTO>("api/ManageBranchProductPrice/Delete", dto, true);

        //                    args.Cancel = true;
        //                    await Grid!.CloseEditAsync();
        //                    await Swal!.FireAsync(
        //                                      "İşlem başarılı",
        //                                      "Kayıt silindi",
        //                                      SweetAlertIcon.Success
        //                                      );
        //                    await LoadList();
        //                }
        //                catch (ApiException ex)
        //                {
        //                    args.Cancel = true;
        //                    await Grid!.CloseEditAsync();
        //                    await Swal!.FireAsync("Api Exception", ex.Message, "error");
        //                }
        //                catch (Exception ex)
        //                {
        //                    args.Cancel = true;
        //                    await Grid!.CloseEditAsync();
        //                    await Swal!.FireAsync("Exception", ex.Message, "error");
        //                }
        //                finally
        //                {
        //                    args.Cancel = true;
        //                    await Grid!.CloseEditAsync();
        //                }
        //            }
        //        }
        //        else if (result.Dismiss == DismissReason.Cancel)
        //        {
        //            args.Cancel = true;
        //            await Grid!.CloseEditAsync();
        //        }
        //    }
        //}
        //public async Task ActionCompleteHandler(ActionEventArgs<BranchProductPriceDTO> args)
        //{
        //    if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
        //    {
        //        //if (args.Action == "Add") await Swal!.FireAsync("Başarılı", "Yeni kayıt başarıyla oluşturuldu", "success");
        //        //else await Swal!.FireAsync("Başarılı", "Kayıt başarıyla güncelleştirildi", "success");

        //        args.Cancel = true;
        //        await Grid!.CloseEditAsync();
        //        //await LoadList();
        //    }

        //    if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
        //    {
        //        args.Cancel = true;
        //        await Grid!.CloseEditAsync();
        //        //await Swal!.FireAsync(
        //        //                  "İşlem başarılı",
        //        //                  "Kayıt başarıyla silindi",
        //        //                  SweetAlertIcon.Success
        //        //                  );
        //    }
        //}
        //public async Task ActionFailureHandler(FailureEventArgs args)
        //{
        //    var s = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(args.Error));  //get details 
        //    await Swal!.FireAsync("??", "Tabloda bilinmeyen bir hata oluştu", "error");
        //    await LoadList();
        //}
        //public async Task ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        //{

        //    SyncfusionExportation<BranchProductPriceDTO> syfExp = new();
        //    await syfExp.ToolBarClick(args, this.Grid!);
        //}
        //public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<BranchProductPriceDTO> args)
        //{
        //    if (args.Column.Field == "IsActive")
        //    {
        //        if (args.Data.IsActive == true)
        //            args.Cell.Value = "Aktif";
        //        else args.Cell.Value = "Pasif";
        //    }
        //}
        //public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<BranchProductPriceDTO> args)
        //{
        //    if (args.Column.Field == "IsActive")
        //    {
        //        if (args.Data.IsActive == true)
        //            args.Cell.Value = "Aktif";
        //        else args.Cell.Value = "Pasif";
        //    }
        //}
        #endregion


    }
}
