using System.Security.Cryptography;
using AutoMapper;
using Mapping.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Mapping.AutoMapperConfigurations;

public static class AutoMapperConfig
{
    public static void Configure(IServiceCollection services)
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateProfile("ProductStockProfile", expression =>
            {
                expression.CreateMap<ProductStock, Product>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.AvailableQuantity))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => RandomNumberGenerator.GetInt32(1000, 6000)));
            });
        });
        
        configuration.AssertConfigurationIsValid();
        var mapper = configuration.CreateMapper();
        services.AddSingleton(mapper);
    }
}