using Microsoft.EntityFrameworkCore;
using System;
using WebShop.Data;
using WebShop.Data.Interfaces;
using WebShop.Data.Mocks;
using WebShop.Data.Models;
using WebShop.Data.Repozitory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAllCars, CarRepozitory>();
builder.Services.AddTransient<ICarsCategory, CategoryRepozitory>();
//confBuilder.Services.AddMvc(o => o.EnableEndpointRouting = false);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped(sp=>ShopCart.GetCart(sp));
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();


// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDbContent>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

var confBuilder = new ConfigurationBuilder();
// установка пути к текущему каталогу
confBuilder.SetBasePath(Directory.GetCurrentDirectory());
// получаем конфигурацию из файла appsettings.json
confBuilder.AddJsonFile("appsettings.json");
// создаем конфигурацию
var config = confBuilder.Build();
// получаем строку подключения
string connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<AppDbContent>();
var options = optionsBuilder.UseSqlServer(connectionString).Options;

using (AppDbContent db = new AppDbContent(options))
{
    DbObjects.Initial(db);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=categoryFilter}/{action}/{id?}");



app.Run();

