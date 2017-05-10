using System;

namespace CadastroDevedores.Modelos
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NomeCompleto { get; set;}
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
    }
}
