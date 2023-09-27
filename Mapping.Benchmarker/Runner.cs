using System.Security.Cryptography;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapping.External;
using Mapping.Interfaces;
using Mapping.Models;
using Mapping.Translators;

namespace Mapping.Benchmarker;

[MemoryDiagnoser]
public class Runner
{
    private IRestService<ProductStock, StockRequest> _restService = null!;
    private IMapper _mapper = null!;

    [Params(10_000, 100_000, 1_000_000)] public int MaxProducts { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _restService = new StockRestService(MaxProducts);
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateProfile("ProductStockProfile", expression =>
            {
                expression.CreateMap<ProductStock, Product>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.AvailableQuantity))
                    .ForMember(dest => dest.Price,
                        opt => opt.MapFrom(src => RandomNumberGenerator.GetInt32(1000, 6000)));
            });
        });

        configuration.AssertConfigurationIsValid();
        _mapper = configuration.CreateMapper();
    }

    [Benchmark(Baseline = true)]
    public async Task<List<Product>> RunTranslatorStrategy()
    {
        var translatorStrategy = new TranslatorStrategy(_restService, new ProductTranslator());
        var products = await translatorStrategy.GetProducts();
        return products.ToList();
    }

    [Benchmark]
    public async Task<List<Product>> RunAutoMapperStrategy()
    {
        _restService = new StockRestService(MaxProducts);
        var mapperStrategy = new AutoMapperStrategy(_restService, _mapper);

        var products = await mapperStrategy.GetProducts();
        return products.ToList();
    }
}
