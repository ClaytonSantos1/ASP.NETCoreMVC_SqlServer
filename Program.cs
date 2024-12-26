using Microsoft.EntityFrameworkCore;
using MvcEFCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração do bando de dados
builder.Services.AddDbContext<ProdutoContexto>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSqlServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configuração de middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Inicializar banco de dados 
using (var scope = app.Services.CreateScope()) { 
    var services = scope.ServiceProvider; 
    var context = services.GetRequiredService<ProdutoContexto>(); 
    InicializaDB.Inicialize(context); 
    }

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
