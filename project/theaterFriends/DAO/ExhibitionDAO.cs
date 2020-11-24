using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class ExhibitionDAO : PadraoDAO<ExhibitionViewModel>
    {
        protected override SqlParameter[] CriaParametros(ExhibitionViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("room_id", model.Room_id));
            parameters.Add(new SqlParameter("movie_id", model.Movie_id));
        
            return parameters.ToArray();
        }

        protected override ExhibitionViewModel MontaModel(DataRow registro)
        {
            ExhibitionViewModel exhibition = new ExhibitionViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                Room_id = Convert.ToInt32(registro["room_id"]),
                Movie_id = Convert.ToInt32(registro["movie_id"]),
            };
            return exhibition;
        }

        protected override void SetTabela(string table)
        {
            Tabela = (table != null && table != "") ? table : "Exhibition";
        }
    }
}
