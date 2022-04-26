namespace Library
{
    public class SpellBook
    {
        public int Ataque {get; private set;} = 0;
        public int Defensa {get; private set;} = 0;
        public int Durabilidad {get; set;} = 100;

        public void AddSpell(Spell spell)
        {
            this.Ataque += spell.Ataque;
            this.Defensa += spell.Defensa;
        }
    }
}