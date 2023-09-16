

using Fight_game;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Hero hero = new Hero("Pesho",100);
        Weapon goldenSword = new Weapon("Golden Sword", 20, 50);
        Weapon diamondSword = new Weapon("Diamond Sword", 30, 60);
        Weapon epicSword = new Weapon("Epic Sword", 40, 70);
        List<Target> monsters = new List<Target>
        {
    new Target("Monster", 20, 50),
    new Target("Armored Monster", 40, 75),
    new Target("Boss Monster", 80, 100)
};

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Change Weapon");
            Console.WriteLine("3. Check Inventory");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    
                    Console.WriteLine("Choose a target:");
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {monsters[i].Name} ({monsters[i].HealthPoints} HP)");
                    }

                    int targetChoice;
                    if (int.TryParse(Console.ReadLine(), out targetChoice))
                    {
                        if (targetChoice >= 1 && targetChoice < monsters.Count)
                        {

                            Target target = monsters[targetChoice - 1];


                            if (hero.ExperiencePoints > 50)
                            {
                                // Героят може да се бие и с голи ръце и с оръжие
                                Console.WriteLine($"{hero.Name} chooses to attack {target.Name}.");
                                hero.Attack(target);

                                // Проверка дали чудовището е убито
                                if (target.HealthPoints <= 0)
                                {
                                    // Героят получава опит и убитото чудовище дава предмет
                                    hero.GainExperience(target.ExperienceReward);
                                    Item item = new Item("Hlqb", 1); // Променете този ред според вашите предмети
                                    hero.AddItemToInventory(item);

                                    // Извеждане на съобщение, че чудовището е убито
                                    Console.WriteLine($"{target.Name} has been defeated!");
                                    monsters.Remove(target);
                                }

                                if (monsters.Count == 0)
                                {
                                    Console.WriteLine("All monsters have been defeated!");
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
                                    hero.GainExperience(target.ExperienceReward);
                                    target.HealthPoints = 0;
                                    Item item = new Item("Riba", 1); // Променете този ред според вашите предмети
                                    hero.AddItemToInventory(item);

                                    // Извеждане на съобщение, че чудовището е убито
                                    Console.WriteLine($"{target.Name} has been defeated!");
                                    monsters.Remove(target);
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
                    if (hero.ExperiencePoints >= hero.RequiredExperienceForNextWeapon)
                    {
                        Console.WriteLine("Choose a weapon:");
                        Console.WriteLine("1. Golden Sword");
                        Console.WriteLine("2. Diamond Sword");
                        Console.WriteLine("3. Epic Sword");

                        string weaponChoice = Console.ReadLine();

                        switch (weaponChoice)
                        {
                            case "1":
                                hero.ChangeWeapon(goldenSword);
                                break;
                            case "2":
                                hero.ChangeWeapon(diamondSword);
                                break;
                            case "3":
                                hero.ChangeWeapon(epicSword);
                                break;
                            default:
                                Console.WriteLine("Invalid weapon choice.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} does not have enough experience to change the weapon.");
                    }
                    break;
                  

                case "3":
                    hero.CheckInventory(); // Извеждане на инвентара
                    break;

                case "4":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
