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



// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AppDbContent>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

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
    
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    Category electroCategory = new Category { categoryName = "�������������", desc = "����������� ��� ����������" };
    Category classikCategory = new Category { categoryName = "������������ ����������", desc = "������ � ���������� ����������� ��������" };

    // ����������
    db.Category.Add(electroCategory);
    db.Category.Add(classikCategory);

    db.Car.AddRange(
        new Car
        {
            name = "Tesla",
            shortDesc = "������� ����������",
            longDesc = "��������, ������� � ����� ����� ���������� �������� Tesla",
            img = "/img/Tesla-Model-S-Plaid.jpg",
            price = 45000,
            isFavourite = true,
            available = true,
            Category = electroCategory
        },
                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "����� � ���������",
                        longDesc = "������� ���������� ��� ��������� �����",
                        img = "/img/Ford Fiesta.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = classikCategory
                    },
                    new Car
                    {
                        name = "BMW M3",
                        shortDesc = "������� � ��������",
                        longDesc = "������� ���������� ��� ��������� �����",
                        img = "/img/BMW M3.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = classikCategory
                    },
                    new Car
                    {
                        name = "Mercedes C class",
                        shortDesc = "������ � �������",
                        longDesc = "������� ���������� ��� ��������� �����",
                        img = "/img/Mercedes C class.jpg",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = classikCategory
                    },
                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "��������� � ���������",
                        longDesc = "������� ���������� ��� ��������� �����",
                        img = "/img/Nissan Leaf.jpg",
                        price = 14000,
                        isFavourite = true,
                        available = true,
                        Category = electroCategory
                    });
    db.SaveChanges();
}

//DbObjects.Initial(app);
//var scope = app.ApplicationServises.CreateScope()

//    AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
//    DbObjects.Initial(content);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CarContoller}/{action=Cars/List}/{id?}");

app.Run();














//var confBuilder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//confBuilder.Services.AddControllersWithViews();

//var app = confBuilder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
