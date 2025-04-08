using System.Text;
using task2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Hero hero = new Mage();
        Hero hero1 = new Palladin();
        Hero hero2 = new Warrior();
        Console.WriteLine($"{hero.GetDescription()} - {hero.GetHealth()} - {hero.GetPower()}");
        Console.WriteLine($"{hero1.GetDescription()} - {hero1.GetHealth()} - {hero1.GetPower()}");
        Console.WriteLine($"{hero2.GetDescription()} - {hero2.GetHealth()} - {hero2.GetPower()}");
        hero = new ArtifactDecorator(hero);
        hero1 = new ClothingDecorator(hero1);
        hero2 = new WeaponDecorator(hero2);
        Console.WriteLine($"{hero.GetDescription()} - {hero.GetHealth()} - {hero.GetPower()}");
        Console.WriteLine($"{hero1.GetDescription()} - {hero1.GetHealth()} - {hero1.GetPower()}");
        Console.WriteLine($"{hero2.GetDescription()} - {hero2.GetHealth()} - {hero2.GetPower()}");
    }
}