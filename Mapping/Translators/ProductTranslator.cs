using System.Security.Cryptography;
using Mapping.Interfaces;
using Mapping.Models;

namespace Mapping.Translators;

public class ProductTranslator : ITranslator<ProductStock, Product>
{
    public Product Translate(ProductStock input)
    {
        return new Product
        {
            Id = input.Id,
            Name = input.Name,
            QuantityInStock = input.AvailableQuantity,
            Price = RandomNumberGenerator.GetInt32(1000, 6000)
        };
    }

    public Task<Product> TranslateAsync(ProductStock input)
    {
        return Task.FromResult(Translate(input));
    }
}