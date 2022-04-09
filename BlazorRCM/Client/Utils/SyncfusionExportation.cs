using BlazorRCM.Shared.Extensions;
using Core.Model;
using Syncfusion.Blazor.Grids;
using System.Configuration;

namespace BlazorRCM.Client.Utils
{
    public class SyncfusionExportation<T> :ISyncfusionExportation<T>
        where T : class, new()

    {
        //IConfiguration? _configuration;
        //private IConfiguration _configuration;
        //public SyncfusionExportation(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //readonly string fontType = _configuration["CustomSyncfusionExportationFont"];

        //SfGrid<T> Grid;
        //public SyncfusionExportation(SfGrid grid)
        //{
        //    Grid = grid;
        //}
        public async Task ToolBarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args, SfGrid<T> Grid)

        {

            
            //string fontType = File.ReadAllText(@"E:\RCMblazor\RCM\BlazorRCM\Client\wwwroot\Others\pdfTurkish.txt");

            //string fontType = ConfigHelper.AppSetting("CustomSyncfusionExportationFont");

            //Configuration _configuration=new Configuration();
            //string fntType = _configuration!["CustomSyncfusionExportationFont"];
            //string fontTyp = "";

            //Grid = _grid;

            if (args.Item.Id == "Grid_pdfexport")
            {
                //this.Grid!.PdfExport();
                //GetAppsettingsExtension ex = new();
                
                //string str = GetAppsettingsExtension.GetConnString;

                string fontType = PdfTurkishTxt.Txt;
                PdfExportProperties ExportProperties = new PdfExportProperties();

                PdfTheme Theme = new PdfTheme();


                PdfThemeStyle HeaderThemeStyle = new PdfThemeStyle()

                {

                    Font = new PdfGridFont { IsTrueType = true, FontSize = 8, FontFamily = fontType }, //apply your custom font base64 string to FontFamily

                    //FontColor = "#64FA50",

                    //FontName = "Calibri",

                    //FontSize = 17,

                    Bold = true,

                    //Border = HeaderBorder

                };

                Theme.Header = HeaderThemeStyle;


                PdfThemeStyle RecordThemeStyle = new PdfThemeStyle()

                {


                    Font = new PdfGridFont { IsTrueType = true, FontSize = 8, FontFamily = fontType }, //apply your custom font base64 string to FontFamily

                    //FontColor = "#64FA50",

                    //FontName = "Calibri",

                    //FontSize = 17


                };

                Theme.Record = RecordThemeStyle;


                PdfThemeStyle CaptionThemeStyle = new PdfThemeStyle()

                {

                    Font = new PdfGridFont { IsTrueType = true, FontSize = 8, FontFamily = fontType }, //apply your custom font base64 string to FontFamily

                    //FontColor = "#64FA50",

                    //FontName = "Calibri",

                    //FontSize = 17,

                    Bold = true


                };

                Theme.Caption = CaptionThemeStyle;


                ExportProperties.Theme = Theme;
                ExportProperties.IncludeTemplateColumn = true;
                await Grid!.PdfExport(ExportProperties);
            }
            if (args.Item.Id == "Grid_excelexport")
            {
                ExcelExportProperties exportProperties = new ExcelExportProperties();
                exportProperties.IncludeTemplateColumn = true;
                await Grid.ExcelExport(exportProperties);
            }
            if (args.Item.Id == "Grid_csvexport")
            {
                await Grid!.CsvExport();
            }
        }
    }
}


