using Questao5.Application.Commands;
using Questao5.Domain.Entities;
using Questao5.Domain.Interface;
using Questao5.Infrastructure.Database;

namespace Questao5.Domain.Service
{
    public class MovimentoService : IMovimentoService
    {
        private readonly IRepository<Movimento> _repository;

        public MovimentoService(IRepository<Movimento> repository)
        {
            this._repository = repository;
        }

        public async Task EfetuarTransacao(Movimento movimento)
        {
            var conta = await _repository.Get(movimento.IdContaCorrente);
            if (conta != null)
            {
                if (Convert.ToBoolean(conta.Ativo))
                {
                    if (movimento.Valor > 0)
                    {
                        if (movimento.TipoMovimento == 'C' || movimento.TipoMovimento == 'D')
                        {
                            await _repository.Add(movimento);

                        }

                    }
                }

            }
        }
    }
}
