using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class RoomsDAO : PadraoDAO<RoomsViewModel>
    {
        protected override SqlParameter[] CriaParametros(RoomsViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("name", model.Name));
            parameters.Add(new SqlParameter("seats", model.Seats));
            parameters.Add(new SqlParameter("theaters_id", model.Theaters_id));
           
            return parameters.ToArray();
        }

        protected override RoomsViewModel MontaModel(DataRow registro)
        {
            RoomsViewModel room = new RoomsViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                Name = (registro["name"]).ToString(),
                Seats = Convert.ToInt32(registro["seats"]),
                Theaters_id = Convert.ToInt32(registro["theaters_id"]),

            };
            return room;
        }

        protected override void SetTabela(string table)
        {
            Tabela = (table != null && table != "") ? table : "rooms";
        }
    }
}
