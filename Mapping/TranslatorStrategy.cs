using Mapping.Interfaces;
using Mapping.Models;

namespace Mapping;

public class TranslatorStrategy : IProductService
{
    private readonly IRestService<ProductStock, StockRequest> _restService;
    private readonly ITranslator<ProductStock, Product> _translator;

    public TranslatorStrategy(IRestService<ProductStock, StockRequest> restService, ITranslator<ProductStock, Product> translator)
    {
        _restService = restService;
        _translator = translator;
    }
    
    public async Task<IEnumerable<Product>> GetProducts()
    {
        var request = new StockRequest
        {
            Search = "Macbook"
        };
        var products = await _restService.GetEnumerableAsync(request);
        return products.Select(_translator.Translate);
    }
}