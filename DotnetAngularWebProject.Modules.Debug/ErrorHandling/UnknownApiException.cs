using DotnetAngularWebProject.Common;
using System;
using System.Net;

namespace DotnetAngularWebProject.Modules.Debug.ErrorHandling {
    public class UnknownApiException : ApiException {
        public UnknownApiException(HttpStatusCode errorCode, string? message) : base(errorCode, message) {
        }

        public UnknownApiException(HttpStatusCode errorCode, string? message, Exception? innerException) : base(errorCode, message, innerException) {
        }
    }
}
