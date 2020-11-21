using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class LoginDAO : PadraoDAO<CostumerViewModel>
    {
        protected override SqlParameter[] CriaParametros(CostumerViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("email", model.Email));
            parameters.Add(new SqlParameter("pass", model.Password));

            return parameters.ToArray();
        }

        protected override CostumerViewModel MontaModel(DataRow registro)
        {
            CostumerViewModel c = new CostumerViewModel()
            {
                Id = Convert.ToInt32(registro["id"]),
                Name = registro["name"].ToString(),
                Email = registro["email"].ToString(),
                Password = registro["password"].ToString(),
                Created_At = Convert.ToDateTime(registro["created_at"])
            };
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Costumer";
        }
    }
}
