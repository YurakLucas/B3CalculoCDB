using B3CalculoCDB.Features.CDB.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace B3CalculoCDB.Tests
{
    [TestClass]
    public class CalcularCdbCommandTests
    {
        [Fact]
        [TestMethod]
        public void CalcularCdbCommand_Should_SetPropertiesCorrectly()
        {
            // Arrange
            double valor = 1000;
            int prazo = 6;

            // Act
            var command = new CalcularCdbCommand
            {
                Valor = valor,
                Prazo = prazo
            };

            // Assert
            Assert.AreEqual(valor, command.Valor);
            Assert.AreEqual(prazo, command.Prazo);
        }
    }
}

