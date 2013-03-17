using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Players
    {
        private List<Person> players;

        public Players()
        {
            players = new List<Person>();
        }

        public void Add(Person player)
        {
            this.players.Add(player);
        }

        public void Remove(Person player)
        {
            this.players.Remove(player);
        }

        // total number of clients

        // total number of library employees

        // 

    
    }
}
