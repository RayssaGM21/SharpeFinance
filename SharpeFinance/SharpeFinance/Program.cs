using static System.Net.Mime.MediaTypeNames;

public class Program
{
    private static List<string> conta = new List<string>();
    public static void CadastrarConta()
    {
        Console.WriteLine("Digite o nome do seu banco:");
        string nome = Console.ReadLine();

        Console.Write("Digite o seu saldo atual:");
        string saldo = Console.ReadLine();

        List<string> saldo_total = new List<string>();
        conta.Add(new contas(nome, saldo_total));

        Console.WriteLine("Sua Conta foi cadastrada!");

        for contas in conta
        {
            Console.WriteLine(CadastrarConta[0], conta[1]);
        }

        Console.WriteLine($"Nome: {contas.nome}, Saldo:{ contas.saldo_total} ");
    }
    public static void Main(string[] args)
    {
        CadastrarConta();
    }
}
