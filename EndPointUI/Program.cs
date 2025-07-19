using Application;
using EndPointUI.Hubs;
using Infrastructure;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.
    LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddSignalR();
builder.Services.AddLocalization(option =>
{
    option.ResourcesPath = "Resources";
});
builder.Services.Application(builder.Configuration);
builder.Services.Infrastructure(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
        new CultureInfo("fa-IR"),
            };
var options = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture("fa-IR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
};
app.UseRequestLocalization(options);
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
         context.HttpContext.Response.Redirect("/404");
    }

    if (context.HttpContext.Response.StatusCode == 401 || context.HttpContext.Response.StatusCode == 403)
    {
         context.HttpContext.Response.Redirect("/Forbidden");
    }



});

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/ChatHub");
app.MapHub<SupportHub>("/SupportHub");
app.Run();
