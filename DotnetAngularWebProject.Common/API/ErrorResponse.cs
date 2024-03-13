namespace DotnetAngularWebProject.Common.API {
    public sealed class ErrorResponse {
        public ErrorDto? Error { get; init; }
        public ExceptionDto? Exception { get; init; }
    }
}
