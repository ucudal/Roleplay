namespace Library
{
    public class Staff
    {
        public int Ataque {get; private set;} = 0;
        public int Defensa {get; private set;} = 0;
        public int Durabilidad {get; set;} = 100;

        public Staff(int ataque, int defensa)
        {
            this.Ataque = ataque;
            this.Defensa = defensa;
        }
        
    }
}