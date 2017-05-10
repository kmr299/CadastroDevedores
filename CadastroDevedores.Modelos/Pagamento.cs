namespace CadastroDevedores.Modelos
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public string Valor { get; set; }
    }
}
