using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class RequestDAO : PadraoDAO<RequestViewModel>
    {
        protected override SqlParameter[] CriaParametros(RequestViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("seat_number", model.Seat_number));
            parameters.Add(new SqlParameter("number_ticket", model.Number_ticket));
            parameters.Add(new SqlParameter("total_pay", model.Total_pay));
            parameters.Add(new SqlParameter("costumer_id", model.Costumer_id));
            parameters.Add(new SqlParameter("payment_id", model.Payment_id));
            parameters.Add(new SqlParameter("schedule_exhibition_id", model.Schedule_Exhibition_id));

            return parameters.ToArray();
        }

        protected override RequestViewModel MontaModel(DataRow registro)
        {
            RequestViewModel request = new RequestViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                Seat_number = Convert.ToInt32(registro["seat_number"]),
                Number_ticket = Convert.ToInt32(registro["number_ticket"]),
                Total_pay = Convert.ToDouble(registro["total_pay"]),
                Costumer_id = Convert.ToInt32(registro["costumer_id"]),
                Payment_id = Convert.ToInt32(registro["payment_id"]),
                Schedule_Exhibition_id = Convert.ToInt32(registro["schedule_exhibition_id"])
            };
            return request;
        }

        protected override void SetTabela()
        {
            Tabela = "Requests";
        }
    }
}
