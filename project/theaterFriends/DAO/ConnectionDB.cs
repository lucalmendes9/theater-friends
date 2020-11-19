using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.DAO
{
    public class ConnectionDB
    {
        public static SqlConnection GetConexao()
        {
            //string strCon = ""; //Connection for the online DB
            string strCon = "Data Source=localhost;database=ProjetoCinema;integrated security=true"; //Connection for the local DB
            SqlConnection connection = new SqlConnection(strCon);
            connection.Open();
            return connection;
        }
    }
}
