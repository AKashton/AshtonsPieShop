using AshtonsPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Services for Dependency Injection

builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();


builder.Services.AddControllersWithViews();
var app = builder.Build();

// Middleware Components

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
