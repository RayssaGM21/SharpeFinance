using static System.Net.Mime.MediaTypeNames;

public class Program
{
    private static List<string> conta = new List<string>();
    public static void CadastrarConta()
    {
        Console.WriteLine("Digite o nome do seu banco:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o seu saldo atual:");
        string saldo = Console.ReadLine();

        List<string> saldo_total = new List<string>();
        conta.Add(new conta(nome, saldo_total));

        Console.WriteLine("Sua Conta foi cadastrada!");

        foreach conta in conta
        {
            Console.WriteLine(CadastrarConta[0], conta[1]);
        }

        Console.WriteLine($"Nome: {nome}, Saldo:{ saldo_total} ");
    }
    public static void Main(string[] args)
    {
        CadastrarConta();
    }
}
