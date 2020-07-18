using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Common.Function
{
    public static partial class Fun
    {
        public static PagedResult<TPayload> ToResult<TPayload>(this IEnumerable<TPayload> enumerable)
            => enumerable.ToList().ToResult();

        public static PagedResult<TPayload> ToResult<TPayload>(this List<TPayload> list)
            => new PagedResult<TPayload>(list, list.Count, new BasePagination
            {
                PageNumber = 1,
                PageSize = list.Count
            });

        public static PagedResult<TPayload> ToResult<TPayload>(this ListResult<TPayload> result)
            => new PagedResult<TPayload>(result.Payload, result.Payload.Count, new BasePagination
            {
                PageNumber = 1,
                PageSize = result.Payload.Count
            });
    }
}