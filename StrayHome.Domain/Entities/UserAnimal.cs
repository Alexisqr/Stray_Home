using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Domain.Entities
{
    public class UserAnimal
    {
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Guid AnimalID { get; set; }
        public Animal Animal { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
