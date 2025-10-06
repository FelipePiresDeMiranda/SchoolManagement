public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado");
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var response = new { mensagem = "Ocorreu um erro inesperado. Tente novamente mais tarde." };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}