using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Result = new ObjectResult(new { ErrorMessage = "Not implemented" })
                {
                    StatusCode = 500
                };
            }
            if (context.Exception is Exception)
            {
                context.Result = new ObjectResult(new { ErrorMessage = "Something went wrong" })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
