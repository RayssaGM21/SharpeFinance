namespace SharpeFinance.Entidades
{
    public enum TipoTransacao
    {
        Receita,
        Despesa
    }
    public class Transacao
    {
        public TipoTransacao Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
