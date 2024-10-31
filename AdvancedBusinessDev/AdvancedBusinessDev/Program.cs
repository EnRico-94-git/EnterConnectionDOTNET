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

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração do DbContext
builder.Services.AddDbContext<ABDcontext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleABD")));

// Configuração do repositório genérico e do serviço
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
var app = builder.Build();


// Middleware e pipeline de execução
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
