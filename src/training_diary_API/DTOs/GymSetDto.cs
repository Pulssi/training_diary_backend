using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace training_diary_API.DTOs
{
    public class GymSetDto
    {
        public int Repetitions { get; set; }
        public double SetWeight { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
