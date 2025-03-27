using static System.Net.Mime.MediaTypeNames;

public class Program
{
    private static List<conta> contas = new List<conta>();
    public static void CadastrarConta()
    {
        Console.WriteLine("Digite o nome do seu banco:");
        string nome = Console.ReadLine();

        Console.Write("Digite o seu saldo atual:");
        string saldo = Console.ReadLine();

        List<conta> saldo_total = new List<conta>();
        contas.Add(new conta(nome, saldo_total));

        Console.WriteLine("Sua Conta foi cadastrada!");

        for conta in contas
        {
            Console.WriteLine(CadastrarConta[0], conta[1]);
        }

        Console.WriteLine($nome{ nome}
        { saldo_total}
        ");
    }
    public static void Main(string[] args)
    {
        CadastrarConta();
    }
}
