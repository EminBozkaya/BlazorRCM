using BlazorRCM.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.VisualStudio.Web.BrowserLink;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



await builder.Build().RunAsync();

//var app = builder.Build();

////app.UseDefaultFiles();    // add this line before invoking app.UseStaticFiles();
//object p = app.UseStaticFiles();



//app.RunAsync();



