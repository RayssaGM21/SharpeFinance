using SharpeFinance;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void exibeContas(List<Conta> contas)
    {
        int contador = 0;
        foreach (var conta in contas)
        {
            Console.WriteLine($"({contador}) Nome: {conta.Nome} - Saldo: {conta.Saldo}");
            contador++;    
        }
    }
    public static void Main(string[] args)
    {
        /* Cadastrar conta */

        List<Conta> contas = new List<Conta>();
        Boolean x = true;
        while (x == true) { 
            Console.WriteLine("Digite o nome da sua conta:");
            string nomeConta = Console.ReadLine();

            Console.WriteLine("Digite o saldo da sua conta:");
            decimal saldoConta = Convert.ToDecimal(Console.ReadLine());

            contas.Add(new Conta { Nome = nomeConta, Saldo = saldoConta});

            Console.WriteLine("Sua conta foi cadastrada com sucesso!");
            Console.WriteLine("Deseja continuar cadastrando uma conta (SIM ou NÃO)?");
            string opcao = Console.ReadLine();
            if (opcao == "SIM")
            {
                x = true;
            }
            else
            {
                x = false;
            }

        }
        /* Exibir Contas */
        exibeContas(contas);

        /* Cadastrar transação */
        Console.WriteLine("Digite o índice da conta pela qual você deseja fazer a transação: ");
        int indiceConta = Convert.ToInt32(Console.ReadLine());

        
            Console.WriteLine(indiceConta);
            if ((indiceConta <= contas.Count) && (indiceConta >= 0)) { 
                var conta_escolhida = contas[indiceConta];
                Console.WriteLine($"Nome da conta: {conta_escolhida.Nome}");

                Console.WriteLine("Digite o tipo de transação que você deseja realizar (Receita ou Despesa) : ");
                string tipoTransacao = Console.ReadLine();
            
                 Console.WriteLine("Digite o valor da transação a ser realizada: ");
                 decimal valorTransacao = Convert.ToDecimal(Console.ReadLine());

                 Console.WriteLine("Digite uma descrição para a transação: ");
                 string descricaoTransacao = Console.ReadLine();

                 Console.WriteLine("Digite uma data para que a transação possa ser realizada: ");
                 string dataTransacao = Console.ReadLine();

            DateTime data;
            if (DateTime.TryParseExact(dataTransacao, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
            {
                Console.WriteLine($"Data Transação: " + data.ToString("dd/MM/yyyy"));
            }
            else
            {
                Console.WriteLine("Data inválida!");
            }

            if (tipoTransacao == "Receita")
            {
                conta_escolhida.Saldo += valorTransacao;
                Console.WriteLine($"Conta após a transação: Nome da conta: {conta_escolhida.Nome} - Novo saldo da conta: {conta_escolhida.Saldo}");
            }
            else if (tipoTransacao == "Despesa")
            {
                conta_escolhida.Saldo -= valorTransacao;
                Console.WriteLine($"Conta após a transação: Nome da conta: {conta_escolhida.Nome} - Novo saldo da conta: {conta_escolhida.Saldo}");
            }
            else
            {
                Console.WriteLine("Transação inválida!");
            }

            }
            else
            { 
                Console.WriteLine("Índice inválido!");
            }

        /*//** Cadastrar transação *//*
        Console.WriteLine("Digite o índice da conta pela qual você deseja fazer a transação: ");
        int contaEscolhida = Convert.ToInt32(Console.ReadLine());

        ;*/

    }
}