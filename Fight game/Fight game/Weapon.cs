using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_game
{
    
        public class Weapon
        {
            public string Name { get; set; }
            public int AttackPoints { get; set; }
            public int Durability { get; set; }

            public Weapon(string name, int attackPoints, int durability)
            {
                Name = name;
                AttackPoints = attackPoints;
                Durability = durability;
            }
        }
    
}
