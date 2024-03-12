using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Infrastructure;
using PetShopCRM.Web.Resources;
using PetShopCRM.Web.SignalHubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(ValidationMessages));
    });

builder.Services.AddDbContext<PetShopDbContext>(
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
    .AddPolicy(nameof(UserType.General), x => x.RequireRole(nameof(UserType.Admin), nameof(UserType.General)));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<NotificationHub>("/Notification");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
