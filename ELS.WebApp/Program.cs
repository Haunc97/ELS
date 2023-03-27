using ELS.Persistence;
using ELS.Persistence.Contexts;
using ELS.Persistence.Repositories;
using ELS.UseCase.PluginInterfaces;
using ELS.UseCase.PluginInterfaces.Repositories;
using ELS.UseCase.Queries.Vocabularies.SearchVocabularies;
using ELS.WebApp.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("ELSSchema");

// Solving the problem of Ef core and blazor
// Blazor cannot dispose of the DbContext instant properly even if we use the Transient lifetime scope
builder.Services.AddDbContextFactory<ELSContext>(options =>
{
    options.UseSqlServer(connStr);
});

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(typeof(SearchVocabulariesQuery));

builder.Services.AddTransient<IVocabularyRepository, VocabularyRepository>();
builder.Services.AddTransient<IStudySetRepository, StudySetRepository>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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
