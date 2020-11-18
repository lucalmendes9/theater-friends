using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class RoomsViewModel : PadraoViewModel
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public int Theaters_id { get; set; }
    }
}
