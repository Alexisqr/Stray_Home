using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.DTO
{
    public class MissingAnimalSeleniumDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageLink { get; set; }
        public string? Link { get; set; }
        public string? Location { get; set; }
    }
}
