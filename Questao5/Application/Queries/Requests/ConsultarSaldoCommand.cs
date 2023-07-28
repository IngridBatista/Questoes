using MediatR;

namespace Questao5.Application.Commands.Requests
{
    public class ConsultarSaldoCommand : IRequest<string>
    {
        public int IdContaCorrente { get; set; }
    }
}
