using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa a un personaje tipo Wizard, cuya habilidad especial es la habilidad de poseer el
    /// libro de hechizos.
    /// </summary>
    public class Wizard
    {
        /// <summary>
        /// Atributo vida inicial del personaje.
        /// </summary>
        /// <value>Vida inicial del personaje.</value>
        public int BaseHP {get; private set;}
        /// <summary>
        /// Atributo daño inicial del personaje.
        /// </summary>
        /// <value>Daño inicial del personaje.</value>
        public int BaseDamage {get; private set;}
        /// <summary>
        /// Atributo defensa inicial del personaje.
        /// </summary>
        /// <value>Defensa inicial del personaje.</value>
        public int BaseDefense {get; private set;}
        /// <summary>
        /// Atributo puntos de salud actuales del personaje.
        /// </summary>
        /// <value>Puntos de salud actuales del personaje.</value>
        public int HP {get; set;}
        /// <summary>
        /// Atributo Daño actual del personaje.
        /// </summary>
        /// <value>Daño actual del personaje.</value>
        public int Damage {get; private set;}
        /// <summary>
        /// Atributo puntos de salud actuales del personaje.
        /// </summary>
        /// <value>Puntos de salud actuales del personaje.</value>
        public int Defense {get; private set;}
        /// <summary>
        /// Atributo libro de hechizos del personaje. Puede ser null o tener un valor.
        /// </summary>
        /// <value>null o un objeto SpellBook.</value>
        public SpellBook SpellBook {get; private set;}
        /// <summary>
        /// Lista de items que contiene el personaje.
        /// </summary>
        /// <value>Items que lleva el personaje.</value>
        public List<Item> Items {get; private set;} = new List<Item>();


        /// <summary>
        /// Crea un nuevo wizard, con valores iniciales para sus atributos, y calcula
        ///  los valores de los atributos finales.
        /// </summary>
        /// <param name="hp">El valor inicial de la vida del personaje.</param>
        /// <param name="damage">El valor inicial del daño del personaje.</param>
        /// <param name="defense">El valor inicial de la defensa del personaje.</param>
        public Wizard(int hp, int damage, int defense)
        {
            this.BaseHP = hp;
            this.HP = hp;
            this.BaseDamage = damage;
            this.BaseDefense = defense;
            CalculateAttributes();
        }

        /// <summary>
        /// Calcula los atributos finales, basandose en los valores iniciales y los items del personaje.
        /// Se llama cada vez que hay un cambio en los items, y cada vez que el personaje ataca o es atacado.
        /// </summary>
        private void CalculateAttributes()
        {
            this.Damage = this.BaseDamage;
            this.Defense = this.BaseDefense;
            if(this.SpellBook != null)
            {
                if(this.SpellBook.IsBroken())
                {
                    RemoveSpellBook();
                    return;
                }
                this.Damage += this.SpellBook.Damage;
                this.Defense += this.SpellBook.Defense;
            }
            foreach(Item item in this.Items)
            {
                if(item.Broken())
                {
                    RemoveItem(item);
                    return;
                }
                this.Damage += item.Damage;
                this.Defense += item.Defense;
            }
        }

        /// <summary>
        /// Checkea si el personaje sigue con vida.
        /// </summary>
        /// <returns>true si el personaje está con vida, false en otro caso.</returns>
        public bool IsAlive()
        {
            return this.HP > 0;
        }

        /// <summary>
        /// Añade un SpellBook al personaje.
        /// </summary>
        /// <param name="spellBook">El item tipo SpellBook a añadir</param>
        public void AddSpellBook(SpellBook spellBook)
        {
            if(this.SpellBook != null) RemoveSpellBook();
            this.SpellBook = spellBook;
            CalculateAttributes();
        }

        /// <summary>
        /// Remueve el SpellBook al personaje, en caso de tener uno.
        /// </summary>
        public void RemoveSpellBook()
        {
            if(this.SpellBook == null) return;
            this.SpellBook = null;
            CalculateAttributes();
        }     
        
        /// <summary>
        /// Añade un item al personaje.
        /// </summary>
        /// <param name="item">El item a añadir.</param>
        public void AddItem (Item item)
        {
            if (!this.Items.Contains(item))
            {
                this.Items.Add(item);
                CalculateAttributes();
            }
        }

        /// <summary>
        /// Remueve un item específico del personaje, en caso de que lo tenga.
        /// </summary>
        /// <param name="item">El item a remover.</param>
        public void RemoveItem (Item item)
        {
            if (this.Items.Contains(item)){ 
                this.Items.Remove(item);
                CalculateAttributes();
            }
        }     
        
        /// <summary>
        /// Efectúa un ataque a otro personaje de tipo Wizard.
        /// </summary>
        /// <param name="wizard">El personaje a atacar.</param>
        public void Attack(Wizard wizard)
        {
            if(!wizard.IsAlive() || !this.IsAlive()) return;
            wizard.ReceiveAttack(this.Damage);
            //Los items que tengan atributos de ataque se desgastan
            if(this.SpellBook != null && this.SpellBook.Damage != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Damage != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }

        /// <summary>
        /// Efectúa un ataque a otro personaje de tipo Elf.
        /// </summary>
        /// <param name="elf">El personaje a atacar.</param>
        public void Attack(Elf elf)
        {
            if(!elf.IsAlive() || !this.IsAlive()) return;
            elf.ReceiveAttack(this.Damage);
            //Los items que tengan atributos de ataque se desgastan
            if(this.SpellBook != null && this.SpellBook.Damage != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Damage != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }

        /// <summary>
        /// Efectúa un ataque a otro personaje de tipo Dwarf.
        /// </summary>
        /// <param name="dwarf">El personaje a atacar.</param>
        public void Attack(Dwarf dwarf)
        {
            if(!dwarf.IsAlive() || !this.IsAlive()) return;
            dwarf.ReceiveAttack(this.Damage);
            //Los items que tengan atributos de ataque se desgastan
            if(this.SpellBook != null && this.SpellBook.Damage != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Damage != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }

        /// <summary>
        /// Recibe daño por parte de otro personaje.
        /// </summary>
        /// <param name="damage">El daño recibido.</param>
        public void ReceiveAttack(int damage)
        {
            if(!IsAlive()) return;
            this.HP -= damage - this.Defense;
            //Los items que tengan atributos de defensa se desgastan
            if(this.SpellBook != null && this.SpellBook.Defense != 0)
            {
                this.SpellBook.Deteriorate(1);
            }
            foreach(Item item in this.Items)
            {
                if(item != null && item.Defense != 0)
                {
                    item.Deterioration();
                }
            }
            CalculateAttributes();
        }

        
    }
}