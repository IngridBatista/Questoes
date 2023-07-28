using Questao5.Application.Commands;
using Questao5.Domain.Entities;

namespace Questao5.Domain.Interface
{
    public interface IMovimentoService
    {
        Task EfetuarTransacao(Movimento request);
    }
}
