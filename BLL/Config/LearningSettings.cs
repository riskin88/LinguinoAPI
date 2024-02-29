using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Config
{
    public class LearningSettings
    {
        public long SessionLengthMs { get; set; }
        public double TimeForNewItems {  get; set; }
        public Dictionary<string, int> ExercisesInSession { get; set; }
    }
}
