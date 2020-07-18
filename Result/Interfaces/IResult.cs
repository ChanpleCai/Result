using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Common.Function
{
    public interface IResult
    {
        bool IsSuccess { get; }

        string FailureReason { get; }
    }

    public interface IResult<out TPayload> : IResult
    {
        TPayload Payload { get; }
    }

    public interface IResult<out TPayload, out TFailurePayload> : IResult<TPayload>
    {
        TFailurePayload FailurePayload { get; }
    }

    public interface IListResult<TPayload> : IResult
    {
        List<TPayload> Payload { get; }
    }

    public interface IPagedResult<TPayload> : IListResult<TPayload>
    {
        int Total { get; }

        int PageNumber { get; }

        int PageSize { get; }
    }
}