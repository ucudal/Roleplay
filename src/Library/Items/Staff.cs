namespace Library
{
    public class Staff
    {
        public int Ataque {get; private set;}
        public int Defensa {get; private set;}
        public int Durabilidad {get; set;}

        public Staff(int ataque, int defensa, int durabilidad = 100)
        {
            this.Ataque = ataque;
            this.Defensa = defensa;
            this.Durabilidad = durabilidad;
        }

        public bool EstaRoto()
        {
            return this.Durabilidad <= 0;
        }
        public void Desgaste(int amount)
        {
            if(!this.EstaRoto()) this.Durabilidad--;
        }
    }
}