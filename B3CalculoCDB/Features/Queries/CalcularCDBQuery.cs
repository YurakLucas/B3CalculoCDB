using B3CalculoCDB.Models;
using MediatR;

namespace B3CalculoCDB.Features.Queries
{
    public class CalcularCdbQuery : IRequest<InvestimentoResponse>
    {
        public double Valor { get; set; }
        public int Prazo { get; set; }
    }
}
