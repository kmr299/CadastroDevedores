using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace CadastroDevedores.Data
{
    public abstract class BaseData
    {
        private readonly string _conexao;
        private readonly string _provider;

        public BaseData()
        {
            _conexao = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
            _provider = ConfigurationManager.ConnectionStrings["Conexao"].ProviderName;
        }

        public IDbConnection GetConexao()
        {
            return new SqlConnection(_conexao);
        }
    }
}
