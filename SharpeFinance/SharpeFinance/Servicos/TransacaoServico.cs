using SharpeFinance.Entidades;
using System.Globalization;


namespace SharpeFinance.Servicos
{
    public class TransacaoServico
    {

        public static void CadastrarTransacao(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada ainda.");
                return;
            }

            ContaServico.ExibirContas(contas);
            Console.Write("Digite o índice da conta para transação: ");
            Console.Write("Digite o índice da conta para transação: ");
            int indiceConta = Convert.ToInt32(Console.ReadLine());
            
            if (indiceConta >= 0 && indiceConta > contas.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }
            var conta = contas[indiceConta - 1];
            Console.WriteLine($"\nConta selecionada: {conta.Nome}");

            Console.Write("\nDigite o tipo de transação (Receita ou Despesa): ");
            string tipoInput = Console.ReadLine();


            if (!Enum.TryParse<TipoTransacao>(tipoInput, true, out TipoTransacao tipo) || !Enum.IsDefined(typeof(TipoTransacao), tipo))
            {
                Console.WriteLine("Tipo inválido!");
                return;
            }

            Console.Write("Digite o valor da transação: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido!");
                return;
            }

            Console.Write("Digite a descrição da transação: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data da transação (dd/MM/yyyy): ");
            string dataStr = Console.ReadLine();

            if (!DateTime.TryParseExact(dataStr, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime data))
            {
                Console.WriteLine("Data inválida!");
                return;
            }

            try
            {
                conta.AdicionarTransacao(new Transacao
                {
                    Tipo = tipo,
                    Valor = valor,
                    Descricao = descricao,
                    Data = data
                });

                Console.WriteLine("Transação cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar transação: " + ex.Message);
            }
        }



        public static void ExibirSaldos(List<Conta> contas)
        {
            decimal saldoTotal = 0;
            Console.WriteLine("\n--- Saldos por Conta ---");
            foreach (var conta in contas)
            {
                Console.WriteLine($"{conta.Nome}: {conta.Saldo:C}");
                saldoTotal += conta.Saldo;
            }
            Console.WriteLine($"Saldo total: {saldoTotal:C}");
        }

        public static void ListarTransacoes(List<Conta> contas)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            ContaServico.ExibirContas(contas);
            Console.Write("Digite o índice da conta: ");
            int indiceConta;
            if (!int.TryParse(Console.ReadLine(), out indiceConta) || indiceConta < 0 || indiceConta >= contas.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            var conta = contas[indiceConta];

            Console.Write("Deseja ver (Todas / Receita / Despesa): ");
            string filtroTipo = Console.ReadLine();
            TipoTransacao? tipoFiltro = null;

            if (filtroTipo.Equals("Receita", StringComparison.OrdinalIgnoreCase))
                tipoFiltro = TipoTransacao.Receita;
            else if (filtroTipo.Equals("Despesa", StringComparison.OrdinalIgnoreCase))
                tipoFiltro = TipoTransacao.Despesa;

            Console.Write("Deseja filtrar por mês? Digite o número do mês (1 a 12) ou deixe vazio: ");
            string mesStr = Console.ReadLine();
            int? mes = string.IsNullOrEmpty(mesStr) ? null : int.Parse(mesStr);

            Console.WriteLine("\n--- Transações ---");
            foreach (var t in conta.Transacoes)
            {
                if ((tipoFiltro == null || t.Tipo == tipoFiltro) &&
                    (mes == null || t.Data.Month == mes))
                {
                    Console.WriteLine($"{t.Data:dd/MM/yyyy} - {t.Tipo} - {t.Descricao} - {t.Valor:C}");
                }
            }
        }
    }
}
