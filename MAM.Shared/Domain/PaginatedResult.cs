using System;

namespace MAM.Shared.Domain;

public class PaginatedResult<T>
{
    public IEnumerable<T> Data { get; }
    public int Total { get; }
    public int Top { get; }
    public int Skip { get; }

    private PaginatedResult(IEnumerable<T> data, int total, int top, int skip)
    {
        Data = data;
        Total = total;
        Top = top;
        Skip = skip;
    }

    public static PaginatedResult<T> Create(IEnumerable<T> data, int total, int skip) => new(data, total, data.Count(), skip);
}
