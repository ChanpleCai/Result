using System.Collections.Generic;


// ReSharper disable once CheckNamespace

namespace Common.Function
{
    public readonly struct ListResult<TPayload> : IListResult<TPayload>
    {
        private ListResult(List<TPayload> payload)
        {
            Payload = payload;
            IsSuccess = true;
            FailureReason = default;
        }

        private ListResult(string failureReason)
        {
            Payload = default;
            IsSuccess = false;
            FailureReason = failureReason;
        }

        public List<TPayload> Payload { get; }

        public bool IsSuccess { get; }

        public string FailureReason { get; }

        public static implicit operator ListResult<TPayload>(List<TPayload> payload)
            => new ListResult<TPayload>(payload);

        public static implicit operator ListResult<TPayload>(string failureReason)
            => new ListResult<TPayload>(failureReason);
    }
}