using beautyTech.Data; // Certifique-se de ter esta refer�ncia
using Microsoft.EntityFrameworkCore; // Necess�rio para usar o DbContext

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllersWithViews();

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ajuste conforme necess�rio

// Configurar sess�es
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Dura��o da sess�o
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configurar o IHttpClientFactory
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7002/"); // Substitua pela URL da sua API
});

var app = builder.Build();

// Configurar o pipeline de requisi��es
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitar sess�es
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
