using System;
using System.Configuration;
using BlazorRCM.Server.Services.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using RCMServerData.EFContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureMapping();

builder.Services.AddDbContext<RCMBlazorContext>();
//builder.Services.AddDbContext<RCMBlazorContext>(config =>
//{
//    config.UseNpgsql(builder.Configuration.GetConnectionString("RCMpostgreConnection"), b => b.MigrationsAssembly("RCMServerData"));
//    config.EnableSensitiveDataLogging();
//});
//builder.Services.AddScoped<DbContext>(provider =>  provider.GetService<RCMBlazorContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
