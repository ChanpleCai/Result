// ReSharper disable once CheckNamespace

namespace Common.Function
{
    public interface IPagination
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}