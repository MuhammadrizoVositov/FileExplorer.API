using FileExplore.Aplication.Common.Model.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.Common.Model.Querinng.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> sources, FilterPagination paginationOptions)
        {
            return sources.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
        
        }
        public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination paginationOptions)
        {

            return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
        }
    }
}
