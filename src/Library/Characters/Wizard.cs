
namespace Library
{
    public class Wizard
    {
        public int BaseHP {get; private set;}
        public int BaseAtaque {get; private set;}
        public int BaseDefensa {get; private set;}
        public int HP {get; set;}
        public int Ataque {get; private set;}
        public int Defensa {get; private set;}
        public SpellBook SpellBook {get; private set;}
        public Staff Staff {get; set;}

        public Wizard(int hp, int ataque, int defensa)
        {
            this.BaseHP = hp;
            this.HP = hp;
            this.BaseAtaque = ataque;
            this.BaseDefensa = defensa;
            CalcularAtributos();
        }


        private void CalcularAtributos()
        {
            this.Ataque = this.BaseAtaque;
            this.Defensa = this.BaseDefensa;
            if(this.SpellBook != null)
            {
                if(this.SpellBook.EstaRoto())
                {
                    RemoveSpellBook();
                    return;
                }
                this.Ataque += this.SpellBook.Ataque;
                this.Defensa += this.SpellBook.Defensa;
            }
            if(this.Staff != null)
            {
                if(this.Staff.EstaRoto())
                {
                    RemoveStaff();
                    return;
                }
                this.Ataque += this.Staff.Ataque;
                this.Defensa += this.Staff.Defensa;
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
            CalcularAtributos();
        }

        public void RemoveSpellBook()
        {
            if(this.SpellBook == null) return;
            this.SpellBook = null;
            CalcularAtributos();
        }     
        
        public void AddStaff(Staff staff)
        {
            if(this.Staff != null) RemoveStaff();
            this.Staff = staff;
            CalcularAtributos();
        }

        public void RemoveStaff()
        {
            if(this.Staff == null) return;
            this.Staff = null;
            CalcularAtributos();
        }      
        

        public void Attack(Wizard wizard)
        {
            if(!wizard.IsAlive() || !this.IsAlive()) return;
            wizard.ReceiveAttack(this.Ataque);
            //Los items que tengan atributos de ataque se desgastan
            if(this.SpellBook != null && this.SpellBook.Ataque != 0)
            {
                this.SpellBook.Desgaste(1);
            }
            if(this.Staff != null && this.Staff.Ataque != 0)
            {
                this.Staff.Desgaste(1);
            }
            CalcularAtributos();
        }

        public void ReceiveAttack(int damage)
        {
            if(!IsAlive()) return;
            this.HP -= damage - this.Defensa;
            //Los items que tengan atributos de defensa se desgastan
            if(this.SpellBook != null && this.SpellBook.Defensa != 0)
            {
                this.SpellBook.Desgaste(1);
            }
            if(this.Staff != null && this.Staff.Defensa != 0)
            {
                this.Staff.Desgaste(1);
            }
            CalcularAtributos();
        }
    }
}