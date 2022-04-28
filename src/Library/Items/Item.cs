using System;

namespace Library
{
    public class Item
    {
        public int Damage { get; private set; } = 0;
        public int Defense { get; private set; } = 0;
        public int Durability { get; private set; } = 0;

        public Item(int damage, int defense, int durability)
        {
            this.Damage = damage;
            this.Defense = defense;
            this.Durability = durability;
        }

        public bool Broken()
        {
            return this.Durability <= 0;
        }
        public void Deterioration()
        {
            if(!this.Broken()) { this.Durability--; }
        }

        public void PrettyPrint()
        {
            Console.WriteLine($"Este objeto tiene {this.Damage} de Damage, {this.Defense} de Defense y una Durability de {this.Durability}");
        }
    }
}