using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class LocalizationDAO : PadraoDAO<LocalizationViewModel>
    {
        protected override SqlParameter[] CriaParametros(LocalizationViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("phone", model.Phone));
            parameters.Add(new SqlParameter("address", model.Address));
            parameters.Add(new SqlParameter("number", model.Number));
            if (model.Neighbourhood == null)
                parameters.Add(new SqlParameter("neighbourhood", DBNull.Value));
            else
                parameters.Add(new SqlParameter("neighbourhood", model.Neighbourhood));
            parameters.Add(new SqlParameter("city", model.City));
            parameters.Add(new SqlParameter("state", model.State));

            return parameters.ToArray();
        }

        protected override LocalizationViewModel MontaModel(DataRow registro)
        {
            LocalizationViewModel location = new LocalizationViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                Phone = registro["phone"].ToString(),
                Address = registro["address"].ToString(),
                Number = Convert.ToInt32(registro["number"]),
                Neighbourhood = registro["neighbourhood"].ToString(),
                City = registro["city"].ToString(),
                State = registro["state"].ToString(),
            };
            return location;
        }

        protected override void SetTabela()
        {
            Tabela = "Localization";
        }
    }
}
