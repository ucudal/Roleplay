using System;
using System.Collections.Generic;
namespace Library
{
    public class Elf
    {
        public string Name { get; private set; }
        public int Attack { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int Health { get; private set; } = 0;
        public int InitialHealth { get; private set; } = 0;

        public Elf (string name, int attack, Item item, int health)
        {
            this.InitialHealth = health;
            this.Name = name;
            this.Attack = attack;
            this.Health = health;
        }

        public void AddItem (Item item)
        {
            if (!this.Items.Contains(item)){ this.Items.Add(item); }
        }
        public bool IsAlive()
        {
            return this.Health > 0;
        }
        public void Heal(int amount)
        {
            this.Health = Math.Max(amount, this.InitialHealth);
        }

        public void Attacking(Elf elf)
        {
            int totalDamage = 0;
            bool isAlive = elf.IsAlive();
            
        }
    }
}