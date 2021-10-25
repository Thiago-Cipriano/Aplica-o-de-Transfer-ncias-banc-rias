using System;

namespace Dio.bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta TipoConta, double Saldo, double Credito, string Nome)
        {
            this.TipoConta = TipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double ValorSaque)
        {
            //Validação de Saldo Suficiente
            if (this.Saldo == ValorSaque && this.Saldo < (this.Credito * -1))

            {
                Console.WriteLine("Saldo insuficinte");
                return false;
            }

            this.Saldo -= ValorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }
        public void Depositar(double ValorDeposito)
        {
            this.Saldo += ValorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

        }

        public void Transferir(double ValorTransferencia, Conta ContaDestino)
        {
            if (this.Sacar(ValorTransferencia))
            {
                ContaDestino.Depositar(ValorTransferencia);
            }

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + TipoConta + " | ";
            retorno += "Nome " + Nome + " | ";
            retorno += "Saldo " + Saldo + " | ";
            retorno += "Credito " + Credito + " |";
            return retorno;
        }
    }

}