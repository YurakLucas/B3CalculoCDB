using B3CalculoCDB.Models;
using MediatR;

namespace B3CalculoCDB.Features.CDB.Commands
{
    public class CalcularCdbCommand : IRequest<InvestimentoResponse>
    {
        public double Valor { get; set; }
        public int Prazo { get; set; }
    }
}
