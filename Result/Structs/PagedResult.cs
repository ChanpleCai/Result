using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Common.Function
{
    public readonly struct PagedResult<TPayload> : IPagedResult<TPayload>
    {
        public PagedResult(List<TPayload> list, int total, IPagination request)
        {
            IsSuccess = true;
            PageNumber = request.PageNumber;
            PageSize = request.PageSize;
            Total = total;
            FailureReason = default;
            Payload = list;
        }

        private PagedResult(string failureReason)
        {
            IsSuccess = false;
            PageNumber = Constant.DefaultPageNumber;
            PageSize = Constant.DefaultPageSize;
            Total = 0;
            FailureReason = failureReason;
            Payload = default;
        }

        public bool IsSuccess { get; }

        public string FailureReason { get; }

        public int Total { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public List<TPayload> Payload { get; }

        public static implicit operator PagedResult<TPayload>(string failureReason)
            => new PagedResult<TPayload>(failureReason);
    }
}