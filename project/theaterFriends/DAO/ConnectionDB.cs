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
            string strCon = "Data Source=sql5091.site4now.net;database=DB_A6AA72_theatherfriends;User Id=DB_A6AA72_theatherfriends_admin;Password=kajs9wqoied"; //Connection for the local DB
            SqlConnection connection = new SqlConnection(strCon);
            connection.Open();
            return connection;
        }
    }
}
