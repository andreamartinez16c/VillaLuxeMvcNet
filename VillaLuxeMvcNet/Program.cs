using Microsoft.EntityFrameworkCore;
using VillaLuxeMvcNet.Data;
using VillaLuxeMvcNet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("SqlServerVillas");
builder.Services.AddTransient<RepositoryVillas>();
builder.Services.AddDbContext<VillaContext>
	(options => options.UseSqlServer(connectionString));

//builder.Services.AddTransient<IRepositoryEmpleados, RepositoryEmpleadosSQLServer>();
//string connectionString =
//    builder.Configuration.GetConnectionString("SqlServerHospital");
//builder.Services.AddDbContext<HospitalContext>
//    (options => options.UseSqlServer(connectionString));

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