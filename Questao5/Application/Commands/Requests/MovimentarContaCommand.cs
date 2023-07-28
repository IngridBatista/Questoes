using MediatR;

namespace Questao5.Application.Commands
{
    public class MovimentarContaCommand : IRequest<string>
    {
        public int IdTransação { get; set; }
        public int IdContaCorrente { get; set; }
        public char TipoTransacao { get; set; }
        public decimal Valor { get; set; }
    }
}
