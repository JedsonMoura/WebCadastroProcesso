using Microsoft.EntityFrameworkCore;
using WebCadastroProcessos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DbContext
builder.Services.AddDbContext<Contexto>(options =>
    options.UseMySql(
        "server=127.0.0.1;database=FSBR;uid=root;pwd=root",
        ServerVersion.Parse("8.0.38-mysql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Processo}/{action=Index}/{id?}");

app.Run();
