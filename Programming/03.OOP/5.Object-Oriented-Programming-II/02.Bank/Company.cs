namespace MyBank
{
    using System;

    public class Company : Customer
    {
        private string uniqueID;

        public string UniqueID
        {
            get
            {
                return this.uniqueID;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("No name provided!");
                }

                this.uniqueID = value;
            }
        }

        public Company(string name, string address, string uniqueID)
        {
            this.Name = name;
            this.Address = address;
            this.UniqueID = uniqueID;
        }
    }
}
