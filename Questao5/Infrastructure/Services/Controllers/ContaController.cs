using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands;
using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("Saldo")]
        public async Task<IActionResult> Get(int idConta)
        {
            var query = new ConsultarSaldoCommand()
            {
                IdContaCorrente = idConta
            };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("Movimentacao")]
        public async Task<IActionResult> Post(MovimentarContaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}