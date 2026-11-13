using System;

public class Knight : Hero, IMagical
{
    public Knight(string name, string item)
        : base(name)
    {
        this.magicalItem = item;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine("Магически предмет: " + magicalItem);
    }

    public void UseMagicalItem()
    {
        Console.WriteLine($"Рицарят {name} вдига {magicalItem}! " +
            "Предметът пробива половината от защитата на противника.");
    }

    public int CastSpell(Hero target)
    {
        if (!CanFight(target))
        {
            return 0;
        }

        UseMagicalItem();

        int damage = attack - target.shield / 2;

        return ApplyDamage(target, damage);
    }

    public void MakeMove(Hero target)
    {
        if (CalculateAttackDamage(target) > 0)
        {
            Attack(target);
        }
        else
        {
            Console.WriteLine($"Защитата на {target.name} е твърде силна за обикновена атака.");
            CastSpell(target);
        }
    }
}
