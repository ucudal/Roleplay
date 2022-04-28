using System;
using System.Collections.Generic;
namespace Library
{
    public class Elf
    {
        public string Name { get; private set; }
        public int Damage { get; private set; } = 0;
        public int Defense { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int HP { get; set; } = 0;
        public int BaseHP { get; private set; } = 0;

        public Elf (string name, int attack, int health)
        {
            this.BaseHP = health;
            this.Name = name;
            this.Damage = attack;
            this.HP = health;
        }

        public int GetAttack()
        {
            int ataqueTotal = this.Damage;
            foreach(Item item in this.Items) 
            {
                if(!item.Broken())
                {
                    ataqueTotal += item.Damage;
                } 
            }
            return ataqueTotal;
        }

        public int GetDefense()
        {
            int defensaTotal = this.Defense;
            foreach(Item item in this.Items) 
            {
                if(!item.Broken())
                {
                    defensaTotal += item.Defense;
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
            character.HP = Math.Max(amount, character.BaseHP);
        }

        public void Heal(Wizard character, int amount)
        {
            character.HP = Math.Max(amount, character.BaseHP);
        }

        public void Heal(Dwarf character, int amount)
        {
            character.HP = Math.Max(amount, character.BaseHP);
        }

        public void Attack(Elf character)
        {
            int totalDamage = this.GetAttack() - this.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Damage;
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }

        public void Attack(Wizard character)
        {
            int totalDamage = this.GetAttack() - this.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Damage;
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }

        public void Attack(Dwarf character)
        {
            int totalDamage = this.GetAttack() - this.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                totalDamage = this.Damage;
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                foreach(Item item in character.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { character.RemoveItem(item); }
                }
                character.HP -= totalDamage;
            }
        }

        public void PrettyPrint()
        {
            Console.WriteLine($"Un elfo con {this.Damage} puntos de ataque, {this.HP} de vida, y {this.Defense} de defensa.");
        }
    }
}