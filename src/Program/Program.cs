using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Un personaje
            Elf Gandalf = new Elf("Gandalf", 120, 760, 30);
            // Dos items
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            Gandalf.AddItem(Sword);
            Gandalf.AddItem(Orb);
            // Un personaje
            Undead Aainz = new Undead("Aainz", 80, 980, 20); 
            // Dos items
            Item BoneBow = new Item(25, 5, 25);
            Item Scythe = new Item(35, 0, 15);
            Aainz.AddItem(BoneBow);
            Aainz.AddItem(Scythe);
            // Un personaje
            Dwarf Goliath = new Dwarf("Goliath", 100, 850, 30);
            // Dos items
            Item Hammer = new Item(50, 10, 5);
            Item Spear = new Item(30, 0, 25);
            Goliath.AddItem(Hammer);
            Goliath.AddItem(Spear);
        }
    }
}
