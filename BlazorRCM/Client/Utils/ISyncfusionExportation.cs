using Syncfusion.Blazor.Grids;

namespace BlazorRCM.Client.Utils
{
    public interface ISyncfusionExportation<T> where T : class
    {
        Task ToolBarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args, SfGrid<T> Grid);
    }
}
