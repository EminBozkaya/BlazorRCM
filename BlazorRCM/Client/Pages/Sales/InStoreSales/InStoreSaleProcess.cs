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

namespace BlazorRCM.Client.Pages.Sales.InStoreSales
{
    public class InStoreSaleProcess : ComponentBase
    {

        [Inject]
        public HttpClient? Client { get; set; }

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]
        SweetAlertService? Swal { get; set; }

        //BranchProductPriceDTOValidator validator=new();

        //protected AddNewBranchProductPriceDTO AddNewBranchProductPriceDTO = new();
        //protected List<BranchDTO> BranchList = new();
        //protected List<AuthorityTypeDTO> AuthorityTypeList = new();
        protected List<BranchProductPriceDTO> BranchProductPriceList = new();
        protected List<BranchProductPriceDTO> FavList = new();
        protected List<BranchProductPriceDTO> FoodList = new();
        protected List<BranchProductPriceDTO> MenuList = new();
        protected List<BranchProductPriceDTO> DrinkList = new();
        protected List<BranchProductPriceDTO> OtherList = new();

        protected double? Amount = 0;
        //protected int LineNo = 0;
        protected List<InStoreSaleBillDTO>? GridBillData = new();

        protected short BranchId = 1;//şimdilik
        //protected string BranchId = "1";//şimdilik

        protected bool _elementIsLoading = true;
        protected SfGrid<InStoreSaleBillDTO>? Grid;
        protected ActionEventArgs<InStoreSaleBillDTO>? Args;
        //protected DialogSettings DialogParams = new DialogSettings { MinHeight = "400px", Width = "750px" };
        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;

        //public List<ExpandoObject> BranchProductPrices { get; set; } = new List<ExpandoObject>();
        protected async override Task OnInitializedAsync()
        {

            await LoadList();

            //AddNewBranchProductPriceDTO.BranchProductPriceDTOList = BranchProductPriceList;
            //AddNewBranchProductPriceDTO.BranchDTOList = BranchList;
            //AddNewBranchProductPriceDTO.AuthorityTypeDTOList = AuthorityTypeList;

            //BranchProductPrices = Enumerable.Range(1, BranchProductPriceList.Count()).Select((x) => 
            //{
            //    dynamic d = new ExpandoObject();
            //    dynamic BranchProductPrice = new ExpandoObject();
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

                
                //BranchProductPriceList = await Client!.GetServiceResponseAsync<List<BranchProductPriceDTO>>("api/ManageBranchProductPrice/GetList", true);


                BranchProductPriceList = await Client!.PostGetServiceResponseAsync<List<BranchProductPriceDTO>,short>("api/ManageBranchProductPrice/GetBranchList", BranchId, true);

                foreach(BranchProductPriceDTO item in BranchProductPriceList)
                {
                    if (item.IsFavorite == true) FavList.Add(item);
                    if(item.MenuListId==1) FoodList.Add(item);  
                    if(item.MenuListId==2) MenuList.Add(item);  
                    if(item.MenuListId==3) DrinkList.Add(item);  
                    if(item.MenuListId==4) OtherList.Add(item);  
                }
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

        public void ActionBegin(ActionEventArgs<InStoreSaleBillDTO> args)
        {
            //Args = args;
            if ((args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save) && args.Action == "Add"))
            //if ((args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save) && args.Action == "Add"))
            {
                args.Index = GridBillData!.Count();
                //args.Index = (Grid.PageSettings.CurrentPage * Grid.PageSettings.PageSize) - 1; 
            }
        }
        public async Task AddToBill(BranchProductPriceDTO item)
        {
            
            //LineNo++;
            InStoreSaleBillDTO dto = new();
            dto.Id = Guid.NewGuid();
            dto.Quantity = 1;
            dto.Portion = 1;
            dto.ProductPrice = item.BranchPrice;
            dto.ProductName = item.ProductName;
            dto.TotalPrice = dto.ProductPrice * dto.Portion * dto.Quantity;

            await this.Grid!.AddRecord(dto);

            //GridBillData!.Add(dto);
        }

        
            public async Task RemoveFromBill()
        {
            //InStoreSaleBillDTO dto = Grid!.SelectedRecords[0];
            //if (dto != null)
            //GridBillData!.Remove(Args.Data);
            await this.Grid!.DeleteRecordAsync();
            //await this.Grid!.DeleteRecordAsync((Grid!.SelectedRecords[0]);
        }
        

        //public async Task AddToBill()
        //{
        //    int s = 0;
        //    await Task.Delay(100);
        //    s = 3;
        //}


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
    }
}
