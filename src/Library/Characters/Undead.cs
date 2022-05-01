using System;
using System.Collections.Generic;
namespace Library
{
    public class Undead
    {
        public string Name { get; private set; }
        public int HP { get; set; } = 0;
        public int BaseHP { get; private set; } = 0;
        public int Defense { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int Damage { get; private set; } = 0;

        public Undead(string name, int attack, int health, int defense)
        {
            this.Name = name;
            this.HP = health;
            this.BaseHP = health;
            this.Defense = defense;
            this.Damage = attack;
        }

        /// <summary>
        /// Metodo GetDefense se encuentra en la clase Undead por expert, ya que quien tiene los conocimientos
        /// necesarios para obtener la defensa total de Undead es la clase Undead. Porque conoce su misma defensa,
        /// los items y sus defensas.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo GetAttack se encuentra en la clase Undead por expert, ya que quien tiene los conocimientos
        /// necesarios para obtener el ataque total de Elf es la clase Undead. Porque conoce su mismo ataque,
        /// los items y sus ataques.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo AddItem asignado por Expert, quien agrega los items a la lista de items de Undead,
        /// aquel que conoce la lista de items de Undead, osea la misma clase Undead.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem (Item item)
        {
            if (!this.Items.Contains(item))
            { 
                this.Items.Add(item); 
            }
        }

        /// <summary>
        /// Metodo RemoveItem asignado por Expert, quien remueve los items a la lista de items de Undead,
        /// aquel que conoce la lista de items de Undead, osea la misma clase Undead.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem (Item item)
        {
            if (this.Items.Contains(item))
            { 
                this.Items.Remove(item); 
            }
        }

        /// <summary>
        /// Metodo IsAlive designado por Expert, quien es capaz de conocer si Undead esta vivo o no?
        /// Undead ya que es aquel que conoce la vida de Undead.
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            return this.HP > 0;
        }

        /// <summary>
        /// Metodo attack que se encarga realizar el ataque de Undead a otros personajes, asignada por Expert
        /// ya que la clase que contiene los conocimientos para calcular el daño que realiza un Undead a otro
        /// personaje es Undead. Luego al igual que Heal aplicamos sobrecarga en este metodo.
        /// </summary>
        /// <param name="character"></param>
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
    }
}