using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Armor :BaseClass
    {
        
        public int Protection { get; set; }
        public int Price { get; set; }  
        public Armor(string name, int protection, 
            int durability , int price) : base(durability)
        { 
            Name = name;
            Protection = protection;
            Price = price;  
            
        
        }
        
           
        
    }
}
