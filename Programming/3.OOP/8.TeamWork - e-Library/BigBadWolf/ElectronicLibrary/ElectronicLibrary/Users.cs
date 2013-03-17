using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicLibrary
{
    public class Users : IEnumerable
    {
        /// <summary>
        /// Class defining a storage (list) and operations over it for all objects of type Person (clients, workers, administrators)
        /// </summary>

        private List<Person> users;

        public Users()
        {
            users = new List<Person>();
            //TODO:  Load from file 
        }

        private IEnumerable<Person> Search(Person player)
        {
            var query = from user in users
                        where user.PersonalID == player.PersonalID
                        select user;
            return query;
        }

        public void Add(Person player)
        {
            if (!Search(player).Any())
            {
                this.users.Add(player);
                // TODO: OtputPersonAdd(player)
            }
            else
            {
                throw new LibraryException.UserExistException("User already exist in the system!");
            }

        }

        public void Remove(Person player)
        {
            if (this.users.Exists((x) => x.Equals(player)))
            {
                this.users.Remove(player);
                // TODO: OutputPerson();
            }
            else
            {
                string message = string.Empty;
                if (player.GetType().Name.Equals(typeof(Client)))
                {
                    message = "There is no such client in the system!";
                }
                else if (player.GetType().Name.Equals(typeof(LibrarianWorker)))
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

        public List<Person> Extract()
        {
            return this.users;
        }

        // total number of clients

        // total number of library employees

        // 


        public IEnumerator GetEnumerator()
        {
            return (this.users as IEnumerable<Person>).GetEnumerator();
        }
    }
}
