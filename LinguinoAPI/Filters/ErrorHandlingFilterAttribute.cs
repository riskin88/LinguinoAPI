using Microsoft.AspNetCore.Mvc.Filters;
using BLL.Exceptions.User;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            if (exception is SignupErrorException)
            {
                context.Result = new ObjectResult(new { error = exception.Message })
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
            }
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
           // if (exception is SignupErrorException)
            //{
                context.Result = new ObjectResult(new { error = exception.Message })
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
            //}
        }
    }
}
