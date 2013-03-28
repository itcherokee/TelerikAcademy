using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicLibrary
{
    public delegate void UserChangeEventHandler(IEnumerable<Person> list);

    public class Users : IEnumerable
    {
        /// <summary>
        /// Class defining a storage (list) and operations over it for all objects of type Person (clients, workers, administrators)
        /// </summary>

        #region Event declaration to be fired when there is a change in the list of Users

        

        public event UserChangeEventHandler RecordUserHasBeenChanged;

        // fires the event in case of records change
        protected virtual void OnChange()
        {
            if (RecordUserHasBeenChanged != null)
            {
                RecordUserHasBeenChanged(users);
            }
        }

        #endregion

        private List<Person> users;

        public Users()
        {
            users = new List<Person>();
        }

        // LINQ statement to search for an Client or Employee by it's ID. Used to obey duplicates in the list.
        private IEnumerable<Person> Search(Person player)
        {
            var query = from user in users
                        where user.PersonalID == player.PersonalID
                        select user;
            return query;
        }

        // Adds a Client or Employee to the list
        public void Add(Person player)
        {
            if (!Search(player).Any())
            {
                this.users.Add(player);
                OnChange();
            }
            else
            {
                throw new LibraryException.UserExistException("User already exist in the system!");
            }

        }

        // Removes a Client or Employee from the list
        public void Remove(Person player)
        {
            if (this.users.Exists((x) => x.Equals(player)))
            {
                this.users.Remove(player);
                OnChange();

            }
            else
            {
                string message = string.Empty;
                if (player.GetType().Name.Equals(typeof(Client)))
                {
                    message = "There is no such client in the system!";
                }
                else if (player.GetType().Name.Equals(typeof(Librarian)))
                {
                    message = "There is no such Library employee in the system!";
                }
                throw new LibraryException.NonExistingUserException(message);
            }
        }

        public IEnumerable<Person> SearchByPersonalID(string personalID)
        {
            var query = from user in users
                        where user.PersonalID == personalID
                        select user;
            return query;
        }

        // Counts Clients or Employees
        public int CountByPersonType(PersonTypes personType)
        {
            return users.Count((x) => x.PersonType == personType);
        }

        // Convert User object to List<Person> list
        public List<Person> GetUsers()
        {
            return users.ToList();
        }

        public IEnumerator GetEnumerator()
        {
            return (this.users as IEnumerable<Person>).GetEnumerator();
        }
    }
}
