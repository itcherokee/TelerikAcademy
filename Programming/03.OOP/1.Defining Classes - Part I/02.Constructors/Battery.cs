// Define several constructors for the defined classes that take different sets of arguments
// (the full information for the class or part of it). Assume that model and manufacturer
// are mandatory (the others are optional). All unknown data fill with null.

namespace MobilePhone
{
    using System;

    public class Battery
    {
        // battery model
        public string Model { get; set; }

        // Battery hours idle
        public TimeSpan Idle { get; set; }

        // Battery hours talk
        public TimeSpan Talk { get; set; }

        public Battery() : this("Generic", TimeSpan.Zero, TimeSpan.Zero) 
        { 
        }

        public Battery(string model, TimeSpan idle, TimeSpan talk)
        {
            this.Model = model;
            this.Idle = idle;
            this.Talk = talk;
        }
    }
}