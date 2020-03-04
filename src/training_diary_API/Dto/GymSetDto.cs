using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trainingDiaryBackend.Models;

namespace trainingDiaryBackend.Dto
{
    public class GymSetDto
    {
        public int IdGymSet { get; set; }
        public int IdGymMove { get; set; }
        public int IdPerson { get; set; }
        public int Repetitions { get; set; }
        public double SetWeight { get; set; }
        public DateTime Timestamp { get; set; }
        public GymMove GymMoveNavigation {get; set;}
    }
}
