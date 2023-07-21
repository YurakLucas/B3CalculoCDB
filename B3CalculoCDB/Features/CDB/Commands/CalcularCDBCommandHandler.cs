using B3CalculoCDB.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace B3CalculoCDB.Features.CDB.Commands
{
    public class CalcularCdbCommandHandler : IRequestHandler<CalcularCdbCommand, InvestimentoResponse>
    {
        private readonly ICdbService _cdbService;

        public CalcularCdbCommandHandler(ICdbService cdbService)
        {
            _cdbService = cdbService;
        }

        public Task<InvestimentoResponse> Handle(CalcularCdbCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_cdbService.CalcularInvestimento(new InvestimentoRequest
            {
                Valor = request.Valor,
                Prazo = request.Prazo
            }));
        }
    }
}
