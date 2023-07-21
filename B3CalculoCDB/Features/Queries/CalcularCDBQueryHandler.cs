using B3CalculoCDB.Features.CDB;
using B3CalculoCDB.Models;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace B3CalculoCDB.Features.Queries
{
    public class CalcularCdbQueryHandler : IRequestHandler<CalcularCdbQuery, InvestimentoResponse>
    {
        private readonly ICdbService _cdbService;

        public CalcularCdbQueryHandler(ICdbService cdbService)
        {
            _cdbService = cdbService;
        }

        public Task<InvestimentoResponse> Handle(CalcularCdbQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_cdbService.CalcularInvestimento(new InvestimentoRequest
            {
                Valor = request.Valor,
                Prazo = request.Prazo
            }));
        }
    }
}
