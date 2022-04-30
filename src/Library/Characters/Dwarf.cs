using System;
using System.Collections.Generic;

namespace Library {

    public class Dwarf {

        public string Name { get; private set; }
        public int Damage { get; private set; } = 0;
        public int Defense { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int HP { get; set; } = 0;
        public int BaseHP { get; private set; } = 0;
        
        public Dwarf (string name, int attack, int health, int defense) 
        {
            this.Name = Name;
            this.Damage = attack;
            this.Defense = defense;
            this.HP = health;
            this.BaseHP = health;
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

        public void Attack(Elf character)
        {
            int totalDamage = this.GetAttack() - character.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                character.ReceiveAttack(totalDamage);
            }
        }

        public void Attack(Undead character)
        {
            int totalDamage = this.GetAttack() - character.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                character.ReceiveAttack(totalDamage);
            }
        }
        public void Attack(Wizard character)
        {
            int totalDamage = this.GetAttack() ;
            if(this.IsAlive() && character.IsAlive()) 
            {
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                character.ReceiveAttack(totalDamage);
            }
        }

        public void Attack(Dwarf character)
        {
            int totalDamage = this.GetAttack() - character.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                character.ReceiveAttack(totalDamage);
            }
        }

        public bool IsAlive()
        {
            return this.HP > 0;
        }

        public void ReceiveAttack(int amount)
        {
            foreach(Item item in this.Items)
            {
                if(!item.Broken())
                {
                    item.Deterioration();
                }
                else { this.RemoveItem(item); }
            }
            if(this.HP - amount < 0) { this.HP = 0; }
            else { this.HP -= amount; }
        }
        public void AddItem (Item item)
        {
            if (!this.Items.Contains(item))
            {
                this.Items.Add(item); 
            }
        }
        public void RemoveItem (Item item)
        {
            if (this.Items.Contains(item))
            { 
                this.Items.Remove(item); 
            }
        }
    
    }
}

