namespace CadastroDevedores.Modelos
{
    public class Saldo
    {
        [Nome("Identificador")]
        public int ClienteId { get; set; }
        [Nome("Cliente")]
        public string ClienteNome { get; set; }
        [Nome("Saldo")]
        public decimal Valor { get; set; }
    }
}
