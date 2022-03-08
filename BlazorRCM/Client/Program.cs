using BlazorRCM.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.VisualStudio.Web.BrowserLink;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();


await builder.Build().RunAsync();

//var app = builder.Build();

////app.UseDefaultFiles();    // add this line before invoking app.UseStaticFiles();
//object p = app.UseStaticFiles();



//app.RunAsync();



