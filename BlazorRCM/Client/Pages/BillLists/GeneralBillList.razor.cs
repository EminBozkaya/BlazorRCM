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
using MudBlazor;

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
        protected bool _elementIsLoading = false;
        protected SfGrid<SaleDTO>? Grid;
        protected DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "750px" };
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        protected decimal totalPrice = 0;
        protected decimal billTotalPrice = 0;
        protected bool firstClicked;
        protected int saleId;
        protected DateTime saleTime;

        protected DateTime? date;
        
        protected DateRange dateRange = new DateRange();
        protected List<DateTime> rangeList = new();
        //protected DateRange _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.AddDays(5).Date);
        protected async override Task OnInitializedAsync()
        {
            _jsPrintModule = await JSRuntime!.InvokeAsync<IJSObjectReference>("import", "./MyScripts/printDisplay.js");
            //_jsInStoreSalePrintModule = await IJSInStoreSale!.InvokeAsync<IJSObjectReference>("import", "./MyScripts/PrintInStoreSaleBill.js");
            //StateHasChanged();
        }
        protected async Task GetListOfDate()
        {
            SaleList = new();
            billDTOList = new();
            totalPrice = 0;
            billTotalPrice = 0;
            if (date != null)
            {
                _elementIsLoading = true;
                SaleList = await Client!.PostGetServiceResponseAsync<List<SaleDTO>, DateTime>("api/Sale/GetListOfAnyDay", (DateTime)date, true);
                _elementIsLoading = false;
                StateHasChanged();
            }
        }
        protected async Task GetListOfDateRange()
        {
            SaleList = new();
            rangeList = new();
            billDTOList = new();
            totalPrice = 0;
            billTotalPrice = 0;
            if (dateRange.Start != null && dateRange.End != null)
            {
                _elementIsLoading = true;
                rangeList.Add((DateTime)dateRange.Start);
                rangeList.Add((DateTime)dateRange.End);
                SaleList = await Client!.PostGetServiceResponseAsync<List<SaleDTO>, List<DateTime>>("api/Sale/GetListOfDateRange", rangeList, true);
                _elementIsLoading = false;
                StateHasChanged();
            }
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
