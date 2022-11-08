using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Enable Session support - Step 1
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});

//Add EF Core support, configure/setup for Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options => {                                 //What db to use
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:WebShopDbContextConnection"]);       //Use DefaultConnection, must match with Program.cs
});

/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});*/



builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
});


builder.Services.AddScoped<IProductService, ProductsServices>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyMethod();
    options.AllowAnyHeader();

});



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();  
}

builder.Services.AddRazorPages();
//Enable session - Step 2
app.UseSession();


//Must come First                   //Don't change the order, otherwise it can crash
app.UseRouting();
//Second
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
//Third
app.UseHttpsRedirection();
app.UseStaticFiles();


//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed support
DbInitializer.Seed(app);
app.Run();
