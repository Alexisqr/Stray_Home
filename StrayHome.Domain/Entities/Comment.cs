using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class Comment
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; }

        public Guid ShelterID { get; set; }
        public Shelter Shelter { get; set; }
    }
}
