using Mapster;
using MapsterMapper;
using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.DAL.Repositories;
using NetCoreWithAngular.Logic.Abstract;
using NetCoreWithAngular.Middlewares;
using NetCoreWithAngular.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//var config = new TypeAdapterConfig();
var config = TypeAdapterConfig.GlobalSettings;
config.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application services

builder.Services.AddScoped<ICardsRepository, CardsRepository>();
builder.Services.AddScoped<ICardsService, CardsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
