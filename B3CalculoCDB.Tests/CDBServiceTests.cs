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
        [InlineData(22000, 11, 2469.95809654)]
        [InlineData(23000, 13, 3081.96441735)]
        [InlineData(20000, 14, 2900.41835782)]
        [InlineData(20200, 20, 4311.53684432)]
        [InlineData(34000, 18, 6466.54928037)]
        [InlineData(50500, 48, 29841.02938238)]
        [InlineData(10020, 45, 5464.98751193)]
        [InlineData(40070, 7, 2807.16404297)]
        public void CalcularCDB_ShouldCalculateCorrectly(double valorInicial, int meses, double expectedResult)
        {
            var cdbService = new CdbService();
            // Act
            double result = cdbService.CalcularCDB(valorInicial, meses);

            // Assert
            Assert.Equal(expectedResult, result, 8);
        }

        [Theory]
        [InlineData(20000, 12, 4000)]
        [InlineData(10000, 7, 2000)]
        [InlineData(47000, 6, 10575)]
        [InlineData(52000, 5, 11700)]
        [InlineData(20000, 11, 4000)]
        [InlineData(80000, 3, 18000)]
        [InlineData(60000, 7, 12000)]
        [InlineData(40000, 4, 9000)]
        [InlineData(30000, 6, 6750)]
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
