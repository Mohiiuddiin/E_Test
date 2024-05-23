using E_Test.Data;
using E_Test.Models;
using E_Test.Repository;
using E_Test.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBaseRepository<Patient>, BaseRepository<Patient>>();
builder.Services.AddScoped<IBaseRepository<DiseaseInformation>, BaseRepository<DiseaseInformation>>();
builder.Services.AddScoped<IBaseRepository<Allergies>, BaseRepository<Allergies>>();
builder.Services.AddScoped<IBaseRepository<NCD>, BaseRepository<NCD>>();
builder.Services.AddScoped<IBaseRepository<Allergies_Details>, BaseRepository<Allergies_Details>>();
builder.Services.AddScoped<IBaseRepository<NCD_Details>, BaseRepository<NCD_Details>>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
