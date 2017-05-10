using CadastroDevedores.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDevedores.Utilidades
{
    public static class ListaUtils<T> where T : class
    {
        /// <summary>
        /// Imprime uma lista no console
        /// </summary>
        /// <param name="lista">Lista de objetos para impressão</param>
        public static void ImprimeLista(IEnumerable<T> lista)
        {
            //Limpa o console
            Console.Clear();

            //Busca o tipo
            var type = typeof(T);
            //Busca as propriedadades do tipo
            var props = type.GetProperties();

            //Imprime um cabeçalho
            ConsoleUtils.ImprimeCabecalho(" Todos clientes ({0})" + type.Name, lista.Count());

            var linhas = new List<List<string>>();

            var cabecalho = new List<string>();
            //Instancia uma lista de linhas com uma lista de colunas
            foreach (var prop in props)
            {
                var nomeAttributo = prop.GetCustomAttributes(typeof(Nome), true);

                if(nomeAttributo != null && nomeAttributo.FirstOrDefault() != null)
                {
                    var descricao = ((Nome)nomeAttributo.FirstOrDefault()).Descricao;
                    if (descricao != null)
                    {
                        cabecalho.Add(descricao);
                        continue;
                    }
                }
                cabecalho.Add(prop.Name);
            }

            linhas.Add(cabecalho);

            //Adiciona o conteudo no array
            foreach (var item in lista)
            {
                var data = new List<string>();
                for (var i = 0; i < props.Length; i++)
                {
                    var prop = props[i];
                    var value = prop.GetValue(item);
                    if (value == null)
                        data.Add(" -- ");
                    else
                        data.Add(value.ToString());
                }
                linhas.Add(data);
            }

            //Incializa array com tamanhos de coluna
            var counts = new int[props.Length];

            //Busca o tamanho por coluna
            for (var l = 0; l < linhas.Count; l++)
            {
                for (var i = 0; i < linhas[l].Count; i++)
                {
                    if (counts[i] < linhas[l][i].Length)
                        counts[i] = linhas[l][i].Length;
                }
            }

            Console.WriteLine("");
            var total = counts.Select(x => x + 3).Sum() + 1;
            ConsoleUtils.ImprimeLinha("-", total);

            //Faz um loop nas linhas
            foreach (var linha in linhas)
            {
                //Faz a impressão das linhas separadas por |
                var i = 0;
                Console.WriteLine("|" + string.Join("|", linha
                    .Select(x =>
                    {
                        var resultado = GetStringComEspacos(x, counts[i]);
                        i++;
                        return resultado;
                    })) + "|");
                ConsoleUtils.ImprimeLinha("-", total);
            }

            //Aguarda ação do usuário
            ConsoleUtils.PressioneQualquerTeclaParaContinuar();
        }

        private static string GetStringComEspacos(string valor, int tamanho)
        {
            var result = valor;
            if (result.Length < tamanho)
            {
                for (var i = 0; i < tamanho - valor.Length; i++)
                    result += " ";
            }
            return $" {result} ";
        }
    }
}
