using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDevedores.Utilidades
{
    public static class ConsoleUtils
    {
        public static void ImprimeCabecalho(string nome, params object[] args)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("            " + nome.ToUpper(), args);
            Console.WriteLine("=========================================");
        }

        public static void ImprimeLinha(string character, int tamanho)
        {
            var linha = string.Empty;
            for (var i = 0; i < tamanho; i++)
                linha += character;

            Console.WriteLine(linha);
        }

        public static void PressioneQualquerTeclaParaContinuar()
        {
            Console.WriteLine("[Pressione qualquer tecla para continuar]");
            Console.ReadKey();
        }
    }
}
