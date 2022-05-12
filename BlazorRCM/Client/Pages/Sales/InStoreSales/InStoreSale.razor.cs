﻿using BlazorRCM.Shared.DTOs.ModelDTOs;
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


        [CascadingParameter]
        public int IntValue { get; set; }

        [Inject]
        IPrintingService? PrintingService { get; set; }

        protected List<BranchProductPriceDTO> BranchProductPriceList = new();
        protected List<BranchProductPriceDTO> FavList = new();
        protected List<BranchProductPriceDTO> FoodList = new();
        protected List<BranchProductPriceDTO> MenuList = new();
        protected List<BranchProductPriceDTO> DrinkList = new();
        protected List<BranchProductPriceDTO> OtherList = new();

        protected List<ProductSaleNoteDTO> ProductSaleNoteList = new();
        //protected List<ProductSaleNoteDTO> LittleList = new();
        //protected List<ProductSaleNoteDTO> LotsOfList = new();
        //protected List<ProductSaleNoteDTO> RemoveList = new();
        //protected List<ProductSaleNoteDTO> IncludeList = new();
        //protected List<ProductSaleNoteDTO> LavashList = new();
        //protected List<ProductSaleNoteDTO> OtherNoteList = new();

        protected decimal totalPrice = 0;
        protected bool skipLastIndex = true;
        protected List<InStoreSaleBillDTO>? GridBillData = new();

        protected short BranchId = 1;//şimdilik

        protected bool _elementIsLoading = true;
        protected SfGrid<InStoreSaleBillDTO>? Grid;
        protected ActionEventArgs<InStoreSaleBillDTO>? Args;
        public static Guid Pkey { get; set; }

        protected bool setAggregate = true;
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;


        protected async override Task OnInitializedAsync()
        {
            //StringBuilder sb = new();
            //sb.

            await LoadList();
        }
        protected async Task LoadList()
        {
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
            //foreach (ProductSaleNoteDTO item in ProductSaleNoteList!)
            //{
            //    if (item.NoteCat == 1) LotsOfList.Add(item);
            //    if (item.NoteCat == 2) LittleList.Add(item);
            //    if (item.NoteCat == 3) RemoveList.Add(item);
            //    if (item.NoteCat == 4) IncludeList.Add(item);
            //    if (item.NoteCat == 5) LavashList.Add(item);
            //    if (item.NoteCat == 6) OtherNoteList.Add(item);
            //}

            _elementIsLoading = false;
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
                Pkey = args.Data.Id;           //get primary key value of newly added record 
            }
        }
        //public async void DataBoundHandler(BeforeDataBoundArgs<InStoreSaleBillDTO> args)
        //{
        //    if (skipLastIndex)
        //    {
        //        //await Task.Delay(50);
        //        var Idx = this.Grid!.TotalItemCount - 1;   //get last index value 
        //        //var Idx = await this.Grid!.GetRowIndexByPrimaryKey(Convert.ToDouble(Pkey));   //get index value
        //        await this.Grid.SelectRowAsync(Convert.ToDouble(Idx));       //select the added or after deleting - last row by using index value of the record 
        //    }

        //}
        public async Task AddToBill(BranchProductPriceDTO item)
        {
            InStoreSaleBillDTO dto = new();
            dto.Id = Guid.NewGuid();
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
                    rowData.Quantity = rowData.Quantity + (q + 1);
                }
                if (q > 0)
                {
                    rowData.Quantity = q;
                }

                if (q == -1)
                {
                    DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
                    //DialogParameters params= new DialogParameters();
                    var parameters = new DialogParameters();
                    parameters.Add("IntValue", rowData.Quantity);
                    parameters.Add("Max", 100);

                    var dialog = DialogService!.Show<BaseMudDialogNumeric>("Adet Girin:", parameters, closeOnEscapeKey);
                    var result = await dialog.Result;
                    if (!result.Cancelled)
                        rowData.Quantity = Convert.ToInt32(result.Data.ToString());
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

        public void SaveAndPrint()
        {
            //PrintingService!.Print("printable-form", PrintType.Html);
            this.Grid!.Print();
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