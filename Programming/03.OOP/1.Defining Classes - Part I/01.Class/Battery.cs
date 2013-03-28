using System;

// battery characteristics (model, hours idle and hours talk)

namespace MobilePhone
{

    internal class Battery
    {
        // battery model
        public string Model { get; set; }

        // Battery hours idle
        public TimeSpan Idle { get; set; }

        // Battery hours talk
        public TimeSpan Talk { get; set; }
    }
}