namespace Assets.CodeBase.Model
{
    public class PlayerStats
    {
        public ReactiveProperty<int> Strength = new();
        public ReactiveProperty<int> Stamina = new();
        public ReactiveProperty<int> Defense = new();
        public ReactiveProperty<int> Luck = new();
        public ReactiveProperty<int> Mana = new();
        public ReactiveProperty<int> Intelligence = new();
        public ReactiveProperty<int> PointsToSpend = new();

        public PlayerStats(
            int strength, int stamina, int defense, int luck, int mana, int intelligence, int pointsToSpend)
        {
            Strength.Value = strength;
            Stamina.Value = stamina;
            Defense.Value = defense;
            Luck.Value = luck;
            Mana.Value = mana;
            Intelligence.Value = intelligence;
            PointsToSpend.Value = pointsToSpend;
        }
    }
}