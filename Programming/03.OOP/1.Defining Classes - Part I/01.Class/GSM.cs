using System;

// Define several constructors for the defined classes that take different sets of arguments
// (the full information for the class or part of it). Assume that model and manufacturer
// are mandatory (the others are optional). All unknown data fill with null.

namespace MobilePhone
{
    internal class GSM
    {
        // mobile model
        public string Model { get; set; }

        // mobile manufacturer
        public string Manufacturer { get; set; }

        // mobile price
        public decimal Price { get; set; }

        // owner of the mobile
        public string Owner { get; set; }

        // Property returns a new instance of Battery class
        public Battery GSMBattery
        {
            get { return new Battery(); }
        }

        // Property returns a new instance of the Display class
        public Display GSMDisplay
        {
            get { return new Display(); }
        }

    }
}