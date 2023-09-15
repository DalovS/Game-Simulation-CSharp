using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_game
{
    public  class Target { 
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int ExperienceReward { get; set; }

        public Target(string name, int healthPoints, int experienceReward)
        {
            Name = name;
            HealthPoints = healthPoints;
            ExperienceReward = experienceReward;
        }
      
    }
}
