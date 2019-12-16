using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace training_diary_API.Models
{
    public partial class Weight
    {
        public int IdWeight { get; set; }
        public int IdPerson { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public virtual Person IdPersonNavigation { get; set; }
    }
}
