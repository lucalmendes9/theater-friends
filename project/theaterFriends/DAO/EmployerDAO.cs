using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class EmployerDAO : PadraoDAO<EmployerViewModel>
    {
        protected override SqlParameter[] CriaParametros(EmployerViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("name", model.Name));
            parameters.Add(new SqlParameter("email", model.Email));
            parameters.Add(new SqlParameter("password", model.Password));
            parameters.Add(new SqlParameter("employer_role", model.Employer_role));
            parameters.Add(new SqlParameter("hired_at", model.Hired_At));
        
            return parameters.ToArray();
        }

        protected override EmployerViewModel MontaModel(DataRow registro)
        {
            EmployerViewModel Employer = new EmployerViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                Name = registro["name"].ToString(),
                Email = registro["email"].ToString(),
                Password = registro["password"].ToString(),
                Employer_role = registro["employer_role"].ToString(),
                Hired_At = Convert.ToDateTime(registro["hired_at"])
            };
            return Employer;
        }

        protected override void SetTabela(string table)
        {
            Tabela = (table != null && table != "") ? table : "Employer";
        }
    }
}
