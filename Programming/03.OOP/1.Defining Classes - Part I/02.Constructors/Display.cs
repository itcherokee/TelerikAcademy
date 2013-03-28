// Define several constructors for the defined classes that take different sets of arguments
// (the full information for the class or part of it). Assume that model and manufacturer
// are mandatory (the others are optional). All unknown data fill with null.

namespace MobilePhone
{
    using System;

    public class Display
    {
        // property holding size of the screen in inches
        public double Size { get; set; }

        // number of display colors
        public int Colors { get; set; }

        public Display() : this(0, 0) 
        {
        }

        public Display(double size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
    }
}
