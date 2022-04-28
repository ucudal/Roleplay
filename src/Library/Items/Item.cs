using System;

namespace Library
{
    public class Item
    {
        public int Daño { get; private set; } = 0;
        public int Defensa { get; private set; } = 0;
        public int Durabilidad { get; private set; } = 0;

        public Item(int damage, int defense, int durability)
        {
            this.Daño = damage;
            this.Defensa = defense;
            this.Durabilidad = durability;
        }

        public bool EstaRoto()
        {
            return this.Durabilidad <= 0;
        }
        public void Desgaste()
        {
            if(!this.EstaRoto()) { this.Durabilidad--; }
        }

        public void PrettyPrint()
        {
            Console.WriteLine($"Este objeto tiene {this.Daño} de daño, {this.Defensa} de defensa y una durabilidad de {this.Durabilidad}");
        }
    }
}