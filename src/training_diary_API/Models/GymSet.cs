using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace training_diary_API.Models
{
    public partial class GymSet
    {
        public int IdGymSet { get; set; }
        public int IdGymMove { get; set; }
        public int IdPerson { get; set; }
        public int Repetitions { get; set; }
        public double SetWeight { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual GymMove IdGymMoveNavigation { get; set; }
        [JsonIgnore]
        public virtual Person IdPersonNavigation { get; set; }
    }
}
