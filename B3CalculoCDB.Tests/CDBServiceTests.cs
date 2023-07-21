using B3CalculoCDB.Features.CDB;
using B3CalculoCDB.Models;
using Xunit;

namespace B3CalculoCDB.Tests
{
    public class CDBServiceTests
    {
        [Fact]
        public void CalcularInvestimento_ShouldCalculateCorrectly()
        {
            // Arrange
            var cdbService = new CdbService();

            var request = new InvestimentoRequest
            {
                Valor = 20000,
                Prazo = 1
            };

            // Act
            var result = cdbService.CalcularInvestimento(request);

            // Assert
            // Verifica se o resultado bruto é igual ao valor esperado
            Assert.Equal(20194.4, result.ResultadoBruto, 8);

            // Verifica se o resultado líquido é igual ao valor esperado
            Assert.Equal(20150.66, result.ResultadoLiquido, 8);
        }

        [Theory]
        [InlineData(20000, 1, 194.39999999999782)]
        public void CalcularCDB_ShouldCalculateCorrectly(double valorInicial, int meses, double expectedResult)
        {
            var cdbService = new CdbService();
            // Act
            double result = cdbService.CalcularCDB(valorInicial, meses);

            // Assert
            Assert.Equal(expectedResult, result, 8);
        }

        [Theory]
        [InlineData(20000, 1, 4500)]
        public void CalcularImposto_ShouldCalculateCorrectly(double rendimento, int meses, double expectedResult)
        {
            var cdbService = new CdbService();
            // Act
            double result = cdbService.CalcularImposto(rendimento, meses);

            // Assert
            Assert.Equal(expectedResult, result, 8);
        }
    }
}
