using System;
using System.Collections.Generic;
namespace Library
{
    public class Elf
    {
        public string Name { get; private set; }
        public int Damage { get; private set; } = 0;
        public int Defense { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public int HP { get; set; } = 0;
        public int BaseHP { get; private set; } = 0;

        public Elf (string name, int attack, int health, int defense)
        {
            this.BaseHP = health;
            this.Name = name;
            this.Damage = attack;
            this.HP = health;
            this.Defense = defense;
        }

        /// <summary>
        /// Metodo GetAttack se encuentra en la clase Elf por expert, ya que quien tiene los conocimientos
        /// necesarios para obtener el ataque total de Elf es la clase Elf. Porque conoce su mismo ataque,
        /// los items y sus ataques.
        /// </summary>
        /// <returns></returns>
        public int GetAttack()
        {
            // El ataque es la suma del ataque base del elfo + la sumatoria del ataque de los items
            int ataqueTotal = this.Damage;
            foreach(Item item in this.Items) 
            {
                // Aqui verificamos que los items no esten rotos antes de calcular el ataque.
                if(!item.Broken())
                {
                    ataqueTotal += item.Damage;
                } 
            }
            return ataqueTotal;
        }

        /// <summary>
        /// Metodo GetDefense se encuentra en la clase Elf por expert, ya que quien tiene los conocimientos
        /// necesarios para obtener la defensa total de Elf es la clase Elf. Porque conoce su misma defensa,
        /// los items y sus defensas.
        /// </summary>
        /// <returns></returns>
        public int GetDefense()
        {
            int defensaTotal = this.Defense;
            foreach(Item item in this.Items) 
            {
                if(!item.Broken())
                {
                    defensaTotal += item.Defense;
                } 
            }
            return defensaTotal;
        }
        /// <summary>
        /// Metodo AddItem asignado por Expert, quien agrega los items a la lista de items de Elf,
        /// aquel que conoce la lista de items de Elf, osea la misma clase Elf.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem (Item item)
        {
            // Intentamos que no se dupliquen los items
            if (!this.Items.Contains(item)){ this.Items.Add(item); }
        }
        /// <summary>
        /// Metodo RemoveItem asignado por Expert, quien remueve los items a la lista de items de Elf,
        /// aquel que conoce la lista de items de Elf, osea la misma clase Elf.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem (Item item)
        {
            // Vemos que no ocurra una excepcion por intentar de remover un item que no esta en la lista.
            if (this.Items.Contains(item)){ this.Items.Remove(item); }
        }
        /// <summary>
        /// Metodo IsAlive designado por Expert, quien es capaz de conocer si Elf esta vivo o no?
        /// Elf ya que es aquel que conoce la vida de Elf.
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            return this.HP > 0;
        }
        /// <summary>
        /// Heal es una habilidad exclusiva de los elfos, puede curarse a si mismo como a otros personajes.
        /// Para poder curar a distintas razas usamos sobrecarga, que es basicamente agregar multiples
        /// metodos con el mismo nombre pero distintos parametros, el metodo que se ejecute cuando llamamos
        /// a esta dependera de los parametros dados.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="amount"></param>
        public void Heal(Elf character, int amount)
        {
            // Si el personaje se cura mas de lo que su vida base era, en vez de subirse su vida aun por encima de la
            // base solo se regenera los daños que pudo haber recibido y vuelve a su vida inicial.
            if(amount + this.HP >= character.BaseHP)
            {
                character.HP = character.BaseHP;
            }
            else
            {
                character.HP += amount;
            }
        }

        public void Heal(Undead character, int amount)
        {
            if(amount + this.HP >= character.BaseHP)
            {
                character.HP = character.BaseHP;
            }
            else
            {
                character.HP += amount;
            }
        }

        public void Heal(Dwarf character, int amount)
        {
            if(amount + this.HP >= character.BaseHP)
            {
                character.HP = character.BaseHP;
            }
            else
            {
                character.HP += amount;
            }
        }

        public void Heal(Wizard character, int amount)
        {
            if(amount + this.HP >= character.BaseHP)
            {
                character.HP = character.BaseHP;
            }
            else
            {
                character.HP += amount;
            }
        }

        /// <summary>
        /// Metodo attack que se encarga realizar el ataque de elf a otros personajes, asignada por Expert
        /// ya que la clase que contiene los conocimientos para calcular el daño que realiza un Elf a otro
        /// personaje es Elf. Luego al igual que Heal aplicamos sobrecarga en este metodo.
        /// </summary>
        /// <param name="character"></param>
        public void Attack(Elf character)
        {
            int totalDamage = this.GetAttack() - character.GetDefense();
            // Verificamos que tanto nuestro personaje como al que vamos a atacar esten vivos, ya que no tiene
            // sentido ser atacado o atacar si el otro o uno mismo esta muerto.
            if(this.IsAlive() && character.IsAlive()) 
            {
                // Verificamos que los items no esten rotos antes de desgastarlos. Si lo estan los removemos de los items.
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                // El personaje enemigo recibe el daño.
                character.ReceiveAttack(totalDamage);
            }
        }

        public void Attack(Undead character)
        {
            int totalDamage = this.GetAttack() - character.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                character.ReceiveAttack(totalDamage);
            }
        }
        public void Attack(Wizard character)
        {
            int totalDamage = this.GetAttack() ;
            if(this.IsAlive() && character.IsAlive()) 
            {
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                character.ReceiveAttack(totalDamage);
            }
        }

        public void Attack(Dwarf character)
        {
            int totalDamage = this.GetAttack() - character.GetDefense();
            if(this.IsAlive() && character.IsAlive()) 
            {
                foreach(Item item in this.Items)
                {
                    if(!item.Broken())
                    {
                        item.Deterioration();
                    }
                    else { this.RemoveItem(item); }
                }
                character.ReceiveAttack(totalDamage);
            }
        }

        /// <summary>
        /// El metodo ReceiveAttack fue asignado a la clase Elf por Expert, ya que aquel que a partir
        /// del daño que pretende hacer un enemigo a un elf puede calcular cuanta vida pierde apartir de 
        /// este es Elf que es quien conoce su propia vida.
        /// </summary>
        /// <param name="amount"></param>
        public void ReceiveAttack(int amount)
        {
            // Se deterioran nuestros items por ser atacados
            foreach(Item item in this.Items)
            {
                if(!item.Broken())
                {
                    item.Deterioration();
                }
                else { this.RemoveItem(item); }
            }
            // Para que la vida no de negativa vemos si al restar nuestra vida a el daño recibido da o no menor que 0.
            if(this.HP - amount < 0) { this.HP = 0; }
            else { this.HP -= amount; }
        }
    }
}