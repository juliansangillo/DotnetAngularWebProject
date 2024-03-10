using DotnetAngularWebProject.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;

namespace DotnetAngularWebProject.Modules.Debug.API.v1.Controllers {
    [ApiVersion("1")]
    [Route("[module]/api/v{version:apiVersion}/[controller]/[action]")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Controller methods can't be static.")]
    public class ErrorController : BaseController {
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public void Api()
            => ThrowException(
                inner => new ApiException(HttpStatusCode.InternalServerError, "Something is wrong", inner),
                () => ThrowException(() => new ApiException(HttpStatusCode.InternalServerError, "Something else is wrong")));

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ErrorResponse))]
        public void Unknown()
            => ThrowException(
                inner => new UnknownException("Something is wrong", inner),
                () => ThrowException(() => new UnknownException("Something else is wrong")));

        private static void ThrowException(Func<Exception> outer)
            => throw outer();

        private static void ThrowException(Func<Exception, Exception> outer, Action inner) {
            try {
                inner();
            }
            catch (Exception e) {
                throw outer(e);
            }
        }
    }
}
