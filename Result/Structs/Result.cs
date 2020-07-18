using System;

// ReSharper disable once CheckNamespace

namespace Common.Function
{
    public readonly struct Result : IResult
    {
        private Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
            FailureReason = default;
        }

        private Result(string failureReason)
        {
            IsSuccess = false;
            FailureReason = failureReason;
        }

        public bool IsSuccess { get; }

        public string FailureReason { get; }

        public static implicit operator Result(bool isSuccess)
            => new Result(isSuccess);

        public static implicit operator Result(string failureReason)
            => new Result(failureReason);
    }

    public readonly struct Result<TPayload> : IResult<TPayload>
    {
        private Result(TPayload payload)
        {
            Payload = payload;
            IsSuccess = true;
            FailureReason = default;
        }

        private Result(string failureReason)
        {
            Payload = default;
            IsSuccess = false;
            FailureReason = failureReason;
        }

        public TPayload Payload { get; }

        public bool IsSuccess { get; }

        public string FailureReason { get; }

        public static implicit operator Result<TPayload>(TPayload payload)
            => new Result<TPayload>(payload);

        public static implicit operator Result<TPayload>(string failureReason)
            => new Result<TPayload>(failureReason);
    }

    public readonly struct Result<TPayload, TFailurePayload> : IResult<TPayload, TFailurePayload>
    {
        private Result(TPayload payload)
        {
            Payload = payload;
            IsSuccess = true;
            FailureReason = default;
            FailurePayload = default;
        }

        private Result(string failureReason)
        {
            Payload = default;
            IsSuccess = false;
            FailureReason = failureReason;
            FailurePayload = default;
        }

        private Result(TFailurePayload failurePayload)
        {
            Payload = default;
            IsSuccess = false;
            FailureReason = default;
            FailurePayload = failurePayload;
        }

        private Result(string failureReason, TFailurePayload failurePayload)
        {
            Payload = default;
            IsSuccess = false;
            FailureReason = failureReason;
            FailurePayload = failurePayload;
        }

        public TPayload Payload { get; }

        public bool IsSuccess { get; }

        public string FailureReason { get; }

        public TFailurePayload FailurePayload { get; }

        public static implicit operator Result<TPayload, TFailurePayload>(TPayload payload)
            => new Result<TPayload, TFailurePayload>(payload);

        public static implicit operator Result<TPayload, TFailurePayload>(string failureReason)
            => new Result<TPayload, TFailurePayload>(failureReason);

        public static implicit operator Result<TPayload, TFailurePayload>(TFailurePayload failurePayload)
            => new Result<TPayload, TFailurePayload>(failurePayload);

        public static implicit operator Result<TPayload, TFailurePayload>(ValueTuple<string, TFailurePayload> tuple)
            => new Result<TPayload, TFailurePayload>(tuple.Item1, tuple.Item2);

        public static implicit operator Result<TPayload, TFailurePayload>(ValueTuple<TFailurePayload, string> tuple)
            => new Result<TPayload, TFailurePayload>(tuple.Item2, tuple.Item1);
    }
}