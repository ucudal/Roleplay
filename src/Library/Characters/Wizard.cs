using System;
using System.Collections.Generic;

namespace Library
{
    public class Wizard
    {
        private int InitialHealth {get; set;}
        public int HP {get; private set;}
        public int Ataque {get; private set;}
        public int Defensa {get; private set;}
        public SpellBook SpellBook {get; private set;}
        public List<Item> Items {get;} = new List<Item>();

        public Wizard(int hp, int ataque, int defensa)
        {
            this.InitialHealth = hp;
            this.HP = hp;
            this.Ataque = ataque;
            this.Defensa = defensa;
        }

        public bool IsAlive()
        {
            return this.HP > 0;
        }

        public void AddSpellBook(SpellBook spellBook)
        {
            if(this.SpellBook != null) RemoveSpellBook();
            this.SpellBook = spellBook;
            this.Ataque += spellBook.Ataque;
            this.Defensa += spellBook.Defensa;
        }

        public void RemoveSpellBook()
        {
            if(this.SpellBook == null) return;
            this.Ataque = Math.Max(0, this.Ataque-this.SpellBook.Ataque);
            this.Defensa = Math.Max(0, this.Defensa-this.SpellBook.Defensa);
        }      
        
        public void AddItem(Item item)
        {
            if(this.Items.Contains(item)) return;
            this.Items.Add(item);
            this.Ataque += item.Daño;
            this.Defensa += item.Defensa;
        }

        public void RemoveItem(Item item)
        {
            if(!this.Items.Contains(item)) return;
            this.Items.Remove(item);
            this.Ataque = Math.Max(0, this.Ataque-item.Daño);
            this.Defensa = Math.Max(0, this.Defensa-item.Defensa);
        }

        public void Attack(Wizard wizard)
        {
            if(!wizard.IsAlive() || !this.IsAlive()) return;
            wizard.HP = wizard.HP - this.Ataque;
            if(this.SpellBook != null)
            {
                this.SpellBook.Durabilidad -= 5;
                if(this.SpellBook.Durabilidad <= 0)
                {
                    RemoveSpellBook();
                }
            }
            foreach(Item item in this.Items)
            {
                item.Desgaste(1);
                if(item.Durabilidad <= 0)
                {
                    RemoveItem(item);
                }
            }
        }
    }
}