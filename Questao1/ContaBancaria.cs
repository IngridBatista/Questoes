namespace Questao1
{
    class ContaBancaria
    {
        public int Numero { get; }
        public string Titular { get; set; }
        private double Saldo { get; set; }

        public ContaBancaria(int numero, string titular)
        {
            this.Numero = numero;
            this.Titular = titular;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = depositoInicial;
        }

        internal void Saque(double quantia)
        {
            var taxa = 3.50;
            this.Saldo -= quantia;
            AplicarTaxa(this.Saldo, taxa);
        }

        internal void Deposito(double quantia)
        {
            this.Saldo += quantia;
        }

        internal void AplicarTaxa(double saldo, double taxa)
        {
            this.Saldo -= taxa;
        }

        public override string ToString()
        {
            return $"Conta {this.Numero}, Titular: {this.Titular}, Saldo: ${this.Saldo}";
        }
    }
}
