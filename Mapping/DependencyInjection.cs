using Mapping.AutoMapperConfigurations;
using Mapping.External;
using Mapping.Interfaces;
using Mapping.Models;
using Mapping.Translators;
using Microsoft.Extensions.DependencyInjection;

namespace Mapping;

public static class DependencyInjection
{
    public static void Inject(IServiceCollection services)
    {
        // Rest Services
        services.AddTransient<IRestService<ProductStock, StockRequest>, StockRestService>();
        
        // Translators
        services.AddTransient<ITranslator<ProductStock, Product>, ProductTranslator>();

        // Mappers
        AutoMapperConfig.Configure(services);
    }
}