using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.DTO
{
    public class FilterDto
    {
        public IEnumerable<string> Locations { get; set; }
        public IEnumerable<string> TypeAnimal { get; set; }
        public IEnumerable<string> Sex { get; set; }
        public IEnumerable<string> Shelter { get; set; }

    }
}
