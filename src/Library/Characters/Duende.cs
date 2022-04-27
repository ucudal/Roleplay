using System;
using System.Collections.Generic;

namespace Library {

    public class Duende {

        public string Nombre { get; private set; }
        public int Ataque { get; private set; } = 0;
        public int Defensa { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int HP { get; set; } = 0;
        public int VidaInicial { get; private set; } = 0;
        public int DañoTotal { get; private set; }
        public int DefensaTotal { get; private set; }

        public Duende (string nombre, int ataque, int defensa, int hp, int vidainicial, int dañototal) {

            this.Nombre = nombre;
            this.Ataque = ataque;
            this.Defensa = defensa;
            this.HP = hp;
            this.VidaInicial = vidainicial;
            this.DañoTotal = dañototal;
        }

        public int ObtenerAtaque() {
            foreach (Item item in this.Items)
            {
                this.DañoTotal = this.Ataque + item.Daño;
            }
            return DañoTotal;
        }

        public int ObtenerDefensa() {
            foreach (Item item in this.Items)
            {
                this.DefensaTotal = this.Defensa + item.Defensa;
            }
            return DefensaTotal;
        }

        public void Atacar (Duende duende) {
            foreach (Item item in this.Items) {

                if (!item.EstaRoto()) {
                    item.Desgaste();
                    this.Ataque = this.Ataque + item.Daño;
                } else {
                    this.DesequiparItem(item);
                }
                
            }
            duende.HP = duende.HP - this.Ataque;
        }

        public void EquiparItem (Item item)
        {
            if (!this.Items.Contains(item)) {

                this.Items.Add(item); 
            } 
        }
        public void DesequiparItem (Item item)
        {
            if (this.Items.Contains(item)) {

                this.Items.Remove(item); 
            } 
        }
    
    }
}

