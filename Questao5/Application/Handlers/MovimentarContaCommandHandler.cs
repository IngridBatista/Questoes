using MediatR;
using Questao5.Application.Commands;
using Questao5.Domain.Entities;
using Questao5.Domain.Interface;

namespace Questao5.Application.Handlers
{
    public class MovimentarContaCommandHandler : IRequestHandler<MovimentarContaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IMovimentoService _service;
        public MovimentarContaCommandHandler(IMediator mediator, IMovimentoService service)
        {
            this._mediator = mediator;
            this._service = service;
        }

        public async Task<string> Handle(MovimentarContaCommand request, CancellationToken cancellationToken)
        {
            var movimentarConta = new Movimento
            {
                IdMovimento = request.IdTransação,
                IdContaCorrente = request.IdContaCorrente,
                DataMovimento = DateTime.UtcNow.ToString(),
                TipoMovimento = request.TipoTransacao,
                Valor = request.Valor
            };

            try
            {
                await _service.EfetuarTransacao(movimentarConta);

                await _mediator.Publish(new MovimentacaoRealizadaNotification
                {
                    IdMovimentacao = movimentarConta.IdMovimento,
                    IdContaCorrente = movimentarConta.IdContaCorrente,
                    TipoTransacao = movimentarConta.TipoMovimento,
                    Valor = movimentarConta.Valor
                });

                return await Task.FromResult("Conta movimentada com sucesso.");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new MovimentacaoRealizadaNotification
                {
                    IdMovimentacao = movimentarConta.IdMovimento,
                    IdContaCorrente = movimentarConta.IdContaCorrente,
                    TipoTransacao = movimentarConta.TipoMovimento,
                    Valor = movimentarConta.Valor
                });
                await _mediator.Publish(new ErroNotification
                {
                    Excecao = ex.Message,
                    PilhaErro = ex.StackTrace
                });

                return await Task.FromResult("Ocorreu um erro no momento da movimentação de conta.");
            }
        }
    }
}
