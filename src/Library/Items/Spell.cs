namespace Library
{
    public class Spell
    {
        public int Damage {get; private set;}
        public int Defense {get; private set;}

        public Spell(int damage, int defense)
        {
            this.Damage = damage;
            this.Defense = defense;
        }

    }
}