namespace Library
{
    public class Item
    {
        public int daño { get; private set; } = 0;
        public int defensa { get; private set; } = 0;
        public int durabilidad { get; private set; } = 0;

        public Item(int damage, int defense, int durability)
        {
            this.daño = damage;
            this.defensa = defense;
            this.durabilidad = durability;
        }

        public bool EstaRoto()
        {
            return this.durabilidad <= 0;
        }
        public void Desgaste(int amount)
        {
            if(!this.EstaRoto()) { this.durabilidad--; }
        }
    }
}