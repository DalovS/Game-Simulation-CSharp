using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Mob:BaseClass
    {
        public int ExpReward { get; set; }
        public Mob(string name,int hp,int exp) :base(name,hp) { //Конструктор с параметри          
            ExpReward = exp;     
        }
    }
}
