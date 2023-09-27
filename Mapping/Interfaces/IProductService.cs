using Mapping.Models;

namespace Mapping.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
}