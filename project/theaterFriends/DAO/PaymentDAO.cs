using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class PaymentDAO : PadraoDAO<PaymentViewModel>
    {
        protected override SqlParameter[] CriaParametros(PaymentViewModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("type", model.Type));
            parameters.Add(new SqlParameter("credit_card", model.Credit_card));
            parameters.Add(new SqlParameter("parcels", model.Parcels));


            return parameters.ToArray();
        }

        protected override PaymentViewModel MontaModel(DataRow registro)
        {
            PaymentViewModel payment = new PaymentViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                Type = registro["type"].ToString(),
                Credit_card = registro["credit_card"].ToString(),
                Parcels = Convert.ToInt32(registro["parcels"]),
            };
            return payment;
        }

        protected override void SetTabela(string table)
        {
            Tabela = (table != null && table != "") ? table : "Payment";
        }
    }
}
