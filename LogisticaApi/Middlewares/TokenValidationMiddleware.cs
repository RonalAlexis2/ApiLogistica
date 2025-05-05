using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var path = context.Request.Path;

        // Puedes permitir rutas sin token, por ejemplo el login (si existiera)
        if (!path.StartsWithSegments("/api"))
        {
            await _next(context);
            return;
        }

        var hasAuthHeader = context.Request.Headers.TryGetValue("Authorization", out var token);

        if (!hasAuthHeader || string.IsNullOrEmpty(token) || !token.ToString().StartsWith("Bearer "))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Token de autorización no válido o faltante.");
            return;
        }

        // Si quieres validar el valor del token, hazlo aquí:
        var tokenValue = token.ToString().Substring("Bearer ".Length);
        if (tokenValue != "mipersonalToken123") // Puedes cambiar este valor
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Token inválido.");
            return;
        }

        await _next(context);
    }
}

