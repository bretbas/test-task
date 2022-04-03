using Microsoft.EntityFrameworkCore;
using SomeService2.DAL.CQRS.ValueObjects;

namespace SomeService2.DAL.Additions.Extensions;

public static class IQueryableExtensions
{
    public static async Task<Pagination<T>> WithPaginationAsync<T>(
        this IQueryable<T> source,
        int currentPage,
        int perPage)
    {
        // Нормализуем данные пагинации исходя из количества страниц
        var postCount = await source.CountAsync();
        var totalPage = (int)Math.Ceiling((float)postCount / perPage);
        NormalizePaginationData(ref currentPage, ref perPage, totalPage);

        var entities = await source
            .Skip((currentPage - 1) * perPage)
            .Take(perPage)
            .ToListAsync();

        return new Pagination<T>()
        {
            Entities = entities,
            CurrentPage = currentPage,
            PerPage = perPage,
            TotalEntities = postCount
        };
    }

    private static void NormalizePaginationData(
        ref int currentPage,
        ref int perPage,
        int totalPage)
    {
        if (totalPage < 1) totalPage = 1;
        if (currentPage < 1) currentPage = 1;
        if (totalPage < currentPage) currentPage = totalPage;
        if (perPage < 1) perPage = 10;
    }
}