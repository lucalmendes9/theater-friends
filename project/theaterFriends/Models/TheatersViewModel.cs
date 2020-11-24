using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class TheatersViewModel : PadraoViewModel
    {
        public string Description { get; set; }
        public int Localization_id { get; set; }
        public int Work_days { get; set; }
        public string Open_hour { get; set; }
        public string Close_hour { get; set; }

        //Atributos não mapeados

        public string City { get; set; }
    }
}
