using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class Hero :BaseClass
    {
        public int ExperiencePoints { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public int NeededExpForWeapon { get; set; }
       // public List<Armor> Armors=new List<Armor>();

        /*public void AddArmor(Armor armor)
        {
            Armors.Add(armor);
        }*/
        public Hero(string name,int hp) : base (name, hp)
        {
            hp = 100;
            ExperiencePoints = 0;
            Inventory = new List<Item>();
            CurrentWeapon = null;
            NeededExpForWeapon = 50;
        }
        public void GainEXP(int exp)
        {
            ExperiencePoints+= exp;
            Console.WriteLine($"{Name} recived {exp} exp points.");
        }
        public void Attack(Mob target)
        {
            if (target.HealthPoints <= 0)
            {
                Console.WriteLine($"{Name} chooses to attack {target.Name}.");
                Console.WriteLine($"{Name} cannot attack {target.Name} because it has no health left.");
                return; // Не продължавай с атаката, ако чудовището няма здраве
            }

            int damage;

            if (CurrentWeapon != null)
            {
                damage = CurrentWeapon.AttackDamage;
                CurrentWeapon.Durability--;

                if (CurrentWeapon.Durability <= 0)
                {
                    CurrentWeapon = null;
                }
            }
            else
            {
                damage = 10; // Урон с голи ръце (можете да настроите стойността според вашите изисквания)
            }
            target.HealthPoints -= damage;

            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage.");
        }
        public bool IsWeaponBroken()
        {
            return CurrentWeapon != null && CurrentWeapon.Durability<=0;
        }
        public void CheckInventory()
        {
            Console.WriteLine( $"{Name} inventory's");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Name} : {item.Quantity}");
            }
        }
        public void AddItemToInventory(Item item)
        {
            Item exists = Inventory.FirstOrDefault(item=>item.Name==item.Name);
            if(exists != null)
            {
                exists.Quantity += item.Quantity;
            }
            else { Inventory.Add(item); }
            Console.WriteLine(  $"{Name} recived {item.Name} : {item.Quantity}(s)");
        }
        public void ChangeWeapon(Weapon newWeapon) 
        {
            if (ExperiencePoints >= NeededExpForWeapon)
            {
                CurrentWeapon = newWeapon;
                Console.WriteLine($"{Name} has equipped {newWeapon.Name} ");
            }
            else
            {
                Console.WriteLine($"{Name} has not enought exp for {newWeapon.Name} ");
            }
        }
    }
}
