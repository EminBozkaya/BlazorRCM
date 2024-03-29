using Blazored.LocalStorage;
using BlazorRCM.Server.Hubs;
using BlazorRCM.Server.Services.Business.EF;
using BlazorRCM.Server.Services.Infrastructures;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.Extensions;
using BlazorRCM.Shared.ValidationRules.FluentValidation.DTOs.ModelDTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RCMServerData.EFContext;
using System.Reflection;
using System.Text;
//using FluentValidation;
//using FluentValidation.DependencyInjectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(options =>
//    {
//        // Validate child properties and root collection elements
//        options.ImplicitlyValidateChildProperties = true;
//        options.ImplicitlyValidateRootCollectionElements = true;
//        // Automatic registration of validators in assembly
//        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//    });

//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(options => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddControllersWithViews();
//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(fv =>
//    {
//        fv.DisableDataAnnotationsValidation = true;
//    });

builder.Services.AddTransient<IValidator<UserDTO>, UserDTOValidator>();

builder.Services.AddRazorPages();
builder.Services.ConfigureMapping();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

//builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
// policy.AllowAnyMethod()
// .AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin => true)));


#region MyRepos
builder.Services.AddScoped<IAuthorityTypeRepo, EfAuthorityTypeRepo>();
builder.Services.AddScoped<IBranchRepo, EfBranchRepo>();
builder.Services.AddScoped<ISupplierRepo, EfSupplierRepo>();
builder.Services.AddScoped<IUserBranchAuthorityRepo, EfUserBranchAuthorityRepo>();
builder.Services.AddScoped<IUserRepo, EfUserRepo>();
builder.Services.AddScoped<IFirmTypeRepo, EfFirmTypeRepo>();
builder.Services.AddScoped<IBranchProductPriceRepo, EfBranchProductPriceRepo>();
builder.Services.AddScoped<IProductSaleNoteRepo, EfProductSaleNoteRepo>();
builder.Services.AddScoped<ISaleRepo, EfSaleRepo>();
builder.Services.AddScoped<ISaleDetailRepo, EfSaleDetailRepo>();

#endregion


//builder.Services.AddScoped(typeof(ISyncfusionExportation<>), typeof(SyncfusionExportation<>));

builder.Services.AddDbContext<RCMBlazorContext>();



builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtIssuer"],
                    ValidAudience = builder.Configuration["JwtAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"]))
                };
                //options.Authority = "Authority URL";
                ////options.RequireHttpsMetadata = false;
                //options.Events = new JwtBearerEvents
                //{
                //    OnMessageReceived = context =>
                //    {
                //        var accessToken = context.Request.Query["access_token"];

                //        // If the request is for our hub...
                //        var path = context.HttpContext.Request.Path;
                //        if (!string.IsNullOrEmpty(accessToken) &&
                //            (path.StartsWithSegments("/hubs/dashboarddailyincome")))
                //        {
                //            // Read the token out of the query string
                //            context.Token = accessToken;
                //        }
                //        return Task.CompletedTask;
                //    }
                //};
            });

//builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
//                            policy.AllowAnyMethod()
//                                  .AllowAnyHeader()
//                                  .AllowCredentials()
//                                  .SetIsOriginAllowed(origin => true)));




var app = builder.Build();
//app.UseCors();
app.UseResponseCompression();

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

//ILocalStorageService service = app.Services.GetRequiredService<ILocalStorageService>();
//LSManager.Configure(service);

//app.Use(<LSManager.Configure(app.Services.GetService<ILocalStorageService>())>);
//using (var scope = app.Services.CreateScope()) 
//{
//    var service = scope.ServiceProvider.GetService<ILocalStorageService>();
//    LocalStorageExtension.Configure(service!);
//};

//LocalStorageExtension.Configure(app.Services.GetRequiredService<ILocalStorageService>());
//LSManager.Configure(app.GetService<ILocalStorageService>());

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapHub<DashboardDailyIncomeHub>("/dashboarddailyincomehub");
app.MapFallbackToFile("index.html");

app.Run();

