using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class News
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public Guid ShelterID { get; set; }
        public Shelter Shelter { get; set; }
    }
}
