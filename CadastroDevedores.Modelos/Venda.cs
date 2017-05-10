using System;

namespace CadastroDevedores.Modelos
{
    public class Venda
    {
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
    }
}
