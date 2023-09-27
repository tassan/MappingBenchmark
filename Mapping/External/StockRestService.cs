using System.Security.Cryptography;
using Mapping.Interfaces;
using Mapping.Models;
using Microsoft.Extensions.Configuration;

namespace Mapping.External;

public class StockRestService : IRestService<ProductStock, StockRequest>
{
    private static int _maxProducts = 1000;
    
    public StockRestService(int maxProducts)
    {
        _maxProducts = maxProducts;
    }
    
    public Task<ProductStock> GetAsync(StockRequest request)
    {
        return Task.FromResult(GenerateProductStock(request.Search));
    }

    public Task<IEnumerable<ProductStock>> GetEnumerableAsync(StockRequest request)
    {
        var products = new List<ProductStock>();
        for (var i = 0; i < _maxProducts; i++) products.Add(GenerateProductStock(request.Search));
        return Task.FromResult<IEnumerable<ProductStock>>(products);
    }

    private static ProductStock GenerateProductStock(string? name = null)
    {
        return new ProductStock
        {
            Id = Guid.NewGuid(),
            Name = name ?? "Product",
            BlockedQuantity = RandomNumberGenerator.GetInt32(100, 1000),
            TotalQuantity = RandomNumberGenerator.GetInt32(1000, 4000)
        };
    }
}