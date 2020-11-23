using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class ExhibitionViewModel : PadraoViewModel
    {
        public int Room_id { get; set; }
        public int Movie_id { get; set; }
    }
}
