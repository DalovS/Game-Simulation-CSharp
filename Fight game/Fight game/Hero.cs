using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_game
{
    public  class Hero 
    {
       public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int ExperiencePoints { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public int RequiredExperienceForNextWeapon { get; set; }
        public Hero(string name, int healthPoints)
     
        {
            Name = name;
            HealthPoints = 100; // Начални точки на здраве
            ExperiencePoints = 0; // Начални точки опит
            Inventory = new List<Item>();
            CurrentWeapon = null; // Героят започва без оръжие
            RequiredExperienceForNextWeapon = 50; // Примерно количество опит, нужно за следващото оръжие
        }
        public  void Attack(Target target)
        {
            int damage;

            if (CurrentWeapon != null)
            {
                damage = CurrentWeapon.AttackPoints;
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

            if (target.HealthPoints <= 0)
            {
                GainExperience(target.ExperienceReward);
                target.HealthPoints = 0;
            }

            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage.");
            
        }
        public bool IsCurrentWeaponBroken()
        {
            return CurrentWeapon != null && CurrentWeapon.Durability <= 0;
        }
        public void CheckInventory()
        {
            Console.WriteLine($"{Name}'s Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Name}: {item.Quantity}");
            }
        }
        public void AddItemToInventory(Item item)
        {
            // Търсене на предмета в инвентара
            Item existingItem = Inventory.FirstOrDefault(item => item.Name == item.Name);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity; // Увеличаване на количество
            }
            else
            {
                // Ако предметът не е в инвентара, създаваме нов предмет и го добавяме
                Inventory.Add(item);
            }

            Console.WriteLine($"{Name} received {item.Quantity} {item.Name}(s).");
        }

        public void GainExperience(int experience)
        {
            ExperiencePoints += experience;
            Console.WriteLine($"{Name} gained {experience} experience points.");
        }
        public void ChangeWeapon(Weapon newWeapon)
        {
            if (ExperiencePoints >= RequiredExperienceForNextWeapon)
            {
                CurrentWeapon = newWeapon;
                Console.WriteLine($"{Name} has equipped {newWeapon.Name}.");
            }
            else
            {
                Console.WriteLine($"{Name} does not have enough experience to equip {newWeapon.Name}.");
            }
        }
    }
}
