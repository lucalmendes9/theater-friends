using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class PaymentViewModel : PadraoViewModel
    {

        public string Type { get; set; }
        public string Credit_card { get; set; }
        public int Parcels { get; set; }
    }
}
