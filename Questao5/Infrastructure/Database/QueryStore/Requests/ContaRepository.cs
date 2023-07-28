using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class ContaRepository : IRepository<Conta>
    {
        public Task Add(Conta item)
        {
            throw new NotImplementedException();
        }

        public Task<Conta> Get(int id)
        {
            throw new NotImplementedException();
        } 

        public Task<List<Conta>> GetByIdConta(int idContaCorrente)
        {
            throw new NotImplementedException();
        }
    }
}
