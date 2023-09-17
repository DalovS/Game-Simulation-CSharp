using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BaseClass
    {
        public string Name { get; set; }// поле/ Характеристика на клас(обект от реален свят)
        public int HealthPoints { get; set; }
        public int Durability { get; set; }

        public BaseClass(int durability)
        {
            Durability = durability;
        }
        public BaseClass(string name,int hp) { 
            Name= name;
            HealthPoints = hp;
        }
        public BaseClass(string name)
        {
            Name = name;
        }

    }
}
