﻿using BlazorRCM.Shared.DTOs;
using BlazorRCM.Shared.ResponseModels;
using BlazorRCM.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BlazorRCM.Shared.CustomExceptions;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Grids;
using BlazorRCM.Client.Shared;
using BlazorRCM.Client.Utils;
using System.Configuration;

namespace BlazorRCM.Client.Pages.SystemManagement.User
{
    public class UserListProcess : ComponentBase
    {
        
        [Inject]
        public HttpClient? Client { get; set; }

        protected List<UserDTO> UserList = new();
        //protected bool _processing = true;
        //protected string visibility = "invisible";
        protected bool _elementIsLoading = true;

        [Inject]
        public SweetAlertService? Sw { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]
        SweetAlertService? Swal { get; set; }

        protected SfGrid<UserDTO>? Grid;

        protected Syncfusion.Blazor.Navigations.ClickEventArgs? clickevent;
        protected async override Task OnInitializedAsync()
        {

            await LoadList();
            //await JSRuntime!.InvokeAsync<object>("TestDataTablesAdd", ".mud-table-root");

            //StateHasChanged();
        }

        protected async Task LoadList()
        {
            try
            {
                //await Task.Delay(2000);

                UserList = await Client!.GetServiceResponseAsync<List<UserDTO>>("api/ManageUser/users", true);

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

                if (args.Action == "Add")
                {
                    try
                    {
                        newdto.CreatedTime= DateTime.Now;
                        newdto.ModifiedTime = DateTime.Now;
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
                        newdto.ModifiedTime = DateTime.Now;
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
            SyncfusionExportation<UserDTO> syfExp = new();
            await syfExp.ToolBarClick(args, this.Grid!);
            //await SyncfusionExportation<UserDTO>.ToolBarClick(args, this.Grid!);
        }
        public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<UserDTO> args)
        {
            if (args.Column.Field == "IsActive")
            {
                //if (args.Data.IsActive==true)
                //    args.Cell.Value = "Aktif";
                //else args.Cell.Value = "Pasif";

                //args.Cell.Value = args.Data.IsActive;
                args.Cell.Value = "hey";
            }
        }
        public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<UserDTO> args)
        {
            if (args.Column.Field == "IsActive")
            {
                if (args.Data.IsActive == true)
                    args.Cell.Value = "Aktif";
                else args.Cell.Value = "Pasif";
                //args.Cell.Value = 'X' ;

            }
        }
        //public async Task ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        //{
        //    if (args.Item.Id == "Grid_pdfexport")
        //    {
        //        //this.Grid!.PdfExport();
        //        PdfExportProperties ExportProperties = new PdfExportProperties();

        //        PdfTheme Theme = new PdfTheme();


        //        PdfThemeStyle HeaderThemeStyle = new PdfThemeStyle()

        //        {

        //            Font = new PdfGridFont { IsTrueType = true, FontSize = 8, FontFamily = "T1RUTwA..." }, //apply your custom font base64 string to FontFamily

        //            FontColor = "#64FA50",

        //            FontName = "Calibri",

        //            FontSize = 17,

        //            Bold = true,

        //            //Border = HeaderBorder

        //        };

        //        Theme.Header = HeaderThemeStyle;


        //        PdfThemeStyle RecordThemeStyle = new PdfThemeStyle()

        //        {


        //            Font = new PdfGridFont { IsTrueType = true, FontSize = 8, FontFamily = "T1RUTwALAI..." }, //apply your custom font base64 string to FontFamily

        //            FontColor = "#64FA50",

        //            FontName = "Calibri",

        //            FontSize = 17


        //        };

        //        Theme.Record = RecordThemeStyle;


        //        PdfThemeStyle CaptionThemeStyle = new PdfThemeStyle()

        //        {

        //            Font = new PdfGridFont { IsTrueType = true, FontSize = 8, FontFamily = "T1RUT...ABQ=" }, //apply your custom font base64 string to FontFamily

        //            FontColor = "#64FA50",

        //            FontName = "Calibri",

        //            FontSize = 17,

        //            Bold = true


        //        };

        //        Theme.Caption = CaptionThemeStyle;


        //        ExportProperties.Theme = Theme;

        //        await this.Grid!.PdfExport(ExportProperties);
        //    }
        //    if (args.Item.Id == "Grid_excelexport")
        //    {
        //        await this.Grid!.ExcelExport();
        //    }
        //    if (args.Item.Id == "Grid_csvexport")
        //    {
        //        await this.Grid!.CsvExport();
        //    }
        //}
    }
}
