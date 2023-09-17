using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Item:BaseClass
    {
        //public string Name { get; set; } // поле/ Характеристика на клас(обект от реален свят)
        public int Quantity { get; set; }// поле/ Характеристика на клас(обект от реален свят)
        public Item(string name , int quantity):base(name) // Конструктор с параметри
        { 
          
            Quantity = quantity;
        } 
    }
}
