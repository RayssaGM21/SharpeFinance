using SharpeFinance.Entidades;
using SharpeFinance.Servicos;

public class Program
{
    public static void Main(string[] args)
    {
        List<Conta> contas = new List<Conta>();
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();

            Console.WriteLine("======= MENU =======");
            Console.WriteLine("1. Cadastrar Conta");
            Console.WriteLine("2. Cadastrar Transação");
            Console.WriteLine("3. Exibir Saldo por Conta e Total");
            Console.WriteLine("4. Listar Transações");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ContaServico.CadastrarConta(contas);
                    PausarServico.Pausar();
                    break;
                case "2":
                    TransacaoServico.CadastrarTransacao(contas);
                    PausarServico.Pausar();
                    break;
                case "3":
                    TransacaoServico.ExibirSaldos(contas);
                    PausarServico.Pausar();
                    break;
                case "4":
                    TransacaoServico.ListarTransacoes(contas);
                    PausarServico.Pausar();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    PausarServico.Pausar();
                    break;
            }
        }
    }
}
