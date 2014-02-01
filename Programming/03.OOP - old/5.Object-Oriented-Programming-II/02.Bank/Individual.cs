namespace MyBank
{
    using System;

    public class Individual : Customer
    {
        public Individual(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}
