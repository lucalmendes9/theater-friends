using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class RequestViewModel : PadraoViewModel
    {
        public int Seat_number { get; set; }
        public int Number_ticket { get; set; }
        public double Total_pay { get; set; }
        public int Costumer_id { get; set; }
        public int Payment_id { get; set; }
        public int Schedule_Exhibition_id { get; set; }
    }
}
