namespace Library
{
    public class Items
    {
        public int damage { get; private set; } = 0;
        public int defense { get; private set; } = 0;
        public int durability { get; private set; } = 0;

        public Items(int damage, int defense, int durability)
        {
            this.damage = damage;
            this.defense = defense;
            this.durability = durability;
        }
    }
}