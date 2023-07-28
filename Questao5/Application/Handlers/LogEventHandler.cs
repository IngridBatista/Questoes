using MediatR;

namespace Questao5.Application.Handlers
{
    public class LogEventHandler :
                            INotificationHandler<MovimentacaoRealizadaNotification>,
                            INotificationHandler<ErroNotification>
    {
        public Task Handle(MovimentacaoRealizadaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"TRANSAÇÃO: '{notification.IdMovimentacao} - {notification.IdContaCorrente} - {notification.TipoTransacao} - {notification.Valor}'");
            });
        }
        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
            });
        }
    }
}
