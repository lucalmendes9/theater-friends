using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class Schedule_ExhibitionViewModel : PadraoViewModel
    {
        public double Price { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public int Exhibition_id { get; set; }
    }
}
