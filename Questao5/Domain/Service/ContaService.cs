using Questao5.Application.Dto;
using Questao5.Domain.Entities;
using Questao5.Domain.Interface;
using Questao5.Infrastructure.Database;

namespace Questao5.Domain.Service
{
    public class ContaService : IContaService
    {
        private readonly IRepository<Conta> _contaRepository;
        private readonly IRepository<Movimento> _movimentoRepository;

        public ContaService(IRepository<Conta> contaRepository, IRepository<Movimento> movimentoRepository)
        {
            this._movimentoRepository = movimentoRepository;
            this._contaRepository = contaRepository;
        }

        public async Task<decimal> ConsultarSaldo(int idContaCorrente)
        {
            var conta = await _contaRepository.Get(idContaCorrente);
            if (conta != null && Convert.ToBoolean(conta.Ativo))
            {
                var transacoes = await GetMovimentacao(idContaCorrente);
                if (transacoes != null && transacoes.Count > 0)
                {
                    var contaRetorno = new ResponseContaDto()
                    {
                        NumeroConta = conta.Numero,
                        Titular = conta.Nome.ToString(),
                        DataResposta = DateTime.Now,
                        Saldo = CalculaSaldo(transacoes)
                    };
                }
            }

            return default;
        }

        private async Task<List<Movimento>> GetMovimentacao(int idContaCorrente)
        {
            return await _movimentoRepository.GetByIdConta(idContaCorrente);
        }

        private decimal CalculaSaldo(List<Movimento> transacoes)
        {
            decimal somaCredito = 0;
            decimal somaDebito = 0;

            foreach (var item in transacoes)
            {
                if (item.TipoMovimento == 'C')
                {
                    somaCredito += item.Valor;
                }
                somaDebito -= item.Valor;
            }

            decimal saldo = somaCredito - somaDebito;
            return saldo;
        }
    }
}
