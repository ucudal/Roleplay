namespace Library
{
    public class SpellBook
    {
        public int Damage {get; private set;} = 0;
        public int Defense {get; private set;} = 0;
        public int Durability {get; set;}

        public SpellBook(int durability = 100)
        {
            this.Durability = durability;
        }

        public void AddSpell(Spell spell)
        {
            this.Damage += spell.Damage;
            this.Defense += spell.Defense;
        }

        public bool IsBroken()
        {
            return this.Durability <= 0;
        }
        public void Deteriorate(int amount)
        {
            if(!this.IsBroken()) this.Durability--;
        }
    }
}