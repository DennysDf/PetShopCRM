using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.External;
using PetShopCRM.Infrastructure;
using PetShopCRM.Infrastructure.Settings;
using PetShopCRM.Web.Middlewares;
using PetShopCRM.Web.Resources;
using PetShopCRM.Web.Services;
using PetShopCRM.Web.Services.Interfaces;
using PetShopCRM.Web.SignalHubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(ValidationMessages));
    });

builder.Services.AddDbContextPool<PetShopDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:PetShopDb"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.LoginPath = "/User/Login";
        options.LogoutPath = "/User/Logout";
        options.AccessDeniedPath = "/User/Denied";
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(nameof(UserType.Admin), x => x.RequireRole(nameof(UserType.Admin)))
    .AddPolicy(nameof(UserType.General), x => x.RequireRole(nameof(UserType.Admin), nameof(UserType.General)))
    .AddPolicy(nameof(UserType.Guardian), x => x.RequireRole(nameof(UserType.Guardian)));

builder.Services.Configure<AppSettings>(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddExternalServices();

//Web services
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ILoggedUserService, LoggedUserService>();
builder.Services.AddScoped<IUpload, Upload>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IWebContext, WebContext>();

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

var app = builder.Build();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseLogException();

app.UseRouting();

app.UseAuthorization();

app.MapHub<NotificationHub>("/Notification");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
