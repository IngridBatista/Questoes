using MediatR;

namespace Questao5.Application.Handlers
{
    public class MovimentacaoRealizadaNotification : INotification
    {
        public int IdMovimentacao { get; set; }
        public int IdContaCorrente { get; set; }
        public char TipoTransacao { get; set; }
        public decimal Valor { get; set; }
    }
}
