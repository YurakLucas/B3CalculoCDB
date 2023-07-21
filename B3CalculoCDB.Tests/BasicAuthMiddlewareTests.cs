using B3CalculoCDB.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace B3CalculoCDB.Tests
{
    [TestClass]
    public class BasicAuthMiddlewareTests
    {
        [Fact]
        [TestMethod]
        public async Task Invoke_ValidCredentials_Should_CallNextMiddleware()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers["Authorization"] = "Basic " + EncodeCredentials("teste", "b3");
            var nextInvoked = false;

            RequestDelegate nextMiddleware = (HttpContext httpContext) =>
            {
                nextInvoked = true;
                return Task.CompletedTask;
            };

            var middleware = new BasicAuthMiddleware(nextMiddleware);

            // Act
            await middleware.Invoke(context);

            // Assert
            Assert.IsTrue(nextInvoked);
            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
        }

        [Fact]
        [TestMethod]
        public async Task Invoke_InvalidCredentials_Should_ReturnUnauthorized()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers["Authorization"] = "Basic " + EncodeCredentials("invalid", "credentials");

            var middleware = new BasicAuthMiddleware(null); // Next middleware is not called

            // Act
            await middleware.Invoke(context);

            // Assert
            Assert.AreEqual(StatusCodes.Status401Unauthorized, context.Response.StatusCode);
        }

        private string EncodeCredentials(string username, string password)
        {
            var credentials = $"{username}:{password}";
            var credentialsBytes = Encoding.UTF8.GetBytes(credentials);
            return System.Convert.ToBase64String(credentialsBytes);
        }
    }
}
