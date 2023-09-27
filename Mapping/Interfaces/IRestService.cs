namespace Mapping.Interfaces;

public interface IRestService<T, in TRequest> 
    where T : class
    where TRequest : class
{
    Task<T> GetAsync(TRequest request);
    Task<IEnumerable<T>> GetEnumerableAsync(TRequest request);
}