using Stray_Home_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray_Home_Domain.Entities
{
    public class UserAnimal
    {
        public int UserID { get; set; }

        public User User { get; set; } 
        public int AnimalID { get; set; }
        public Animal Animal { get; set; } 
        public DateTime SubmissionDate { get; set; }
    }
}
