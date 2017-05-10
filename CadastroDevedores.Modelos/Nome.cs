using System;

namespace CadastroDevedores.Modelos
{
    public class Nome : Attribute
    {
        public string Descricao { get; set; }

        public Nome(string descricao)
        {
            Descricao = descricao;
        }
    }
}
