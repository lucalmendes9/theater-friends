using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class LocalizationViewModel : PadraoViewModel
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
