using B3CalculoCDB.Features.CDB;
using B3CalculoCDB.Models;
using B3CalculoCDB.Features.Queries;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace B3CalculoCDB.Tests
{
    [TestClass]
    public class CalcularCdbQueryHandlerTests
    {
        [Fact]
        [TestMethod]
        public async Task Handle_Should_ReturnInvestimentoResponse()
        {
            // Arrange
            var request = new CalcularCdbQuery
            {
                Valor = 1000,
                Prazo = 6
            };

            var expectedResult = new InvestimentoResponse
            {
                ResultadoBruto = 1165,
                ResultadoLiquido = 1041.875
            };

            var cdbServiceMock = new Mock<ICdbService>();
            cdbServiceMock.Setup(service => service.CalcularInvestimento(It.IsAny<InvestimentoRequest>()))
                .Returns(expectedResult);

            var handler = new CalcularCdbQueryHandler(cdbServiceMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult.ResultadoBruto, result.ResultadoBruto, 0.001);
            Assert.AreEqual(expectedResult.ResultadoLiquido, result.ResultadoLiquido, 0.001);

            // Verificar se o método CalcularInvestimento do ICdbService foi chamado com os parâmetros corretos
            cdbServiceMock.Verify(service => service.CalcularInvestimento(
                It.Is<InvestimentoRequest>(req => req.Valor == request.Valor && req.Prazo == request.Prazo)),
                Times.Once);
        }
    }
}
