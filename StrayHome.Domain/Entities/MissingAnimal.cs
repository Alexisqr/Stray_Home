using StrayHome.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class MissingAnimal
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageLink { get; set; }
        public string? Location { get; set; }
        public AdType AdType { get; set; }
        public string? Link { get; set; }

        public Guid? UserID { get; set; }
        public User? User { get; set; }
    }
}
