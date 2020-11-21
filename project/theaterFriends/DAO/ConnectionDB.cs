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
            string strCon = "Data Source=sql5091.site4now.net;database=DB_A6AA72_theatherfriends;user id=DB_A6AA72_theatherfriends_admin; password=kajs9wqoied";
            SqlConnection connection = new SqlConnection(strCon);
            connection.Open();
            return connection;
        }
    }
}
