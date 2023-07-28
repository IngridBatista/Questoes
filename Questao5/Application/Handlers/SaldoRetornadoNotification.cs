namespace Questao5.Application.Handlers
{
    public class SaldoRetornadoNotification
    {
        public int IdContaCorrente { get; set; }
        public char TipoMovimentacao { get; set; }
        public int Numero { get; set; }
        public int Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
