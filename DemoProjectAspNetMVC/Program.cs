using System.Globalization;
using DemoProjectAspNetMVC.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Localization
builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources";});
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

//Add supported cultures
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportLanguages = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("zh-HANS"),
        new CultureInfo("es-ES")
    };

    options.SupportedCultures = supportLanguages;
    options.SupportedUICultures = supportLanguages;
    options.DefaultRequestCulture = new RequestCulture(supportLanguages[0]);
    options.ApplyCurrentCultureToResponseHeaders = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseAuthorization();

app.UseRequestLocalization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();