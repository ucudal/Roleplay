using System;
using System.Collections.Generic;
namespace Library
{
    public class Elf
    {
        public string Nombre { get; private set; }
        public int Ataque { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int HP { get; set; } = 0;
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
        public void RemoveItem (Item item)
        {
            if (this.Items.Contains(item)){ this.Items.Remove(item); }
        }
        public bool IsAlive()
        {
            return this.HP > 0;
        }
        public void Heal(Elf character, int amount)
        {
            character.HP = Math.Max(amount, character.VidaInicial);
        }

        public void Heal(Wizard character, int amount)
        {
            character.HP = Math.Max(amount, character.VidaInicial);
        }

        public void Heal(Duende character, int amount)
        {
            character.HP = Math.Max(amount, character.VidaInicial);
        }

        public void Attacking(Elf character)
        {
            int totalDamage = 0;
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Ataque;
                foreach(Item item in this.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                        totalDamage += item.Daño;
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.EstaRoto())
                    {
                        totalDamage -= item.Defensa;
                        item.Desgaste();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }

        public void Attacking(Wizard character)
        {
            int totalDamage = 0;
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Ataque;
                foreach(Item item in this.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                        totalDamage += item.Daño;
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.EstaRoto())
                    {
                        totalDamage -= item.Defensa;
                        item.Desgaste();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }

        public void Attacking(Duende character)
        {
            int totalDamage = 0;
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Ataque;
                foreach(Item item in this.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                        totalDamage += item.Daño;
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.EstaRoto())
                    {
                        totalDamage -= item.Defensa;
                        item.Desgaste();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }
    }
}