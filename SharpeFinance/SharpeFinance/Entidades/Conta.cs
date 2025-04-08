namespace SharpeFinance.Entidades
{
    public class Conta
    {
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public void AdicionarTransacao(Transacao transacao)
        {
            if (transacao.Tipo == TipoTransacao.Despesa && Saldo - transacao.Valor < 0)
                throw new InvalidOperationException("Não é possível registrar a despesa. Saldo insuficiente.");

            if (transacao.Data.Month < DateTime.Now.Month && transacao.Data.Year <= DateTime.Now.Year)
                throw new InvalidOperationException("Data inválida!");

            Transacoes.Add(transacao);

            if (transacao.Tipo == TipoTransacao.Receita)
                Saldo += transacao.Valor;
            else
                Saldo -= transacao.Valor;
        }
    }
}
