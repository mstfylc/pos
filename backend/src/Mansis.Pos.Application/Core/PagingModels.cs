namespace Mansis.Pos.Application.Core;

public sealed record ListQuery(
    int Page = 1,
    int PageSize = 50,
    string? Sort = null,
    string? Filter = null);

public sealed record PagedResult<T>(
    IReadOnlyList<T> Items,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages);
