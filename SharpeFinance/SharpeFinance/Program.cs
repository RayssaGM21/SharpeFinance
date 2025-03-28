using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> contas = new List<string>();

        Console.WriteLine("Digite o nome da sua conta:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o saldo da sua conta:");
        string saldo = Console.ReadLine();

        contas.Add($"Nome: {nome} Saldo: {saldo}");

        Console.WriteLine("Sua conta foi cadastrada!");

        foreach (var conta in contas)
        {
            Console.WriteLine(conta);
        }
    }
}