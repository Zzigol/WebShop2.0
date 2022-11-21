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



// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDbContent>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

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
    
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    Category electroCategory = new Category { categoryName = "Электромобили", desc = "Современный вид транспорта" };
    Category classikCategory = new Category { categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего сгорания" };

    // Добавление
    db.Category.Add(electroCategory);
    db.Category.Add(classikCategory);

    db.Car.AddRange(
        new Car
        {
            name = "Tesla",
            shortDesc = "Быстрый автомобиль",
            longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
            img = "/img/Tesla-Model-S-Plaid.jpg",
            price = 45000,
            isFavourite = true,
            available = true,
            Category = electroCategory
        },
                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "Тихий и спокойный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/Ford Fiesta.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = classikCategory
                    },
                    new Car
                    {
                        name = "BMW M3",
                        shortDesc = "Дерзкий и стильный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/BMW M3.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = classikCategory
                    },
                    new Car
                    {
                        name = "Mercedes C class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/Mercedes C class.jpg",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = classikCategory
                    },
                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Бесшумный и экономный",
                        longDesc = "Удобный автомобиль для городской жизни",
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
