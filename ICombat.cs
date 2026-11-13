public interface ICombat
{
    bool Attack(Hero target);

    void ShowExperience();

    int CalculateBattlesWon();
}
