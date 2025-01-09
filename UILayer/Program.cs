using BusinessLayer.ValidationRules.IdentityValidations;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidation>();

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

// Giriþ yapma iþlemi için gerekli ayarlar. Eðer giriþ yapmamýþ bir kullanýcý bir sayfaya eriþmeye çalýþýrsa yönlendirileceði sayfa.
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.LogoutPath = "/Login/Logout";
    opt.Cookie.MaxAge = TimeSpan.FromDays(1); //Oturumun açýk kalacaðý süre
});

var app = builder.Build();

// Error sayfalarý için yönlendirme iþlemi. Eðer bir hata oluþursa kullanýcýya hata sayfasý gösterilecek.
app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode == 404)
    {
        x.HttpContext.Response.Redirect("/Error/NotFound404Page/");
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Dil seçeneði için gerekli ayarlar
var defaultCulture = new CultureInfo("tr-TR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CustomerTable}/{action=CustomerTableList}/{id?}");

app.Run();
