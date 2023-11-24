using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class Shelter
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public Guid AdministratorID { get; set; }
        public User Administrator { get; set; }
    }
}
