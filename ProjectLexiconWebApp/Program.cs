using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Add EF Core support, configure/setup for Dependency Injection
//builder.Services.AddDbContext<ApplicationDbContext>(options => {                                 //What db to use
//    options.UseSqlServer(
//        builder.Configuration["ConnectionStrings:WebShopDbContextConnection"]);       //Use DefaultConnection, must match with Program.cs
//});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

//Seed support
DbInitializer.Seed(app);
app.Run();
