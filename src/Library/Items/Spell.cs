namespace Library
{
    public class Spell
    {
        public int Ataque {get; private set;}
        public int Defensa {get; private set;}

        public Spell(int ataque, int defensa)
        {
            this.Ataque = ataque;
            this.Defensa = defensa;
        }

    }
}