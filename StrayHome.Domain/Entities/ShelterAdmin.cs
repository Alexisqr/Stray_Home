using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class ShelterAdmin
    {
        public Guid ID { get; set; }

        public Guid AdministratorID { get; set; }
        public User Administrator { get; set; }
        public Guid ShelterID { get; set; }
        public Shelter Shelter { get; set; }

    }
}
