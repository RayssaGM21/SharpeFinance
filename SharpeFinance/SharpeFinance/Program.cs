using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void exibeContas(List<List<(string, decimal)>> contas)
    {
        int contador = 0;
        foreach (var conta in contas)
        {
            foreach (var item in conta)
            {
                Console.WriteLine($"{contador}) {item}");
                contador++;
            }
        }
    }
    public static void Main(string[] args)
    {
        /*
            [[nubank, 235.70], [banco do brasil, 1300], [bradesco, 45]]
        */

        List<List<(string, decimal)>> contas = new List<List<(string, decimal)>>();
        Boolean x = true;
        while (x == true) { 
            Console.WriteLine("Digite o nome da sua conta:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o saldo da sua conta:");
            decimal saldo = Convert.ToDecimal(Console.ReadLine());

            contas.Add([(nome, saldo)]);

            Console.WriteLine("Sua conta foi cadastrada com sucesso!");
            Console.WriteLine("Deseja continuar cadastrando uma conta (SIM ou NAO)?");
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
        

        Console.WriteLine("Qual tipo de transação você deseja realizar (Receita ou Despesa):");
        string tipo_transacao = Console.ReadLine();

        Console.WriteLine("Digite o valor da transação:");
        decimal valor_transacao = Convert.ToDecimal(Console.ReadLine());

        exibeContas(contas);

        if (tipo_transacao == "Receita")
        {

        }
    }
}