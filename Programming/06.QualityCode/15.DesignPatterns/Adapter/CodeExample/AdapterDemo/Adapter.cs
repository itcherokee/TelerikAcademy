﻿namespace AdapterPattern
{
    using System;

    public class Adapter : Target
    {
        private readonly Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work 
            // and then call SpecificRequest 
            this.adaptee.SpecificRequest();
        }
    }
}
