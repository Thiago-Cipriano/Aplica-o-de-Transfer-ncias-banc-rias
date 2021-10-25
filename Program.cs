using System;
using System.Collections.Generic;

namespace Dio.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        }

        private static void Transferir()
        {
            Console.Write("Digite a conta de origem:");
            int indiceContadeOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite a conta destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido:");
            double ValorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContadeOrigem].Transferir(ValorTransferencia, listContas[indiceContaDestino]);

        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(ValorDeposito);

        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double ValorSaque = int.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(ValorSaque);
        }

        private static void listarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);
            }


        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para pessoa fisica ou 2 para pessoa jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digiteo o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)entradaTipoConta,
                                     entradaSaldo,
                                     entradaCredito,
                                     entradaNome);

            listContas.Add(novaConta);

        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("DioBank ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 Listar contas");
            Console.WriteLine("2 Inserir nova conta");
            Console.WriteLine("3 Transferir");
            Console.WriteLine("4 Sacar");
            Console.WriteLine("5 Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }

    }
}