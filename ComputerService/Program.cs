using ComputerService.Components;
using ComputerService.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GamerContext>();
// Для доступности метода AddDbContext
// Необходимо установить пакет Entity Framework Core в 
// этот проект (веб проект)

// <T> где T это класс с контекстом подключения
// т.е. ваш класс унаследованный от DbContext

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Получение сервис
// и вызывать у него определенный метод
using (var serviceScope = app.Services.CreateScope())
{
    // Получение сервиса 
    var context = serviceScope.ServiceProvider.GetRequiredService<GamerContext>();
    
    // вызов процедуры миграции
    context.Database.Migrate();
}

app.Run();