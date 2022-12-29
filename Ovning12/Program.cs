using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ovning12.Data;
using Ovning12.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Ovning12Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ovning12Context") ?? throw new InvalidOperationException("Connection string 'Ovning12Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGarageHelpers, GarageHelpers>();

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
app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ParkedVehicles}/{action=Index}/{id?}");

app.Run();
