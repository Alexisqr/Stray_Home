using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray_Home_Domain.Entities
{
    public class Shelter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public int AdministratorID { get; set; }
        public User Administrator { get; set; } 
    }
}
