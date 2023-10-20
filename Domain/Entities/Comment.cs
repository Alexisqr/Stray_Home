using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray_Home_Domain.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public int UserID { get; set; }
        public User User { get; set; } 

        public int ShelterID { get; set; } 
        public Shelter Shelter { get; set; } 
    }
}
