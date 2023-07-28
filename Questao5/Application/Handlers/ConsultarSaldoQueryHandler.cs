using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Domain.Interface;

namespace Questao5.Application.Handlers
{
    public class ConsultarSaldoQueryHandler : IRequestHandler<ConsultarSaldoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IContaService _service;
        public ConsultarSaldoQueryHandler(IMediator mediator, IContaService service)
        {
            this._mediator = mediator;
            this._service = service;
        }

        public async Task<string> Handle(ConsultarSaldoCommand request, CancellationToken cancellationToken)
        {
            var conta = new Conta
            {
                IdContaCorrente = request.IdContaCorrente,
            };

            try
            {
                var saldo = await _service.ConsultarSaldo(conta.IdContaCorrente);

                await _mediator.Publish(new SaldoRetornadoNotification
                {
                    IdContaCorrente = conta.IdContaCorrente,
                    TipoMovimentacao = conta.TipoMovimentacao,
                    Numero = conta.Numero,
                    Nome = conta.Nome,
                    Ativo = conta.Ativo
                });

                return await Task.FromResult("Saldo retornado com sucesso.");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new SaldoRetornadoNotification
                {
                    IdContaCorrente = conta.IdContaCorrente,
                    TipoMovimentacao = conta.TipoMovimentacao,
                    Numero = conta.Numero,
                    Nome = conta.Nome,
                    Ativo = conta.Ativo
                });
                await _mediator.Publish(new ErroNotification
                {
                    Excecao = ex.Message,
                    PilhaErro = ex.StackTrace
                });

                return await Task.FromResult("Ocorreu um erro durante a consulta de saldo.");
            }
        }
    }
}
