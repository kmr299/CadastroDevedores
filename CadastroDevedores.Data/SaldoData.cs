using CadastroDevedores.Modelos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDevedores.Data
{
    public class SaldoData : BaseData
    {
        public IEnumerable<Saldo> BuscarSaldoTodosClientes()
        {
            var sqlVendas = "SELECT                                     " +
            "    c.ClienteId as ClienteId,                              " +
            "    c.NomeCompleto as ClienteNome,                         " +
            "    SUM(v.Valor) as Valor                                  " +
            "FROM Clientes c                                            " +
            "LEFT OUTER JOIN Vendas     v ON v.ClienteId = c.ClienteId  " +
            "GROUP BY c.ClienteId, c.NomeCompleto                       ";


            var sqlPagametos = "SELECT                                  " +
            "    c.ClienteId as ClienteId,                              " +
            "    c.NomeCompleto as ClienteNome,                         " +
            "    SUM(p.Valor) as Valor                                  " +
            "FROM Clientes c                                            " +
            "LEFT OUTER JOIN Pagamentos p ON p.ClienteId = c.ClienteId  " +
            "GROUP BY c.ClienteId, c.NomeCompleto                       ";

            using (var conexao = GetConexao())
            {
                var vendas = conexao.Query<Saldo>(sqlVendas);
                foreach (var v in vendas)
                    v.Valor = v.Valor * -1;


                var todos = new List<Saldo>();
                todos.AddRange(vendas);


                todos.AddRange(conexao.Query<Saldo>(sqlPagametos));

                var resultado = new List<Saldo>();
                foreach (var linha in todos.GroupBy(x => x.ClienteId))
                {
                    var cliente = linha.FirstOrDefault();
                    var saldo = new Saldo();

                    saldo.ClienteId = cliente.ClienteId;
                    saldo.ClienteNome = cliente.ClienteNome;
                    saldo.Valor = linha.Sum(x => x.Valor);

                    resultado.Add(saldo);
                }

                return resultado;
            }
        }
    }
}
