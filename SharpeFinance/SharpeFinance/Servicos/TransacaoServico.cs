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
            int indiceConta;
            try {
                indiceConta = Convert.ToInt32(Console.ReadLine());

                if (indiceConta <= 0 || indiceConta > contas.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }
            var conta = contas[indiceConta - 1];
            Console.WriteLine($"\nConta selecionada: {conta.Nome}");

            Console.Write("\nDigite o tipo de transação (Receita ou Despesa): ");
            string tipoInput = Console.ReadLine();

            // Tenta converter a string 'tipoInput' para um valor válido do enum 'TipoTransacao' (ignorando maiúsculas/minúsculas),
            // e verifica se o valor convertido é um valor válido dentro do enum 'TipoTransacao'. Se falhar em qualquer uma dessas verificações,
            // retorna 'true' (indicando que o tipo é inválido).
            if (!Enum.TryParse<TipoTransacao>(tipoInput, true, out TipoTransacao tipo) || !Enum.IsDefined(typeof(TipoTransacao), tipo))
            {
                Console.WriteLine("Tipo inválido!");
                return;
            }

            decimal valor;
            Console.Write("Digite o valor da transação: ");
            try
            {
                valor = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
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
                Console.WriteLine($"{conta.Nome}: {conta.Saldo.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
                saldoTotal += conta.Saldo;
            }
            Console.WriteLine($"Saldo total: {saldoTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
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
            try
            {
                indiceConta = Convert.ToInt32(Console.ReadLine());
                if (indiceConta <= 0 || indiceConta > contas.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    return;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            var conta = contas[indiceConta - 1];

            Console.Write("Deseja ver (Todas / Receita / Despesa): ");
            string filtroTipo = Console.ReadLine();
            TipoTransacao? tipoFiltro = null;

            if (filtroTipo.ToLower() == "receita")
            {
                tipoFiltro = TipoTransacao.Receita;
            }

            else if (filtroTipo.ToLower() == "despesa")
            {
                tipoFiltro = TipoTransacao.Despesa;
            }

            Console.Write("Deseja filtrar por mês? Digite o número do mês (1 a 12) ou deixe vazio: ");
            string mesStr = Console.ReadLine();
            int? mes = string.IsNullOrEmpty(mesStr) ? null : int.Parse(mesStr);

            Console.WriteLine("\n--- Transações ---");

            foreach (var tipo in conta.Transacoes)
            {
                if ((tipoFiltro == null || tipo.Tipo == tipoFiltro) &&
                    (mes == null || tipo.Data.Month == mes))
                {
                    Console.WriteLine($"{tipo.Data:dd/MM/yyyy} - {tipo.Tipo} - {tipo.Descricao} - {tipo.Valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
                }
            }
        }
    }
}
