using System;
using System.Collections.Generic;
namespace Library
{
    public class Elf
    {
        public string Nombre { get; private set; }
        public int Ataque { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int HP { get; private set; } = 0;
        public int VidaInicial { get; private set; } = 0;

        public Elf (string name, int attack, int health)
        {
            this.VidaInicial = health;
            this.Nombre = name;
            this.Ataque = attack;
            this.HP = health;
        }

        public void AddItem (Item item)
        {
            if (!this.Items.Contains(item)){ this.Items.Add(item); }
        }
        public bool IsAlive()
        {
            return this.HP > 0;
        }
        public void Heal(int amount)
        {
            this.HP = Math.Max(amount, this.VidaInicial);
        }

        public void Attacking(Elf elf)
        {
            int totalDamage = 0;
            bool isAlive = elf.IsAlive();
            
        }
    }
}