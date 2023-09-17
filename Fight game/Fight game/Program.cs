using Game;
using NUnit.Framework;
using System.ComponentModel.Design;
using System.Xml.Linq;


class Program
{

    public static void Main() 
    {
        Hero hero = new Hero("Pesho", 100);
        Weapon goldenSwrod = new Weapon("Golden Sword", 20, 20);
        Weapon diamondSwrod = new Weapon("Diamond Sword", 40, 60);
        Weapon epicSwrod = new Weapon("Epic Sword", 100, 200);

        List<Mob> mobs = new List<Mob> { new Mob("BasicMob",20,50),
        new Mob("ArmoredMob",40,100),
        new Mob("EpicBoss",100,200)};
        while (true)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. ChangeWeapon");
            Console.WriteLine("3. CheckInventory");
            Console.WriteLine("4. Exit");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":

                    Console.WriteLine("Choose a target:");
                    for (int i = 0; i < mobs.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {mobs[i].Name} ({mobs[i].HealthPoints} HP)");
                    }

                    int targetChoice;
                    if (int.TryParse(Console.ReadLine(), out targetChoice))
                    {
                        if (targetChoice >= 1 && targetChoice < mobs.Count)
                        {

                            Mob target = mobs[targetChoice - 1];


                            if (hero.ExperiencePoints > 50)
                            {
                                // Героят може да се бие и с голи ръце и с оръжие
                                Console.WriteLine($"{hero.Name} chooses to attack {target.Name}.");
                                hero.Attack(target);

                                // Проверка дали чудовището е убито
                                if (target.HealthPoints <= 0)
                                {
                                    // Героят получава опит и убитото чудовище дава предмет
                                    hero.GainEXP(target.ExpReward);
                                    Item item = new Item("Hlqb", 1); // Променете този ред според вашите предмети
                                    hero.AddItemToInventory(item);

                                    // Извеждане на съобщение, че чудовището е убито
                                    Console.WriteLine($"{target.Name} has been defeated!");
                                    mobs.Remove(target);
                                }

                                if (mobs.Count == 0)
                                {
                                    Console.WriteLine("All mobs have been defeated!");
                                }
                            }
                            else if (hero.ExperiencePoints == 0)
                            {
                                // Героят може да се бие само с голи ръце
                                Console.WriteLine($"{hero.Name} attacks with bare hands!");
                                hero.Attack(target);

                                // Проверка дали чудовището е убито
                                if (target.HealthPoints <= 0)
                                {
                                    // Героят получава опит и убитото чудовище дава предмет
                                    hero.GainEXP(target.ExpReward);
                                    target.HealthPoints = 0;
                                    Item item = new Item("Riba", 1); // Променете този ред според вашите предмети
                                    hero.AddItemToInventory(item);

                                    // Извеждане на съобщение, че чудовището е убито
                                    Console.WriteLine($"{target.Name} has been defeated!");
                                    mobs.Remove(target);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid target choice.");
                            }
                        }
                    }
                    break;
                case "2":
                    if (hero.ExperiencePoints>=hero.NeededExpForWeapon)
                    {
                        Console.WriteLine("Choose Weapon");
                        Console.WriteLine("1. GoldenSword");
                        Console.WriteLine("2. DiamonSword");
                        Console.WriteLine("3. EpicSword");
                        string weaponChoise = Console.ReadLine();
                        switch (weaponChoise)
                        {
                            case "1":
                                hero.ChangeWeapon(goldenSwrod);
                                break;
                            case "2":
                                hero.ChangeWeapon(diamondSwrod);
                                break;
                            case "3":
                                hero.ChangeWeapon(epicSwrod);
                                break;

                            default:
                                Console.WriteLine( "Invalid weapon choose");
                                break;
                        }
                    }
                    break;
                case "3":
                    hero.CheckInventory();

                    break;
                case "4":
                    Environment.Exit(0);
                    break;                   
            }
        }



       
    }
}