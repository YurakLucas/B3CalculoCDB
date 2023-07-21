using System.Threading;
using System.Threading.Tasks;
using B3CalculoCDB.Features.CDB;
using B3CalculoCDB.Features.Queries;
using B3CalculoCDB.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace B3CalculoCDB.Tests
{
    [TestClass]
    public class CdbControllerTests
    {
        [Fact]
        [TestMethod]
        public async Task CalcularInvestimento_Should_ReturnInvestimentoResponse()
        {
            // Arrange
            var request = new InvestimentoRequest
            {
                Valor = 1000,
                Prazo = 6
            };

            var expectedResult = new InvestimentoResponse
            {
                ResultadoBruto = 1165,
                ResultadoLiquido = 1041.875
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(mediator => mediator.Send(It.IsAny<CalcularCdbQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            var controller = new CdbController(mediatorMock.Object);

            // Act
            var result = await controller.CalcularInvestimento(request) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(expectedResult, result.Value);
        }
    }
}

