namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public int IdMovimento { get; set; }
        public int IdContaCorrente { get; set; }
        public string DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public decimal Valor { get; set; }
        public int Ativo { get; set; }
}
}
