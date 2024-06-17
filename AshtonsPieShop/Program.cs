using AshtonsPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using AshtonsPieShop.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AshtonsPieShopContextConnection") ?? throw new InvalidOperationException("Connection string 'AshtonsPieShopContextConnection' not found.");

// Services for Dependency Injection
builder.Services.AddDbContext<AshtonsPieShopDbContext>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<AshtonsPieShopDbContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware Components
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();



app.MapDefaultControllerRoute();
app.MapRazorPages();


DbInitializer.Seed(app);
app.Run();
