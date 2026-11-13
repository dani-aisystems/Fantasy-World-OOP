using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int choice = 0;

        while (choice != 1 && choice != 2)
        {
            Console.WriteLine("ФЕНТЪЗИ СВЯТ");
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("1. Битка за рицарско звание");
            Console.WriteLine("2. Битка между рицар и магьосник");
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.Write("Изберете сценарий: ");

            string input = Console.ReadLine();

            if (input == null)
            {
                return;
            }

            if (!int.TryParse(input, out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Невалиден избор! Въведете 1 или 2.");
                Console.WriteLine();
                choice = 0;
            }
        }

        Console.WriteLine();

        if (choice == 1)
        {
            BattleForKnighthoodScenario();
        }
        else
        {
            KnightVsWizardScenario();
        }
    }

    static void BattleForKnighthoodScenario()
    {
        Console.WriteLine("===== БИТКА ЗА РИЦАРСКО ЗВАНИЕ =====");
        Console.Write("Въведете името на рицаря-чирак: ");

        string name = Console.ReadLine();

        if (name == null || name.Trim() == "")
        {
            name = "Чирак";
        }

        ApprenticeKnight player = new ApprenticeKnight(name.Trim(), "Вълшебен меч");

        List<ApprenticeKnight> opponents = new List<ApprenticeKnight>();
        opponents.Add(new ApprenticeKnight("Бранимир", "Щит на зората"));
        opponents.Add(new ApprenticeKnight("Светозар", "Копие на бурята"));
        opponents.Add(new ApprenticeKnight("Деян", "Шлем на планината"));

        List<Hero> heroes = new List<Hero>();
        heroes.Add(player);
        foreach (ApprenticeKnight opponent in opponents)
        {
            heroes.Add(opponent);
        }

        Console.WriteLine();
        Console.WriteLine("Участници в турнира:");
        foreach (Hero hero in heroes)
        {
            hero.Show();
        }

        int startHealth = player.health;

        for (int i = 0; i < opponents.Count; i++)
        {
            player.health = startHealth;

            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine($"Започва битка №{i + 1}!");
            Console.WriteLine("=========================");

            player.BattleForKnighthood(opponents[i]);

            Console.WriteLine();
            Console.WriteLine($"Състояние на {player.name} след битка №{i + 1}:");
            Console.WriteLine("Здраве = " + player.health);
            Console.WriteLine("Атака = " + player.attack);
            Console.WriteLine("Защита = " + player.shield);
            Console.WriteLine("Спечелени битки = " + player.battlesWon);
            player.ShowExperience();
        }

        Console.WriteLine();
        Console.WriteLine("=========================");
        Console.WriteLine("КРАЙ НА ТУРНИРА");
        Console.WriteLine("=========================");

        Knight knight = player.PromoteToKnight();

        if (knight != null)
        {
            Console.WriteLine("Новият рицар:");
            knight.Show();
            knight.ShowExperience();
        }
        else
        {
            Console.WriteLine($"{player.name} спечели {player.battlesWon} от 3 битки. " +
                "За рицарско звание са нужни 3 победи.");
        }
    }

    static void KnightVsWizardScenario()
    {
        Knight knight = new Knight("Сър Калоян", "Меч на светлината");
        Wizard wizard = new Wizard("Зоран Мъдрия", "Жезъл на бурите");

        List<Hero> heroes = new List<Hero>();
        heroes.Add(knight);
        heroes.Add(wizard);

        Console.WriteLine("Начални характеристики:");
        foreach (Hero hero in heroes)
        {
            hero.Show();
        }

        while (knight.IsAlive() && wizard.IsAlive())
        {
            Console.WriteLine();
            Console.WriteLine("===== РИЦАР СРЕЩУ МАГЬОСНИК =====");
            Console.WriteLine();
            Console.WriteLine($"{knight.name}: {knight.health} здраве | {wizard.name}: {wizard.health} здраве");
            Console.WriteLine();
            Console.WriteLine("1. Рицарят атакува");
            Console.WriteLine("2. Магьосникът използва заклинание");
            Console.WriteLine();
            Console.Write("Изберете действие: ");

            string input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("Няма повече вход. Битката е прекратена.");
                return;
            }

            Console.WriteLine();

            if (input.Trim() == "1")
            {
                knight.MakeMove(wizard);
            }
            else if (input.Trim() == "2")
            {
                int damage = wizard.CastSpell(knight);

                if (damage == 0)
                {
                    Console.WriteLine("Заклинанието беше твърде слабо срещу защитата на рицаря.");
                }
            }
            else
            {
                Console.WriteLine("Невалиден избор! Въведете 1 или 2.");
            }
        }

        Hero winner;

        if (knight.IsAlive())
        {
            winner = knight;
        }
        else
        {
            winner = wizard;
        }

        Console.WriteLine();
        Console.WriteLine("=========================");
        Console.WriteLine($"Победител: {winner.name}!");
        Console.WriteLine("=========================");
        winner.Show();
        winner.ShowExperience();
    }
}
