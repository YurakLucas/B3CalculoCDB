using B3CalculoCDB.Features.Queries;
using B3CalculoCDB.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace B3CalculoCDB.Features.CDB
{
    [Route("api/[controller]")]
    [ApiController]    
    public class CdbController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CdbController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("calcular")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestimentoResponse))]
        public async Task<IActionResult> CalcularInvestimento([FromBody] InvestimentoRequest request)
        {
            var response = await _mediator.Send(new CalcularCdbQuery
            {
                Valor = request.Valor,
                Prazo = request.Prazo
            });

            return Ok(response);
        }
    }
}
