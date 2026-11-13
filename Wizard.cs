using System;

public class Wizard : Hero, IMagical
{
    public Wizard(string name, string item)
        : base(name)
    {
        magicalItem = item;
        magicalPower = rnd.Next(1, 100);
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine("Магически предмет: " + magicalItem);
        Console.WriteLine("Магическа сила: " + magicalPower);
    }

    public void UseMagicalItem()
    {
        Console.WriteLine(
            $"Магьосникът {name} използва {magicalItem} " +
            $"с магическа сила {magicalPower}!");
    }

    public int CastSpell(Hero target)
    {
        if (!CanFight(target))
        {
            return 0;
        }

        UseMagicalItem();

        int damage = magicalPower * 2 - target.shield;

        return ApplyDamage(target, damage);
    }
}
