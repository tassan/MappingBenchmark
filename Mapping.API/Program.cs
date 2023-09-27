using System.Diagnostics;
using AutoMapper;
using Mapping;
using Mapping.Interfaces;
using Mapping.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Logging
builder.Logging.AddConsole();

DependencyInjection.Inject(builder.Services);

var app = builder.Build();

// GET products-translator
app.MapGet("/products-translator", async () =>
{
    var logger = app.Services.GetService<ILogger<Program>>();
    
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    logger.LogInformation("Getting products-translator");
    var restService = app.Services.GetService<IRestService<ProductStock, StockRequest>>();
    var translator = app.Services.GetService<ITranslator<ProductStock, Product>>();
    var translatorStrategy = new TranslatorStrategy(restService, translator);

    var products = await translatorStrategy.GetProducts();
    
    stopwatch.Stop();
    
    var response = new Response<IEnumerable<Product>>(data: products, elapsedTime: (int)stopwatch.ElapsedMilliseconds);
    
    logger.LogInformation("Returning products-translator");
    return response;
});

// GET products-automapper
app.MapGet("/products-automapper", async () =>
{
    var logger = app.Services.GetService<ILogger<Program>>();
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    logger.LogInformation("Getting products-automapper");
    var restService = app.Services.GetService<IRestService<ProductStock, StockRequest>>();
    var mapper = app.Services.GetService<IMapper>();
    var mapperStrategy = new AutoMapperStrategy(restService, mapper);

    var products = await mapperStrategy.GetProducts();
    stopwatch.Stop();
    
    var response = new Response<IEnumerable<Product>>(products)
    {
        ElapsedTime = (int)stopwatch.ElapsedMilliseconds
    };
    
    logger.LogInformation("Returning products-automapper");
    return response;
});

app.Run();