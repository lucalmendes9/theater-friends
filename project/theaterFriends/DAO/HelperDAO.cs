using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.DAO
{
    public class HelperDAO
    {
        public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
        {
            using (var cx = ConnectionDB.GetConexao())
            {
                DataTable tabela = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    adapter.Fill(tabela);
                    cx.Close();
                    return tabela;
                }
            }
        }

        public static void ExecutaSQL(string sql, SqlParameter[] parametros)
        {
            using (var cx = ConnectionDB.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cx))
                {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    cmd.ExecuteNonQuery();
                }
                cx.Close();
            }
        }


        public static DataTable ExecutaProcSelect(string nomeProc, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConnectionDB.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(nomeProc, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }
        public static int ExecutaProc(string nomeProc, SqlParameter[] parametros,
                          bool consultaUltimoIdentity = false)
        {
            using (SqlConnection conexao = ConnectionDB.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(nomeProc, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                    if (consultaUltimoIdentity)
                    {
                        string sql = "select isnull(@@IDENTITY,0)";
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = sql;
                        int pedidoId = Convert.ToInt32(comando.ExecuteScalar());
                        conexao.Close();
                        return pedidoId;
                    }
                    else
                        return 0;
                }
            }
        }
    }
}
