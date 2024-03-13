using System;

namespace DotnetAngularWebProject.Common.API {
    public sealed class ExceptionDto {
        public string? Type { get; init; }
        public string? Message { get; init; }
        public string? Source { get; init; }
        public string? StackTrace { get; init; }
        public ExceptionDto? InnerException { get; init; }

        public static ExceptionDto? From(Exception? e)
            => e != null
                ? new() {
                    Type = e.GetType().FullName,
                    Message = e.Message,
                    Source = e.Source,
                    StackTrace = e.StackTrace,
                    InnerException = From(e.InnerException),
                }
                : null;
    }
}
