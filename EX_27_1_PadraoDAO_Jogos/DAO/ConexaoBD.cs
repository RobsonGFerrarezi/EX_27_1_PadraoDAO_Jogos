using System.Data.SqlClient;
using System.Data;

namespace EX_27_1_PadraoDAO_Jogos.DAO
{
    internal static class ConexaoBD
    {
        internal static SqlConnection GetConexao()
        {
            string strConexao = "Data Source=LOCALHOST;Initial Catalog=AULADB;user id=sa; password=123456";
            SqlConnection conexao = new SqlConnection(strConexao);
            conexao.Open();
            return conexao;
        }
    }
}
