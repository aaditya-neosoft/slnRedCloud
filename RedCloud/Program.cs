using Microsoft.AspNetCore.DataProtection;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.Models.Email;
using RedCloud.Services;
using RedCloud.ViewModel;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
IConfiguration Configuration = builder.Configuration;

// Add distributed memory cache for session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped(typeof(IApiClient<>), typeof(ApiClient<>));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRedCloudAdminService, RedCloudAdminService>();  // Added by Atharva
builder.Services.AddScoped<IAdminResellerUser, AdminResellerUserService>();
//builder.Services.AddScoped<IAdminResellerUser, AdminResellerUserService>();
builder.Services.AddScoped(typeof(IDropDownService<CountryVM>), typeof(DropDownService<CountryVM>));
builder.Services.AddScoped(typeof(IStateService<StateVM>), typeof(StateService<StateVM>));
builder.Services.AddScoped(typeof(ICityService<CityVM>), typeof(CityService<CityVM>));
builder.Services.AddScoped<IOrganizationAdminService, OrganizationAdminService>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings")); // Add by Aditya
builder.Services.AddTransient<IMailService, MailService>(); // Add by Aditya

builder.Services.AddScoped<IEncryptionService, EncryptionService>();

//logger setup
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc
.ReadFrom.Configuration(ctx.Configuration)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSerilogRequestLogging();
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{Id?}");
    //pattern: "{controller=Account}/{action=Login}/{Id?}");
    pattern: "{controller=Home}/{action=Dashboard}/{Id?}");

app.Run();
