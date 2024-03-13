namespace DotnetAngularWebProject.Common.API {
    public sealed class ErrorDto {
        public int Code { get; init; }
        public string? Type { get; init; }
        public string? Message { get; init; }
    }
}
