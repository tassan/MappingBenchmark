using System.Collections;

namespace Mapping.Models;

public class Response<T>
{
    public Response(T data)
    {
        Data = data;
        Count = (data as IEnumerable)?.Cast<object>().Count() ?? 0;
    }

    public Response(T data, long elapsedTime) : this(data)
    {
        Data = data;
        ElapsedTime = elapsedTime;
    }

    public long ElapsedTime { get; set; }
    public int Count { get; }

    private T Data { get; set; }
}