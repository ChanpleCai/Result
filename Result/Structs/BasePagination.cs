// ReSharper disable once CheckNamespace

namespace Common.Function
{
    public class BasePagination : IPagination
    {
        public int PageNumber { get; set; } = Constant.DefaultPageNumber;

        public int PageSize { get; set; } = Constant.DefaultPageSize;
    }
}