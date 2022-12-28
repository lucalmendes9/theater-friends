using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class TheatersDAO:PadraoDAO<TheatersViewModel>
    {
        protected override SqlParameter[] CriaParametros(TheatersViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("description", model.Description));
            parameters.Add(new SqlParameter("localization_id", model.Localization_id));
            parameters.Add(new SqlParameter("work_days", model.Work_days));
            parameters.Add(new SqlParameter("open_hour", model.Open_hour));
            parameters.Add(new SqlParameter("close_hour", model.Close_hour));

            return parameters.ToArray();
        }

        protected override TheatersViewModel MontaModel(DataRow registro)
        {
            TheatersViewModel c = new TheatersViewModel()
            {
                Id = Convert.ToInt32(registro["id"]),
                Description = registro["description"].ToString(),
                Localization_id = Convert.ToInt32(registro["localization_id"]),
                Work_days = Convert.ToInt32(registro["work_days"]),
                Open_hour = registro["open_hour"].ToString(),
                Close_hour = registro["close_hour"].ToString(),
            };

            if (registro.Table.Columns.Contains("nomeCidade"))
                c.City = registro["nomeCidade"].ToString();

            return c;
        }

        protected override void SetTabela(string table)
        {

            Tabela = (table != null && table != "") ? table : "Theaters";
            NomeProcedureListagem = "spListagemCineCity";
        }

    }
}
