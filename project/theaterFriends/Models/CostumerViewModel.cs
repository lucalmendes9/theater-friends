using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class CostumerViewModel : PadraoViewModel
    {
        public string Name { get; set; }
        public string Email { get;set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime Created_At { get; set; }
    }
}
