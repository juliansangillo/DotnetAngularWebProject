using System;
using System.Net;

namespace DotnetAngularWebProject.Common.API {
    public class ApiException : Exception {
        public ApiException(HttpStatusCode errorCode, string? message) : base(message) => ErrorCode = errorCode;

        public ApiException(HttpStatusCode errorCode, string? message, Exception? innerException) : base(message, innerException) => ErrorCode = errorCode;

        public HttpStatusCode ErrorCode { get; }
    }
}
