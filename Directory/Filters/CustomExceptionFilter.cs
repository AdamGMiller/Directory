﻿using System;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Directory.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // Global error handling for uncaught exceptions
            actionExecutedContext.Response = new HttpResponseMessage()
            { Content = new StringContent("A serious error has occurred: " + actionExecutedContext.Exception.Message, System.Text.Encoding.UTF8, "text/plain"), StatusCode = System.Net.HttpStatusCode.InternalServerError };

            //normally this would be logged centrally as well
        }

    }
}