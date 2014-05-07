namespace PhonebookTest
{
    using Phonebook;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    // AddPhone Tests

    [TestClass()]
    public class PhonebookRepositoryTest
    {

        [TestMethod()]
        public void AddPhoneEntryAddedTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("+359111222333");
            bool actual = target.AddPhone("Ema", phones);
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void AddPhoneNewPhoneNumberTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("+359111222333");
            target.AddPhone("Ema", phones);
            phones.Add("+359111222334");
            bool actual = target.AddPhone("Ema", phones);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void AddPhoneSamePhoneNumberTwiceTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("+359111222333");
            target.AddPhone("Ema", phones);
            phones.Add("+359111222333");
            bool actual = target.AddPhone("Ema", phones);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPhoneNullNameTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("+359111222333");
            target.AddPhone(null, phones);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPhoneNullPhoneListTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            target.AddPhone("Ema", null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPhoneEmptyNameTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("+359111222333");
            target.AddPhone("", phones);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPhoneEmptyPhoneListTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            target.AddPhone("Ema", phones);
        }

        // ChangePhone Tests

        [TestMethod()]
        public void ChangePhoneTrivialTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("+359111222333");
            phones.Add("311222");
            target.AddPhone("Ema", phones);
            string oldPhoneNumber = "+359111222333";
            string newPhoneNumber = "9999999999";
            int actual= target.ChangePhone(oldPhoneNumber, newPhoneNumber);
            Assert.AreEqual(1, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangePhoneNullOldPhoneTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            string oldPhoneNumber = "+359111222333";
            phones.Add(oldPhoneNumber);
            target.AddPhone("Ema", phones);
            string newPhoneNumber = "9999999999";
            target.ChangePhone(null, newPhoneNumber);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangePhoneNullNewPhoneTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            string oldPhoneNumber = "+359111222333";
            phones.Add(oldPhoneNumber);
            target.AddPhone("Ema", phones);
            target.ChangePhone(oldPhoneNumber, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneEmptyOldPhoneTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            string oldPhoneNumber = "+359111222333";
            phones.Add(oldPhoneNumber);
            target.AddPhone("Ema", phones);
            string newPhoneNumber = "9999999999";
            target.ChangePhone("", newPhoneNumber);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneEmptyNewPhoneTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            string oldPhoneNumber = "+359111222333";
            phones.Add(oldPhoneNumber);
            target.AddPhone("Ema", phones);
            target.ChangePhone(oldPhoneNumber, "");
        }

        [TestMethod()]
        public void ChangePhoneNotExistingTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("+359111222333");
            phones.Add("00311222");
            target.AddPhone("Ema", phones);
            string oldPhoneNumber = "+3591112223334";
            string newPhoneNumber = "9999999999";
            int actual = target.ChangePhone(oldPhoneNumber, newPhoneNumber);
            Assert.AreEqual(0, actual);
        }

        // ListEntries Tests

        [TestMethod()]
        public void ListEntriesTrivialTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("111222333");
            target.AddPhone("Alpha", phones);
            phones.Clear();
            phones.Add("+359444555666");
            target.AddPhone("Beta", phones);
            Record[] actual = target.ListEntries(0,2);
            Assert.AreEqual(2, actual.Length);
        }

        [TestMethod()]
        public void ListEntriesInvalidStartIndexTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("111222333");
            target.AddPhone("Alpha", phones);
            phones.Clear();
            phones.Add("+359444555666");
            target.AddPhone("Beta", phones);
            Record[] actual = target.ListEntries(10, 2);
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void ListEntriesNegativeCountTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("111222333");
            target.AddPhone("Alpha", phones);
            phones.Clear();
            phones.Add("+359444555666");
            target.AddPhone("Beta", phones);
            Record[] actual = target.ListEntries(0, -3);
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void ListEntriesZeroParameterersTest()
        {
            PhonebookRepository target = new PhonebookRepository();
            List<string> phones = new List<string>();
            phones.Add("111222333");
            target.AddPhone("Alpha", phones);
            phones.Clear();
            phones.Add("+359444555666");
            target.AddPhone("Beta", phones);
            Record[] actual = target.ListEntries(0, 0);
            Assert.AreEqual(0, actual.Length);
        }
    }
}
