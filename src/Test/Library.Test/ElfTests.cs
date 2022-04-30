using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class ElfTests
    {

        [Test]
        public void HealTest()
        {
            Elf Gandalf = new Elf("Gandalf", 30, 300, 30);
            Undead Aainz = new Undead("Aainz", 30, 200, 0);
            Gandalf.Attack(Aainz);
            Gandalf.Heal(Aainz, 10);
            Assert.AreEqual(Aainz.HP, 180);
        }

        [Test]
        public void OverHealTest()
        {
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Undead Aainz = new Undead("Aainz", 30, 200, 0);
            Gandalf.Attack(Aainz);
            Gandalf.Heal(Aainz, 1000);
            Assert.AreEqual(Aainz.HP, Aainz.BaseHP);
        }

        [Test]
        public void BasicAttackTest()
        {
            Elf Gandalf = new Elf("Gandalf", 120, 300, 30);
            Undead Aainz = new Undead("Aainz", 30, 200, 0); 
            Gandalf.Attack(Aainz);
            Assert.AreEqual(Aainz.HP, Aainz.BaseHP - Gandalf.Damage);
        }

        [Test]
        public void AddItemTest()
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
        public void RemoveItemTest()
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
        public void ComplexAttackTest()
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
        public void AttackingDeadCharacterTest()
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
        public void BreakingItemTest()
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