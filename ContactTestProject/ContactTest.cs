using ContactLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactTestProject
{
    [TestClass]
    public class ContactTest
    {
        ContactProvider provider;

        [TestInitialize]
        public void TestInitialize()
        {
            provider = new ContactProvider();
        }

        [TestMethod]
        public void TestAddContact()
        {
            var name = "Сергей";
            var number = "+7(960) 124 12 45";
            provider.Add(name, number);
            var list = provider.GetContacts();
            var result = list.Where(x => x.Name == name && x.Number == number).First();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUpdateContact()
        {
            var name = "Елена";
            var number = "+7(950) 424 12 45";
            var newNumber = "+7(950) 424 12 47";
            provider.Add(name, number);
            var contact = provider.GetContactByName(name);
            Assert.IsNotNull(contact);
            contact.Number = newNumber;
            provider.Update(contact);
            Assert.IsTrue(contact.Equals(provider.GetContactByName(name)));
        }

        [TestMethod]
        public void TestDeleteContact()
        {
            var name = "Аркадий";
            var number = "+7(930) 424 12 45";
            provider.Add(name, number);
            var contact = provider.GetContactByName(name);
            Assert.IsNotNull(contact);
            provider.Delete(contact.Id);
            var list = provider.GetContacts();
            var result = list.Where(x => x.Name == name && x.Number == number).ToList();
            var expected = 0;
            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void TestGetContacts()
        {
            provider.Clear();
            List<Contact> list = new List<Contact>
            {
                new Contact(1, "Александр", "+7(930) 424 12 45"),
                new Contact(2, "Ольга", "+7(950) 424 12 45"),
                new Contact(3, "Сергей", "+7(960) 124 12 45")
            };
            foreach (var item in list)
            {
                provider.Add(item.Name, item.Number);
            }
            var result = provider.GetContacts();
            Assert.AreEqual(list.Count, result.Count);
        }

        [TestMethod]
        public void TestGetContactByName()
        {
            var name = "Светлана";
            var number = "+7(930) 489 12 45";
            provider.Add(name, number);
            var contact = provider.GetContactByName(name);
            Assert.IsNotNull(contact);
        }

        [TestMethod]
        public void TestClear()
        {
            provider.Clear();
            var result = provider.GetContacts();
            var expected = 0;
            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void TestGetContactsByInitialLetters()
        {
            List<Contact> list = new List<Contact>
            {
                new Contact(1, "Александр", "+7(930) 424 12 45"),
                new Contact(2, "Ольга", "+7(950) 424 12 45"),
                new Contact(3, "Сергей", "+7(960) 124 12 45")
            };
            foreach (var item in list)
            {
                provider.Add(item.Name, item.Number);
            }
            var result = provider.GetContactsByInitialLetters("С");
            var expected = 1;
            Assert.AreEqual(expected, result.Count);
        }
    }
}
