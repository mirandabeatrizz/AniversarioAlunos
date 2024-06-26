using AniversarioAlunos.Data;
using AniversarioAlunos.Services;
using Blazorise;
using Microsoft.EntityFrameworkCore;
using Blazorise.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("DataBaseAniversarioAlunos"));

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<IAlunoService, AlunoService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Adicione esta parte para configurar Blazorise
builder.Services.AddBlazorise();
builder.Services.AddBootstrapProviders();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");



app.Run();
