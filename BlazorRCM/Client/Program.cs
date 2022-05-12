using Blazored.LocalStorage;
using BlazorRCM.Client;
using BlazorRCM.Shared.Utils;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.VisualStudio.Web.BrowserLink;
using MudBlazor.Services;
using Syncfusion.Blazor;
using System.Globalization;
using BlazorRCM.Client.Shared;
using Append.Blazor.Printing;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjAwNzYzQDMxMzkyZTM0MmUzMGdJb002aVRNbU0zRkNiaithUFF6azFyU2VvYVZWK1FXekNlcjJlYzl0MjA9");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSweetAlert2();

builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
// Register the Syncfusion locale service to customize the  SyncfusionBlazor component locale culture
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));

// Set the default culture of the application
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("tr");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("tr");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IPrintingService, PrintingService>();

await builder.Build().RunAsync();

