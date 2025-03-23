using IndieFusionFinal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados com Entity Framework
builder.Services.AddDbContext<IndieFusionFinalContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IndieFusionFinalContext")
        ?? throw new InvalidOperationException("Connection string 'IndieFusionFinalContext' not found.")
    ));

// Configuração de sessão
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Define o tempo de expiração da sessão
    options.Cookie.HttpOnly = true;  // Impede o acesso via JavaScript
    options.Cookie.IsEssential = true;  // Marca a sessão como essencial para o funcionamento do site
});

// Adiciona os serviços necessários para MVC
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("NewsApiClient", client =>
{
    client.DefaultRequestHeaders.Add("User -Agent", "SeuNomeDeAplicacao/1.0");
});

var app = builder.Build();

// Configuração do pipeline de middlewares
app.UseSession();  // Habilita o uso da sessão

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}

// Middleware para servir arquivos estáticos (CSS, JS, imagens)
app.UseStaticFiles();

// Configuração de roteamento
app.UseRouting();

app.MapControllerRoute(
    name: "news",
    pattern: "news",
    defaults: new { controller = "News", action = "Index" }
);

// Configuração de endpoints de controle
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
