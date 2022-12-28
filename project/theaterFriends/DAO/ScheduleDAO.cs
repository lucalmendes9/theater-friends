using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class ScheduleDAO : PadraoDAO<Schedule_ExhibitionViewModel>
    {
        protected override SqlParameter[] CriaParametros(Schedule_ExhibitionViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("price", model.Price));
            parameters.Add(new SqlParameter("start_date", model.Start_date));
            parameters.Add(new SqlParameter("end_date", model.End_date));
            parameters.Add(new SqlParameter("exhibition_id", model.Exhibition_id));

            return parameters.ToArray();
        }

        protected override Schedule_ExhibitionViewModel MontaModel(DataRow registro)
        {
            Schedule_ExhibitionViewModel c = new Schedule_ExhibitionViewModel()
            {
                Id = Convert.ToInt32(registro["id"]),
                Price = Convert.ToDouble(registro["price"]),
                Start_date = Convert.ToDateTime(registro["start_date"]),
                End_date = Convert.ToDateTime(registro["end_date"]),
                Exhibition_id = Convert.ToInt32(registro["exhibition_id"]),
            };
            return c;
        }

        protected override void SetTabela(string table)
        {
            Tabela = (table != null && table != "") ? table : "Schedules Exhibition";
        }

    }
}
    
