using Microsoft.EntityFrameworkCore;
using TP_Shop.DataAccess.EF;
using TP_Shop.DataAccess.Interfaceses;
using TP_Shop.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Configuration.AddJsonFile("config.json");
string ConnectionString(IConfiguration appConfig) => appConfig["PostgreSQLConnection"];
string connectionWithPostgreSQL = ConnectionString(builder.Configuration);

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseNpgsql(connectionWithPostgreSQL));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
