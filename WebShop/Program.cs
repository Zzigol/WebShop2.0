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


// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AppDbContent>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

var confBuilder = new ConfigurationBuilder();
// ��������� ���� � �������� ��������
confBuilder.SetBasePath(Directory.GetCurrentDirectory());
// �������� ������������ �� ����� appsettings.json
confBuilder.AddJsonFile("appsettings.json");
// ������� ������������
var config = confBuilder.Build();
// �������� ������ �����������
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

