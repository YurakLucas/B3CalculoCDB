using Xunit;
using Moq;
using B3CalculoCDB.Features.CDB;
using B3CalculoCDB.Models;
using B3CalculoCDB.Features.CDB.Commands;
using System.Threading;

namespace B3CalculoCDB.Tests
{
    public class CalcularCDBCommandHandlerTests
    {
        [Fact]
        public void Handle_ShouldCalculateCorrectly()
        {
            // Arrange
            var cdbServiceMock = new Mock<ICdbService>();
            cdbServiceMock.Setup(service => service.CalcularInvestimento(It.IsAny<InvestimentoRequest>())).Returns(new InvestimentoResponse
            {
                ResultadoBruto = 20194.4,
                ResultadoLiquido = 20150.66
            });

            var handler = new CalcularCdbCommandHandler(cdbServiceMock.Object);

            var command = new CalcularCdbCommand
            {
                Prazo = 12,
                Valor = 20000,
            };

            // Act
            var result = handler.Handle(command, CancellationToken.None).Result;

            // Assert
            // Verifica se o resultado bruto é igual ao valor esperado
            Assert.Equal(20194.4, result.ResultadoBruto, 8);

            // Verifica se o resultado líquido é igual ao valor esperado
            Assert.Equal(20150.66, result.ResultadoLiquido, 8);
        }
    }
}
