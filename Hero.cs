using System;

public class Hero : ICombat
{
    public int attack;
    public int shield;
    public int health;
    public string name;
    public int battlesWon;
    public int totalAttacks;
    public string magicalItem;
    public int magicalPower;

    public static Random rnd = new Random();

    public Hero(string name)
    {
        this.attack = rnd.Next(50, 100);
        this.shield = rnd.Next(50, 100);
        this.health = rnd.Next(50, 100);
        this.name = name;
        this.battlesWon = 0;
        this.totalAttacks = 0;
    }

    public virtual void Show()
    {
        Console.WriteLine("-------------------");
        Console.WriteLine("Атака = " + attack);
        Console.WriteLine("Защита = " + shield);
        Console.WriteLine("Здраве = " + health);
        Console.WriteLine("Име на героя = " + name);
    }

    public bool Attack(Hero target)
    {
        if (!CanFight(target))
        {
            return false;
        }

        int damage = CalculateAttackDamage(target);

        Console.WriteLine($"{name} атакува {target.name}.");
        ApplyDamage(target, damage);

        return target.health == 0;
    }

    public void ShowExperience()
    {
        int experience = totalAttacks * 10 + battlesWon * 100;

        Console.WriteLine($"--- Опит на {name} ---");
        Console.WriteLine("Извършени атаки: " + totalAttacks);
        Console.WriteLine("Спечелени битки: " + battlesWon);
        Console.WriteLine("Точки опит: " + experience);
        Console.WriteLine("Бойна оценка (CalculateBattlesWon): " + CalculateBattlesWon());
    }

    public int CalculateBattlesWon()
    {
        return (health + shield) / 50 + totalAttacks / 5;
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public int CalculateAttackDamage(Hero target)
    {
        int damage = attack + magicalPower - target.shield;

        if (damage < 0)
        {
            damage = 0;
        }

        return damage;
    }

    protected bool CanFight(Hero target)
    {
        if (!IsAlive())
        {
            Console.WriteLine($"{name} е победен и не може да атакува.");
            return false;
        }

        if (!target.IsAlive())
        {
            Console.WriteLine($"{target.name} вече е победен. Атаката е отменена.");
            return false;
        }

        return true;
    }

    protected int ApplyDamage(Hero target, int damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }

        if (damage > target.health)
        {
            damage = target.health;
        }

        target.health = target.health - damage;
        totalAttacks++;

        if (damage == 0)
        {
            Console.WriteLine($"Защитата на {target.name} спря удара напълно - 0 щети!");
        }
        else
        {
            Console.WriteLine($"Нанесени щети: {damage}. Оставащо здраве на {target.name}: {target.health}");
        }

        if (target.health == 0)
        {
            battlesWon++;
            Console.WriteLine($"{target.name} е победен! {name} печели битката!");
        }

        return damage;
    }
}
