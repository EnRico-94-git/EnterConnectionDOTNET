using AdvancedBusinessDev.DataBase;
using AdvancedBusinessDev.Models;
using AdvancedBusinessDev.Repositories;
using AdvancedBusinessDev.Services;
using Microsoft.EntityFrameworkCore;
using MyConfigManager = AdvancedBusinessDev.Services.ConfigurationManager;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGenericRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IGenericRepository<Empresa>, EmpresaRepository>();
builder.Services.AddScoped<IGenericRepository<IA>, IARepository>();
builder.Services.AddScoped<IGenericRepository<Interface>, InterfaceRepository>();
builder.Services.AddScoped<IGenericRepository<Parceiro>, ParceiroRepository>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<IAService>();
builder.Services.AddScoped<InterfaceService>();
builder.Services.AddScoped<ParceiroService>();

builder.Services.AddSingleton(MyConfigManager.Instance);

// Adiciona servi�os ao cont�iner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura��o do DbContext
builder.Services.AddDbContext<ABDcontext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleABD")));

// Configura��o do reposit�rio gen�rico e do servi�o
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
var app = builder.Build();


// Middleware e pipeline de execu��o
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
