namespace DotnetAngularWebProject.Common {
    public sealed class ErrorResponse {
        public ErrorDto? Error { get; init; }
        public ExceptionDto? Exception { get; init; }
    }
}
