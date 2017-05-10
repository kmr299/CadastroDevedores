using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDevedores.Data
{
    public class GenericData<T> : BaseData where T : class
    {
        public string GetTableName()
        {
            var type = typeof(T);
            return type.Name + "s";
        }

        public int BuscarTotal()
        {
            var type = typeof(T);

            var sql = "SELECT COUNT(*) FROM " + GetTableName();

            using (var conexao = GetConexao())
            {
                return conexao.QueryFirst<int>(sql);
            }
        }

        public void Inserir(T obj)
        {
            var type = typeof(T);

            var props = type.GetProperties()
                .Where(x => x.Name != type.Name + "Id")
            .Select(x => x.Name);

            var sql = string.Format(
                "INSERT INTO " + GetTableName() + " ({0}) VALUES ({1})",
                string.Join(",", props),
                string.Join(",", props.Select(x => "@" + x))
                );

            using (var conexao = GetConexao())
            {
                conexao.Execute(sql, obj);
            }
        }

        public IEnumerable<T> BuscarTodos()
        {
            var sql = "SELECT * FROM " + GetTableName();

            using (var conexao = GetConexao())
            {
                return conexao.Query<T>(sql).ToList();
            }
        }
    }
}
