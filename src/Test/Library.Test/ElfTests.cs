using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class ElfTests
    {

        [Test]
        public void HealTest() // Verificamos que el metodo Heal cure correctamente.
        {
            Elf Gandalf = new Elf("Gandalf", 30, 300, 30);
            Undead Aainz = new Undead("Aainz", 30, 200, 0);
            Gandalf.Attack(Aainz);
            Gandalf.Heal(Aainz, 10);
            Assert.AreEqual(Aainz.HP, 180);
        }

        [Test]
        public void OverHealTest() // Verificamos que si se cura de mas a un personaje, este vuelve a su vida inicial.
        {
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Undead Aainz = new Undead("Aainz", 30, 200, 0);
            Gandalf.Attack(Aainz);
            Gandalf.Heal(Aainz, 1000);
            Assert.AreEqual(Aainz.HP, Aainz.BaseHP);
        }

        [Test]
        public void BasicAttackTest() // Verificamos que el un ataque basico sin items se calcule correctamente.
        {
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Undead Aainz = new Undead("Aainz", 30, 200, 0); 
            Gandalf.Attack(Aainz);
            Assert.AreEqual(Aainz.HP, Aainz.BaseHP - Gandalf.Damage);
        }

        [Test]
        public void AddItemTest() // Verificamos que se puedan agregar items a la lista de items, y que estos no se vean repetidos.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            List<Item> expected = new List<Item>();
            expected.Add(Sword);
            expected.Add(Orb);
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Gandalf.AddItem(Sword);
            Gandalf.AddItem(Orb);
            Gandalf.AddItem(Sword);
            Assert.AreEqual(Gandalf.Items, expected);
        }

        [Test]
        public void RemoveItemTest() // Verificamos que se puedan remover items de la lista de items, y que no surgen excepciones.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            List<Item> expected = new List<Item>();
            expected.Add(Orb);
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Gandalf.AddItem(Sword);
            Gandalf.AddItem(Orb);
            Gandalf.RemoveItem(Sword);
            Gandalf.RemoveItem(Sword);
            Assert.AreEqual(Gandalf.Items, expected);
        }

        [Test]
        public void ComplexAttackTest() // Verificamos que un ataque complejo con items haga el daño conforme a lo esperado.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Gandalf.AddItem(Sword);
            Gandalf.AddItem(Orb);
            Undead Aainz = new Undead("Aainz", 0, 300, 20); 
            Gandalf.Attack(Aainz);
            Assert.AreEqual(Aainz.HP, Aainz.BaseHP + Aainz.Defense - (Gandalf.Damage + Sword.Damage + Orb.Damage));
        }

        [Test]
        public void AttackingDeadCharacterTest() // Verificamos que atacar a un personaje ya muerto no cambie su vida.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 20);
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Gandalf.AddItem(Sword);
            Gandalf.AddItem(Orb);
            Undead Aainz = new Undead("Aainz", 0, 0, 20); 
            Gandalf.Attack(Aainz);
            Assert.AreEqual(Aainz.HP, 0);
        }

        [Test]
        public void BreakingItemTest() // Verificamos que tras cierta cantidad de usos un item se rompe por agotar su durabilidad.
        {
            Item Sword = new Item(30, 0, 20);
            Item Orb = new Item(30, 0, 30);
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Gandalf.AddItem(Sword);
            Gandalf.AddItem(Orb);
            Undead Aainz = new Undead("Aainz", 0, 300000000, 20); 
            for(int i = 0; i<20; i++)
            {
                Gandalf.Attack(Aainz);
            }
            Assert.AreEqual(Sword.Broken(), true);
        }
    }
}