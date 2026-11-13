using System;

public class ApprenticeKnight : Knight
{
    public ApprenticeKnight(string name, string item)
        : base(name, item)
    {
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine("Звание: Рицар-чирак");
        Console.WriteLine("Спечелени битки: " + battlesWon);
    }

    public Knight PromoteToKnight()
    {
        if (battlesWon >= 3)
        {
            Console.WriteLine("Поздравления! Получихте рицарско звание!");

            Knight promotedKnight = new Knight(this.name, this.magicalItem);

            promotedKnight.attack = this.attack;
            promotedKnight.shield = this.shield;
            promotedKnight.health = this.health;
            promotedKnight.magicalPower = this.magicalPower;
            promotedKnight.battlesWon = this.battlesWon;
            promotedKnight.totalAttacks = this.totalAttacks;

            return promotedKnight;
        }

        Console.WriteLine("Все още нямате достатъчно спечелени битки!");
        return null;
    }

    public void BattleForKnighthood(ApprenticeKnight opponent)
    {
        Console.WriteLine($"{name} срещу {opponent.name}");

        int round = 1;

        while (this.IsAlive() && opponent.IsAlive())
        {
            Console.WriteLine();
            Console.WriteLine($"--- Рунд {round} ---");

            this.MakeMove(opponent);

            if (opponent.IsAlive())
            {
                opponent.MakeMove(this);
            }

            round++;
        }

        Console.WriteLine();

        if (this.IsAlive())
        {
            Console.WriteLine($"Победител: {name}");
        }
        else
        {
            Console.WriteLine($"Победител: {opponent.name}");
        }
    }
}
