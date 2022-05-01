using NUnit.Framework;
using Library;

namespace Test.Library
{

    public class WizardTests
    {

        /// <summary>
        /// Verifica que el ataque total del wizard sin items es igual al ataque base.
        /// </summary>
        [Test]
        public void WizardBaseDamageTest() 
        {
            Wizard oz = new Wizard(36, 48, 97);

            Assert.AreEqual(oz.Damage, oz.BaseDamage);
            Assert.AreEqual(48, oz.Damage);
        }
        
        /// <summary>
        /// Verifica que el ataque total del wizard con un item es igual al ataque base + el ataque del item.
        /// Tambien que el daño basico no se modifique.
        /// </summary>
        [Test]
        public void WizardDamageWithItemTest() 
        {
            Wizard oz = new Wizard(36, 10, 97);
            Item sword = new Item(10, 10, 10);

            oz.AddItem(sword);

            Assert.AreEqual(10, oz.BaseDamage);
            Assert.AreEqual(oz.BaseDamage + sword.Damage, oz.Damage);
        } 

        /// <summary>
        /// Verifica que no es posible añadir items duplicados.
        /// </summary>
        [Test]
        public void WizardItemsDoNotRepeatTest() 
        {
            Wizard oz = new Wizard(36, 10, 97);
            Item sword = new Item(10, 10, 10);

            oz.AddItem(sword);
            oz.AddItem(sword);

            Assert.AreEqual(1, oz.Items.Count);
            Assert.AreEqual(10, oz.BaseDamage);
            Assert.AreEqual(oz.Damage, oz.BaseDamage + sword.Damage);
        }

        /// <summary>
        /// Verifica que no es posible añadir items duplicados.
        /// </summary>
        [Test]
        public void WizardAreCorrectlyRemovedTest()
        {
            Wizard oz = new Wizard(36, 10, 97);
            Item sword = new Item(10, 10, 10);

            oz.AddItem(sword);
            oz.RemoveItem(sword);

            Assert.AreEqual(0, oz.Items.Count);
            Assert.AreEqual(10, oz.BaseDamage);
            Assert.AreEqual(oz.BaseDamage, oz.Damage);
        }   
        
        /// <summary>
        /// Verifica que el ataque de un personaje sin items es igual al daño infligido en la vida de
        /// otro pesonaje.
        /// </summary>
        [Test]
        public void WizardAttacksCorrectlyWithoutItemsTest()
        {
            Wizard oz = new Wizard(36, 10, 97);
            Wizard harry = new Wizard(20, 20, 20);

            oz.Attack(harry);

            Assert.AreEqual(0, oz.Items.Count);
            Assert.AreEqual(10, oz.Damage);
            Assert.AreEqual(harry.BaseHP - (oz.Damage-harry.Defense), harry.HP);
        }        
        
        /// <summary>
        /// Verifica que el ataque de un personaje con items es igual al daño infligido en la vida de
        /// otro pesonaje.
        /// </summary>
        [Test]
        public void WizardAttacksCorrectlyWithItemsTest()
        {
            Wizard oz = new Wizard(36, 10, 97);
            Wizard harry = new Wizard(20, 20, 20);
            Item sword = new Item(10, 10, 10);

            oz.AddItem(sword);

            oz.Attack(harry);

            Assert.AreEqual(1, oz.Items.Count);
            Assert.AreEqual(oz.BaseDamage + sword.Damage, oz.Damage);
            Assert.AreEqual(harry.BaseHP - (oz.Damage-harry.Defense), harry.HP);
        }      
        
        /// <summary>
        /// Verifica que la vida de un personaje muerto no varía tras ser atacado, al igual que la durabilidad
        /// de los items del personaje atacante que tienen atributos de daño.
        /// </summary>
        [Test]
        public void WizardAttacksDeadWizardDoesNothingTest()
        {
            Wizard oz = new Wizard(36, 10, 97);
            Wizard harry = new Wizard(0, 20, 20);
            int swordBaseDurability = 10;
            Item sword = new Item(10, 10, swordBaseDurability);

            oz.AddItem(sword);

            oz.Attack(harry);

            Assert.AreEqual(1, oz.Items.Count);
            Assert.AreEqual(oz.BaseDamage + sword.Damage, oz.Damage);
            Assert.AreEqual(0, harry.HP);
            Assert.AreEqual(harry.BaseHP, harry.HP);
            Assert.AreEqual(sword.Durability, swordBaseDurability);
        }        
        
        /// <summary>
        /// Verifica que un item cuya durabilidad llega a 0 por ser utilizado, no cuenta en el daño final del Wizard.
        /// </summary>
        [Test]
        public void WizardItemBreaksTest()
        {
            Wizard oz = new Wizard(36, 10, 97);
            Wizard harry = new Wizard(30, 20, 20);
            int swordBaseDurability = 1;
            Item sword = new Item(10, 10, swordBaseDurability);

            oz.AddItem(sword);

            oz.Attack(harry);

            Assert.AreEqual(0, oz.Items.Count);
            Assert.AreEqual(oz.BaseDamage, oz.Damage);
            Assert.AreEqual(swordBaseDurability-1, sword.Durability);
        }

    }


}