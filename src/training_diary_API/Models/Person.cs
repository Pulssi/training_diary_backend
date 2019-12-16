using System;
using System.Collections.Generic;

namespace training_diary_API.Models
{
    public partial class Person
    {
        public Person()
        {
            GymSet = new HashSet<GymSet>();
            Meal = new HashSet<Meal>();
            Weight = new HashSet<Weight>();
        }

        public int IdPerson { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<GymSet> GymSet { get; set; }
        public virtual ICollection<Meal> Meal { get; set; }
        public virtual ICollection<Weight> Weight { get; set; }
    }
}
