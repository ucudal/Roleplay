namespace Library
{
    public class Item
    {
        public int damage { get; private set; } = 0;
        public int defense { get; private set; } = 0;
        public int durability { get; private set; } = 0;

        public Item(int damage, int defense, int durability)
        {
            this.damage = damage;
            this.defense = defense;
            this.durability = durability;
        }
    }
}