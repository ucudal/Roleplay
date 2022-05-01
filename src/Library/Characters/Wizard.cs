using System.Collections.Generic;

namespace Library
{
    public class Wizard
    {
        public int BaseHP {get; private set;}
        public int BaseDamage {get; private set;}
        public int BaseDefense {get; private set;}
        public int HP {get; set;}
        public int Damage {get; private set;}
        public int Defense {get; private set;}
        public SpellBook SpellBook {get; private set;}
        public List<Item> Items {get; private set;} = new List<Item>();

        public Wizard(int hp, int damage, int defense)
        {
            this.BaseHP = hp;
            this.HP = hp;
            this.BaseDamage = damage;
            this.BaseDefense = defense;
            CalculateAttributes();
        }


        private void CalculateAttributes()
        {
            this.Damage = this.BaseDamage;
            this.Defense = this.BaseDefense;
            if(this.SpellBook != null)
            {
                if(this.SpellBook.IsBroken())
                {
                    RemoveSpellBook();
                    return;
                }
                this.Damage += this.SpellBook.Damage;
                this.Defense += this.SpellBook.Defense;
            }
            foreach(Item item in this.Items)
            {
                if(item.Broken())
                {
                    RemoveItem(item);
                    return;
                }
                this.Damage += item.Damage;
                this.Defense += item.Defense;
            }
        }


        public bool IsAlive()
        {
            return this.HP > 0;
        }

        public void AddSpellBook(SpellBook spellBook)
        {
            if(this.SpellBook != null) RemoveSpellBook();
            this.SpellBook = spellBook;
            CalculateAttributes();
        }

        public void RemoveSpellBook()
        {
            if(this.SpellBook == null) return;
            this.SpellBook = null;
            CalculateAttributes();
        }     
        
        public void AddItem (Item item)
        {
            if (!this.Items.Contains(item))
            {
                this.Items.Add(item);
                CalculateAttributes();
            }
        }
        public void RemoveItem (Item item)
        {
            if (this.Items.Contains(item)){ 
                this.Items.Remove(item);
                CalculateAttributes();
            }
        }     
        

        public void Attack(Wizard wizard)
        {
            if(!wizard.IsAlive() || !this.IsAlive()) return;
            wizard.ReceiveAttack(this.Damage);
            //Los items que tengan atributos de ataque se desgastan
            if(this.SpellBook != null && this.SpellBook.Damage != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Damage != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }
        
        public void Attack(Elf elf)
        {
            if(!elf.IsAlive() || !this.IsAlive()) return;
            elf.ReceiveAttack(this.Damage);
            //Los items que tengan atributos de ataque se desgastan
            if(this.SpellBook != null && this.SpellBook.Damage != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Damage != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }

        public void Attack(Dwarf dwarf)
        {
            if(!dwarf.IsAlive() || !this.IsAlive()) return;
            dwarf.ReceiveAttack(this.Damage);
            //Los items que tengan atributos de ataque se desgastan
            if(this.SpellBook != null && this.SpellBook.Damage != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Damage != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }

        public void ReceiveAttack(int damage)
        {
            if(!IsAlive()) return;
            this.HP -= damage - this.Defense;
            //Los items que tengan atributos de defensa se desgastan
            if(this.SpellBook != null && this.SpellBook.Defense != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Defense != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }

        
    }
}