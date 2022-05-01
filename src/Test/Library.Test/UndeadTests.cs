using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class UndeadTests
    {
        [Test]
        public void BasicAttackTest() // Verificamos que el un ataque basico sin items se calcule correctamente.
        {
            Elf Gandalf = new Elf("Gandalf", 120, 300, 0);
            Undead Aainz = new Undead("Aainz", 30, 200, 0); 
            Aainz.Attack(Gandalf);
            Assert.AreEqual(Gandalf.HP, Gandalf.BaseHP - Aainz.Damage);
        }

        [Test]
        public void AddItemTest() // Verificamos que se puedan agregar items a la lista de items, y que estos no se vean repetidos.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            List<Item> expected = new List<Item>();
            expected.Add(Sword);
            expected.Add(Orb);
            Undead Aainz = new Undead("Aainz", 30, 200, 0); 
            Aainz.AddItem(Sword);
            Aainz.AddItem(Orb);
            Aainz.AddItem(Sword);
            Assert.AreEqual(Aainz.Items, expected);
        }

        [Test]
        public void RemoveItemTest() // Verificamos que se puedan remover items de la lista de items, y que no surgen excepciones.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            List<Item> expected = new List<Item>();
            expected.Add(Orb);
            Undead Aainz = new Undead("Aainz", 30, 200, 0); 
            Aainz.AddItem(Sword);
            Aainz.AddItem(Orb);
            Aainz.RemoveItem(Sword);
            Aainz.RemoveItem(Sword);
            Assert.AreEqual(Aainz.Items, expected);
        }

        [Test]
        public void ComplexAttackTest() // Verificamos que un ataque complejo con items haga el daño conforme a lo esperado.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            Undead Aainz = new Undead("Aainz", 30, 200, 0);
            Aainz.AddItem(Sword);
            Aainz.AddItem(Orb);
            Elf Gandalf = new Elf("Aainz", 0, 300, 20); 
            Aainz.Attack(Gandalf);
            Assert.AreEqual(Gandalf.HP, Gandalf.BaseHP + Gandalf.Defense - (Aainz.Damage + Sword.Damage + Orb.Damage));
        }

        [Test]
        public void AttackingDeadCharacterTest() // Verificamos que atacar a un personaje ya muerto no cambie su vida.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            Undead Aainz = new Undead("Aainz", 30, 200, 0);
            Aainz.AddItem(Sword);
            Aainz.AddItem(Orb);
            Elf Gandalf = new Elf("Aainz", 0, 0, 20);  
            Aainz.Attack(Gandalf);
            Assert.AreEqual(Gandalf.HP, 0);
        }

        [Test]
        public void BreakingItemTest() // Verificamos que tras cierta cantidad de usos un item se rompe por agotar su durabilidad.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 30);
            Undead Aainz = new Undead("Aainz", 120, 300, 30);
            Aainz.AddItem(Sword);
            Aainz.AddItem(Orb);
            Elf Gandalf = new Elf("Gandalf", 0, 300000000, 20); 
            for(int i = 0; i<20; i++)
            {
                Aainz.Attack(Gandalf);
            }
            Assert.AreEqual(Sword.Broken(), true);
        }
    }
}