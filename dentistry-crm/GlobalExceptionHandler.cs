﻿using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace dentistry_crm
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerManager _logger;

        public GlobalExceptionHandler(ILoggerManager logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                httpContext.Response.StatusCode = contextFeature.Error switch
                {
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                _logger.LogError($"Something went wrong: {exception.Message}");

                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = contextFeature.Error.Message,
                }.ToString());
            }

            return true;
        }
    }
}
