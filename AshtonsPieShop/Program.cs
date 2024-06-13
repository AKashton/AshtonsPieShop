using AshtonsPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services for Dependency Injection

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AshtonsPieShopDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:AshtonsPieShopDbContextConnection"]));

var app = builder.Build();

// Middleware Components

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

DbInitializer.Seed(app);
app.Run();
