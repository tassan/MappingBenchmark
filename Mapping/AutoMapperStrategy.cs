using AutoMapper;
using Mapping.Interfaces;
using Mapping.Models;

namespace Mapping;

public class AutoMapperStrategy : IProductService
{
    private readonly IRestService<ProductStock, StockRequest> _restService;
    private readonly IMapper _mapper;

    public AutoMapperStrategy(IRestService<ProductStock, StockRequest> restService, IMapper mapper)
    {
        _restService = restService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var request = new StockRequest()
        {
            Search = "Macbook"
        };
        var products = await _restService.GetEnumerableAsync(request);
        return _mapper.Map<IEnumerable<Product>>(products);
    }
}