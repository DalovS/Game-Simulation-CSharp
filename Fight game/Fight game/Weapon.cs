using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Weapon:BaseClass
    {
      
       // public string Name { get; set; }
        public int AttackDamage { get; set; }
        public int Durability { get; set; }
        public Weapon(string name, int attackDamage, int durability) : base(name)
        {

            AttackDamage = attackDamage;
            Durability = durability;
        }
       
    }
}
