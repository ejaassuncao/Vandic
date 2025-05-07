using System.Net;
using System.Text.Json;

namespace Vandic.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // tenta passar para o próximo middleware
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro inesperado."); // loga com Serilog ou qualquer ILogger
                await HandleExceptionAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new
            {
                status = 500,
                message = "Erro interno do servidor. Tente novamente mais tarde."
            });

            return context.Response.WriteAsync(result);
        }
    }

}
