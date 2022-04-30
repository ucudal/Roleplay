using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Gandalf.AddItem(Sword);
            Gandalf.AddItem(Orb);
            Undead Aainz = new Undead("Aainz", 0, 300, 20); 
            Gandalf.Attack(Aainz);
        }
    }
}
