using System;

namespace CadastroDevedores.Utilidades
{
    public static class CadastroUtils<T> where T : class
    {
        public static void GetCadastro(T obj)
        {
            Console.Clear();

            var type = typeof(T);
            var props = type.GetProperties();

            ConsoleUtils.ImprimeCabecalho("Cadastrar " + type.Name);

            foreach (var prop in props)
            {
                if (type.Name + "Id" == prop.Name)
                    continue;

                Console.WriteLine("Insira o {0}:", prop.Name);
                var input = Console.ReadLine();
                var value = Convert.ChangeType(input, prop.PropertyType);
                prop.SetValue(obj, value);

            }
        }
    }
}
