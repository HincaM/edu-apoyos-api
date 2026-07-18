using EduApoyos.Domain.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EduApoyos.Infrastructure.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PaginatedList<T>> ToPaginatedList<T>(this IQueryable<T> query, int currentPage, int pageSize, CancellationToken cancellationToken)
        {
            var paginatedList = new PaginatedList<T>
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = query.Count(),
                Results = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken)
            };
            return paginatedList;
        }
    }
}
