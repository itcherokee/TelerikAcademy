// Define several constructors for the defined classes that take different sets of arguments
// (the full information for the class or part of it). Assume that model and manufacturer
// are mandatory (the others are optional). All unknown data fill with null.

namespace MobilePhone
{
    using System;

    internal class GSM
    {
        // field holding reference to Battery
        private Battery gsmBattery;

        // field holding reference to Display
        private Display gsmDisplay;

        // mobile model
        public string Model { get; set; }

        // mobile manufacturer
        public string Manufacturer { get; set; }

        // mobile price
        public decimal Price { get; set; }

        // owner of the mobile
        public string Owner { get; set; }

        public GSM() : this("Generic", "Unknown")
        {
        }

        public GSM(string model, string manufacturer, decimal price = 0.0M, string owner = "", Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.gsmBattery = battery ?? new Battery();
            this.gsmDisplay = display ?? new Display();
        }
    }
}