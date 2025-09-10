using Microsoft.EntityFrameworkCore;
using System;
using TesteCandidato1.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Nesse contexto, foi definido que o Id é a primary key
builder.Services.AddDbContext<CepContext>(options =>
              options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CEP"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
