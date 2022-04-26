using System;

namespace Library
{
    public class Wizard
    {
        public int HP {get; private set;}
        public int Ataque {get; set;}
        public int Defensa {get; set;}
        public SpellBook SpellBook {get; private set;}
        public Staff Staff {get; private set;}

        public Wizard(int hp, int ataque, int defensa)
        {
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
        
        public void AddStaff(Staff staff)
        {
            if(this.Staff != null) RemoveStaff();
            this.Staff = staff;
            this.Ataque += staff.Ataque;
            this.Defensa += staff.Defensa;
        }

        public void RemoveStaff()
        {
            if(this.Staff == null) return;
            this.Ataque = Math.Max(0, this.Ataque-this.Staff.Ataque);
            this.Defensa = Math.Max(0, this.Defensa-this.Staff.Defensa);
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
            if(this.Staff != null)
            {
                this.Staff.Durabilidad -= 5;
                if(this.Staff.Durabilidad <= 0)
                {
                    RemoveStaff();
                }
            }
        }
    }
}