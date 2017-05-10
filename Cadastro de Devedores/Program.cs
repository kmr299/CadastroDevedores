using CadastroDevedores.Data;
using CadastroDevedores.Modelos;
using CadastroDevedores.Utilidades;
using System;

namespace Cadastro_de_Devedores
{
    class Program
    {
        static void Main(string[] args)
        {
            var clienteData = new GenericData<Cliente>();
            var vendaData = new GenericData<Venda>();
            var pagamentoData = new GenericData<Pagamento>();
            var saldoData = new SaldoData();

            while (true)
            {
                Console.Clear();

                ConsoleUtils.ImprimeCabecalho("Cadastro de Devedores");

                Console.WriteLine("Escolha uma opção:\n" +
                    "0 - Sair\n" +
                    "1 - Cadastrar Cliente \n" +
                    "2 - Listar Clientes (" + clienteData.BuscarTotal() + ") \n" +
                    "3 - Cadastrar Venda \n" +
                    "4 - Listar Vendas (" + vendaData.BuscarTotal() + ")\n" +
                    "5 - Cadastrar Pagamento \n" +
                    "6 - Listar Pagamento (" + pagamentoData.BuscarTotal() + ")\n" +
                    "7 - Saldo por cliente");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {


                    switch (opcao)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            var cliente = new Cliente();
                            CadastroUtils<Cliente>.GetCadastro(cliente);
                            clienteData.Inserir(cliente);
                            break;
                        case 2:
                            var clientes = clienteData.BuscarTodos();
                            ListaUtils<Cliente>.ImprimeLista(clientes);
                            break;
                        case 3:
                            var venda = new Venda();
                            CadastroUtils<Venda>.GetCadastro(venda);
                            vendaData.Inserir(venda);
                            break;
                        case 4:
                            var vendas = vendaData.BuscarTodos();
                            ListaUtils<Venda>.ImprimeLista(vendas);
                            break;
                        case 5:
                            var pagamento = new Pagamento();
                            CadastroUtils<Pagamento>.GetCadastro(pagamento);
                            pagamentoData.Inserir(pagamento);
                            break;
                        case 6:
                            var pagamentos = pagamentoData.BuscarTodos();
                            ListaUtils<Pagamento>.ImprimeLista(pagamentos);
                            break;
                        case 7:
                            var saldos = saldoData.BuscarSaldoTodosClientes();
                            ListaUtils<Saldo>.ImprimeLista(saldos);
                            break;
                        default:
                            continue;
                    }
                }
            }

        }
    }
}
