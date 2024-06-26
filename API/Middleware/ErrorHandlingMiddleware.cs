﻿using BLL.Exceptions;
using BLL.Exceptions.Auth;
using DAL.Exceptions;
using System.Net;
using System.Text.Json;

namespace LinguinoAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware (RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            if (exception is SignupErrorException) statusCode = (int)HttpStatusCode.BadRequest;
            if (exception is InvalidTokenException) statusCode = (int)HttpStatusCode.Unauthorized;
            if (exception is EmailErrorException) statusCode = (int)HttpStatusCode.InternalServerError;
            if (exception is InvalidIDException) statusCode = (int)HttpStatusCode.BadRequest;
            if (exception is CourseMismatchException) statusCode = (int)HttpStatusCode.BadRequest;
            if (exception is UserNotInCourseException) statusCode = (int)HttpStatusCode.BadRequest;
            if (exception is LessonItemMismatchException) statusCode = (int)HttpStatusCode.BadRequest;
            if (exception is LessonTypeMismatchException) statusCode = (int)HttpStatusCode.BadRequest;
            if (exception is AccessDeniedException) statusCode = (int)HttpStatusCode.Forbidden;
            if (exception is MyBadException) statusCode = (int)HttpStatusCode.InternalServerError;
            if (exception is SubscriptionErrorException) statusCode = (int)HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = exception.Message }));
        }
    }
}
