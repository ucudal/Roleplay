using System;
using System.Collections.Generic;

namespace Library {

    public class Duende {

        private int HP { get; set; }
        private int Daño { get; set; }
        private int Resistencia { get; set; }
        public int VidaInicial { get; set; }
        List<Item> ListadeItems = new List<Item>();

        public Duende (int hp, int daño, int resistencia, int vidainicial) {

            this.HP = hp;
            this.Daño = daño;
            this.Resistencia = resistencia;
            this.VidaInicial = vidainicial;
        }

        public void Atacar (Duende duende) {
            foreach (Item item in this.ListadeItems) {
                item.Desgaste();
                this.Daño = this.Daño + item.Daño;
            }
            duende.HP = duende.HP - this.Daño;
        }

        public void EquiparItem (Item item)
        {
            if (!this.ListadeItems.Contains(item)) {

                this.ListadeItems.Add(item); 
            } 
        }
        public void DesequiparItem (Item item)
        {
            if (this.ListadeItems.Contains(item)) {
                this.ListadeItems.Remove(item); 
                
            } 
        }
    
    }
}

