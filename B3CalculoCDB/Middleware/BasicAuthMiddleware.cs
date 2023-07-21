using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace B3CalculoCDB.Middleware
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        // Credenciais para validação
        private const string Username = "teste";
        private const string Password = "b3";

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Obter as credenciais codificadas em base64 (após o "Basic ")
                var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                var credentials = decodedCredentials.Split(':');

                var user = credentials[0];
                var pass = credentials[1];

                // Validar as credenciais
                if (user == Username && pass == Password)
                {
                    // Se as credenciais forem válidas, continuamos o pipeline da aplicação
                    await _next(context);
                    return;
                }
            }

            // Caso as credenciais sejam inválidas, retornamos 401 Unauthorized
            context.Response.Headers["WWW-Authenticate"] = "Basic";
            context.Response.StatusCode = 401;
        }
    }

    // Extensão para usar o middleware no pipeline da aplicação
    public static class BasicAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthMiddleware>();
        }
    }
}
