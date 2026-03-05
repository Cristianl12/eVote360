//using eVote360.Persistence.Context;
//using eVote360.Domain.Repositories;
//using eVote360.Infrastructure.Repositories;
using eVote360.Application;
using eVote360.Application.Services;
using eVote360.Domain.Repositories;
using eVote360.Infrastructure.Repositories;
using eVote360.Persistence.Context;
using eVote360.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// 🔹 Configurar conexión a la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Inyección de dependencias (repositorios)
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped<UnitOfWork>();

// Registrar la interfaz IUnitOfWork con su implementación UnitOfWork (implementación vive en Infrastructure)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<CiudadanoService>();
builder.Services.AddScoped<PartidoService>();
builder.Services.AddScoped<CandidatoService>();
builder.Services.AddScoped<EleccionService>();
builder.Services.AddScoped<VotoService>();
builder.Services.AddScoped<ResultadoService>();
builder.Services.AddScoped<OcrService>();




builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();





//  MVC y controladores
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

//  Configuración del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

//  Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedData.InitializeAsync(roleManager);
}


app.Run();


