using Game;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestHeroAttack()
        {
            // Подготовка на тестовите обекти
            Hero hero = new Hero("Pesho", 100);
            Mob mob = new Mob("Monster", 15, 20);
            hero.Attack(mob);
            Assert.AreEqual(5, mob.HealthPoints);
        }
    }
}