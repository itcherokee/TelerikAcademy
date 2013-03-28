namespace MobilePhone
{
    using System;

    public class Display
    {
        private double size;
        private int colors;

        // property holding size of the screen in inches
        public double Size
        {
            get
            {
                return this.size; 
            }

            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("Size of the display can not be negative!");
                }

                this.size = value;
            }
        }

        // number of display colors
        public int Colors
        {
            get 
            {
                return this.colors; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Display colors can not be negative!");
                }

                this.colors = value;
            }
        }

        public Display()
            : this(0.0, 0)
        {
        }

        public Display(double size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
    }
}
