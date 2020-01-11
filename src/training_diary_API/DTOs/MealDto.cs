using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace training_diary_API.DTOs
{
    public class MealDto
    {
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double Calories { get; set; }
        public double? Carbs { get; set; }
        public double? Fats { get; set; }
        public double? Proteins { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
