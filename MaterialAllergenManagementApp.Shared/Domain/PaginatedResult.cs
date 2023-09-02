using System;

namespace MaterialAllergenManagementApp.Shared.Domain;

public class PaginatedResult<T>
{
    public List<T> Data { get; }
    public int Total { get; }
    public int Top { get; }
    public int Skip { get; }

    public PaginatedResult(List<T> data, int total, int top, int skip)
    {
        Data = data;
        Total = total;
        Top = top;
        Skip = skip;
    }

    public static PaginatedResult<T> Empty() => new(new List<T>(), 0, 0, 0);
}
