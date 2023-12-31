using Microsoft.EntityFrameworkCore;
using OfficeCraft.Context;
using OfficeCraft.Services.IService;
using OfficeCraft.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register services here
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")
));

//Inyecci�m de dependencias

builder.Services.AddTransient<IProductoServices, ProductoServices>();
builder.Services.AddTransient<IPedidoServices, PedidoServices>();
builder.Services.AddTransient<IClienteServices, ClienteServices>();
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();
builder.Services.AddTransient<IRolServices, RolServices>();
builder.Services.AddTransient<IOfertaServices, OfertaServices>();
builder.Services.AddHttpContextAccessor();

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
    pattern: "{controller=Home}/{action=Nosotros}/{id?}");

app.Run();
