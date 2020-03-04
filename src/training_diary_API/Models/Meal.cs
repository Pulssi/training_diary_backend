using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace trainingDiaryBackend.Models
{
    public partial class Meal
    {
        public int IdMeal { get; set; }
        public int IdPerson { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double Calories { get; set; }
        public double? Carbs { get; set; }
        public double? Fats { get; set; }
        public double? Proteins { get; set; }
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public virtual Person IdPersonNavigation { get; set; }
    }
}
