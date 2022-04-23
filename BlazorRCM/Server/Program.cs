using Blazored.LocalStorage;
using BlazorRCM.Server.Infrasructures;
using BlazorRCM.Server.Services.Business.EF;
using BlazorRCM.Shared.DTOs.ModelDTOs;
using BlazorRCM.Shared.Extensions;
using BlazorRCM.Shared.ValidationRules.FluentValidation.DTOs.ModelDTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

#region MyRepos
builder.Services.AddScoped<IAuthorityTypeRepo, EfAuthorityTypeRepo>();
builder.Services.AddScoped<IBranchRepo, EfBranchRepo>();
builder.Services.AddScoped<ISupplierRepo, EfSupplierRepo>();
builder.Services.AddScoped<IUserBranchAuthorityRepo, EfUserBranchAuthorityRepo>();
builder.Services.AddScoped<IUserRepo, EfUserRepo>();
builder.Services.AddScoped<IFirmTypeRepo, EfFirmTypeRepo>();
builder.Services.AddScoped<IBranchProductPriceRepo, EfBranchProductPriceRepo>();

#endregion

//builder.Services.AddScoped(typeof(ISyncfusionExportation<>), typeof(SyncfusionExportation<>));

builder.Services.AddDbContext<RCMBlazorContext>();
//builder.Services.AddDbContext<RCMBlazorContext>(config =>
//{
//    config.UseNpgsql(builder.Configuration.GetConnectionString("RCMpostgreConnection"));
//    config.EnableSensitiveDataLogging();
//});


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
            });





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
app.MapFallbackToFile("index.html");

app.Run();
