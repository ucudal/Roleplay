using System;
namespace Library
{
    public class Elves
    {
        public string Name { get; private set; }
        public int Attack { get; private set; } = 0;
        public Item Item { get; private set; }
        public int Health { get; private set; } = 0;
        public int InitialHealth { get; private set; } = 0;

        public Elves (string name, int attack, Item item, int health)
        {
            this.InitialHealth = health;
            this.Name = name;
            this.Attack = attack;
            this.Item = item;
            this.Health = health;
        }

        public void Heal(int amount)
        {
            this.Health = Math.Max(amount, this.InitialHealth);
        }

        public void Attack()
        {
            
        }
    }
}