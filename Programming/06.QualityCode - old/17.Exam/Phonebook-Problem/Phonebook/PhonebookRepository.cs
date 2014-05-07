namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly List<Record> phonebook = new List<Record>();

        /// <summary>
        /// Adds a new entry to the phone book. The entry consist of person name and phone number(s).
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <param name="phoneNums">A list of phone numbers attached to the <paramref name="name"/></param>
        /// <remarks>If the record already exists a merge operation is performed if 
        /// the new phone numbers provided are non-repeating.</remarks>
        /// <returns>Retirns true if the entry was not existing in the phone book or false if the merge operation took place.</returns>
        public bool AddPhone(string name, IEnumerable<string> phoneNums)
        {
            bool isEmptyName = name == "";
            bool isEmptyPhoneList = phoneNums.Count() == 0;
            bool isNullName = name == null;
            bool isNullPhoneList = phoneNums == null;

            if (!isEmptyName && !isEmptyPhoneList && !isNullName && !isNullPhoneList)
            {
                List<string> phoneNumbers = (List<string>)phoneNums;
                for (int index = 0; index < phoneNumbers.Count(); index++)
                {
                    phoneNumbers[index] = this.ConvertToCanonicalForm(phoneNumbers[index]);
                }

                var personRecords = from personRecord in this.phonebook
                                    where personRecord.Name.ToLowerInvariant() == name.ToLowerInvariant()
                                    select personRecord;

                if (personRecords.Count() == 0)
                {
                    Record phonebookRecord = new Record();
                    phonebookRecord.Name = name;
                    phonebookRecord.PhoneNumbers = new SortedSet<string>();
                    this.AttachPhoneNumbersToRecord(phoneNumbers, phonebookRecord);
                    this.phonebook.Add(phonebookRecord);
                    return true;
                }
                else if (personRecords.Count() == 1)
                {
                    Record phonebookRecord = personRecords.First();
                    this.AttachPhoneNumbersToRecord(phoneNumbers, phonebookRecord);
                    return false;
                }
                else
                {
                    throw new ArgumentException("Duplicated name in the phonebook found: " + name);
                }
            }
            else
            {
                throw new ArgumentNullException("Phone numbers list can not be empty or null.");
            }
        }

        /// <summary>
        /// Changes the specified old phone number in all phonebook entries with a new one. 
        /// Changing a phone number works with merging and thus any duplicating phone numbers are omitted.
        /// </summary>
        /// <param name="oldPhoneNumber">Phone number to be searched within the phone book to be replaced.</param>
        /// <param name="newPhoneNumber">New phone number to replace all founded numbers that match <paramref name="oldPhoneNumber"/> parameter.</param>
        /// <returns>Returns the number of performed changes within the whole phone book.</returns>
        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            if (oldPhoneNumber == "" || newPhoneNumber == "")
            {
                throw new ArgumentException("Old phone number and/or new phone number can not be empty.");
            }

            if (oldPhoneNumber == null || newPhoneNumber == null)
            {
                throw new ArgumentNullException("Old phone number and/or new phone number ca not be Null.");
            }

            string oldNumber = this.ConvertToCanonicalForm(oldPhoneNumber);
            string newNumber = this.ConvertToCanonicalForm(newPhoneNumber);

            var phoneNumbers = from phoneNumber in this.phonebook
                               where phoneNumber.PhoneNumbers.Contains(oldNumber)
                               select phoneNumber;

            int count = 0;
            foreach (var phoneNumber in phoneNumbers)
            {
                phoneNumber.PhoneNumbers.Remove(oldNumber);
                phoneNumber.PhoneNumbers.Add(newNumber);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Lists the phone book entries with paging with alphabeticaly sort on phone numbers.
        /// </summary>
        /// <param name="startIndex">This is the start index from where to start 
        /// the listing of the records in the phone book.</param>
        /// <param name="count">This is the size of the page - the number of 
        /// the phone book entries to be retrieved.</param>
        /// <returns>Returns an array of <see cref="Record"/> records holding the list 
        /// with all requested entries from the phone book.</returns>
        public Record[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.phonebook.Count || count < 0)
            {
                return null;
            }

            this.phonebook.Sort();
            Record[] phoneBookRecords = new Record[count];
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                Record record = this.phonebook[i];
                phoneBookRecords[i - startIndex] = record;
            }

            return phoneBookRecords;
        }

        private void AttachPhoneNumbersToRecord(IEnumerable<string> phoneNumbers, Record record)
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                record.PhoneNumbers.Add(phoneNumber);
            }
        }

        private string ConvertToCanonicalForm(string phoneNumber)
        {
            const string Code = "+359";

            StringBuilder output = new StringBuilder();
            for (int index = 0; index <= output.Length; index++)
            {
                output.Clear();
                foreach (char character in phoneNumber)
                {
                    if (char.IsDigit(character) || (character == '+'))
                    {
                        output.Append(character);
                    }
                }

                if (output.Length >= 2 && output[0] == '0' && output[1] == '0')
                {
                    output.Remove(0, 1);
                    output[0] = '+';
                }

                while (output.Length > 0 && output[0] == '0')
                {
                    output.Remove(0, 1);
                }

                if (output.Length > 0 && output[0] != '+')
                {
                    output.Insert(0, Code);
                }
            }

            return output.ToString();
        }
    }
}
