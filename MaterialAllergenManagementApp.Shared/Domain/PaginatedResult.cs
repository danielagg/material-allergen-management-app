using System;

namespace MaterialAllergenManagementApp.Shared.Domain;

public class PaginatedResult<T>
{
    public IEnumerable<T> Data { get; }
    public int Total { get; }
    public int Top { get; }
    public int Skip { get; }

    public PaginatedResult(IEnumerable<T> data, int total, int top, int skip)
    {
        Data = data;
        Total = total;
        Top = top;
        Skip = skip;
    }

    public static PaginatedResult<T> Empty() => new(Enumerable.Empty<T>(), 0, 0, 0);
}
