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

        /// <summary>
        /// Metodo GetAttack se encuentra en la clase Dwarf por expert, ya que quien tiene los conocimientos
        /// necesarios para obtener el ataque total de Dwarf es la clase Dwarf. Porque conoce su mismo ataque,
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
        /// Metodo GetDefense se encuentra en la clase Dwarf por expert, ya que quien tiene los conocimientos
        /// necesarios para obtener la defensa total de Dwarf es la clase Dwarf. Porque conoce su misma defensa,
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
        /// Metodo attack que se encarga realizar el ataque de Dwarf a otros personajes, asignada por Expert
        /// ya que la clase que contiene los conocimientos para calcular el daño que realiza un Dwarf a otro
        /// personaje es Dwarf. Luego al igual que Heal aplicamos sobrecarga en este metodo.
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

        /// <summary>
        /// Metodo IsAlive designado por Expert, quien es capaz de conocer si Elf esta vivo o no?
        /// Elf ya que es aquel que conoce la vida de Elf.
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            return this.HP > 0;
        }

        /// <summary>
        /// El metodo ReceiveAttack fue asignado a la clase Dwarf por Expert, ya que aquel que a partir
        /// del daño que pretende hacer un enemigo a un Dwarf puede calcular cuanta vida pierde apartir de 
        /// este es Dwarf que es quien conoce su propia vida.
        /// </summary>
        /// <param name="amount"></param>
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

        /// <summary>
        /// Metodo AddItem asignado por Expert, quien agrega los items a la lista de items de Dwarf,
        /// aquel que conoce la lista de items de Dwarf, osea la misma clase Dwarf.
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
        /// Metodo RemoveItem asignado por Expert, quien remueve los items a la lista de items de Dwarf,
        /// aquel que conoce la lista de items de Dwarf, osea la misma clase Dwarf.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem (Item item)
        {
            if (this.Items.Contains(item))
            { 
                this.Items.Remove(item); 
            }
        }
    
    }
}

