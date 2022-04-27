using System;
using System.Collections.Generic;
namespace Library
{
    public class Elf
    {
        public string Nombre { get; private set; }
        public int Ataque { get; private set; } = 0;
        public int Defensa { get; private set; } = 0;
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

        public int GetAtaque()
        {
            int ataqueTotal = this.Ataque;
            foreach(Item item in this.Items) 
            {
                if(!item.EstaRoto())
                {
                    ataqueTotal += item.Daño;
                } 
            }
            return ataqueTotal;
        }

        public int GetDefensa()
        {
            int defensaTotal = this.Defensa;
            foreach(Item item in this.Items) 
            {
                if(!item.EstaRoto())
                {
                    defensaTotal += item.Defensa;
                } 
            }
            return defensaTotal;
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
            int totalDamage = this.GetAtaque() - this.GetDefensa();
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Ataque;
                foreach(Item item in this.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }

        public void Attacking(Wizard character)
        {
            int totalDamage = this.GetAtaque() - this.GetDefensa();
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Ataque;
                foreach(Item item in this.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }

        public void Attacking(Duende character)
        {
            int totalDamage = this.GetAtaque() - this.GetDefensa();
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Ataque;
                foreach(Item item in this.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.EstaRoto())
                    {
                        item.Desgaste();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }
    }
}