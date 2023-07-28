using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class MovimentoRepository : IRepository<Movimento>
    {
        public Task Add(Movimento item)
        {
            throw new NotImplementedException();
        }

        public Task<Movimento> Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Movimento>> IRepository<Movimento>.GetByIdConta(int idContaCorrente)
        {
            throw new NotImplementedException();
        }
    }
}
