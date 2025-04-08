using SharpeFinance.Entidades;
using System.Globalization;

namespace SharpeFinance.Servicos
{
    public class ContaServico
    {
        public static void CadastrarConta(List<Conta> contas)
        {
            Console.Write("Digite o nome da sua conta: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inicial da conta: ");
            decimal saldoInicial;

            while (true)
            {
                try
                {
                    saldoInicial = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Valor inválido. Digite novamente: ");
                }
            }

            contas.Add(new Conta { Nome = nome, Saldo = saldoInicial });
            Console.WriteLine("Conta cadastrada com sucesso!");
        }

        public static void ExibirContas(List<Conta> contas)
        {
            for (int i = 0; i < contas.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {contas[i].Nome} - Saldo: {contas[i].Saldo.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
            }
        }
    }
}
