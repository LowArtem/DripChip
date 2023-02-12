namespace DripChip.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Paged<T>(this IQueryable<T> queryable, int from = 0, int size = 10) =>
        queryable.Skip(from).Take(size);
}