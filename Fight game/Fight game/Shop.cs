using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Shop
    {
        List<Armor> armors;
        public Shop()
        {
            armors = new List<Armor>();
        }

        /*public void AddArmor(Armor armor)
        {
            armors.Add(armor);
        }*/
       // public void RemoveArmor(Armor armor) { armors.Remove(armor); }

        public void ShowItems()
        {

            Console.WriteLine("Avaliable Armor Items");
            foreach (var item in armors)
            {
                Console.WriteLine($"{item.Name} - Price {item.Price} " +
                    $"gold - Defence {item.Protection}");
            }
        }
        public void VisitShop(Hero hero, Shop shop)
        {
            Console.WriteLine("Avaliable Armor Items choose number of item you want");
            shop.ShowItems();         
            int Choice = int.Parse(Console.ReadLine());

            if (Choice >= 1 && Choice < armors.Count)
            {
                Armor item = armors[Choice - 1];
                if(hero.ExperiencePoints >= item.Price)
                {
                    hero.ExperiencePoints -= item.Price;
                   // hero.AddArmor(item);
                    Console.WriteLine( $"{hero.Name} Bought {item.Name} " +
                        $"for {item.Price} gold.");
                }
            }
            
        }
    }
}
