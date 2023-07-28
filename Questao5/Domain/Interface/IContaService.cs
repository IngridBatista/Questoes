using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database;

namespace Questao5.Domain.Interface
{
    public interface IContaService
    {
        Task<decimal> ConsultarSaldo(int idContaCorrente);
    }
}
