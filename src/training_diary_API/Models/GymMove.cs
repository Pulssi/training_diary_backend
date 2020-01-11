using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace training_diary_API.Models
{
    public partial class GymMove
    {
        public GymMove()
        {
            GymSet = new HashSet<GymSet>();
        }

        public int IdGymMove { get; set; }
        public string MoveName { get; set; }
        public string MoveDescription { get; set; }

        [JsonIgnore]
        public virtual ICollection<GymSet> GymSet { get; }
    }
}
