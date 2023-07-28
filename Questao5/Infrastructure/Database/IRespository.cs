namespace Questao5.Infrastructure.Database
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);

        Task Add(T item);

        Task<List<T>> GetByIdConta(int idContaCorrente);
    }
}
