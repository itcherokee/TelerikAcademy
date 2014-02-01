namespace MyShape
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Shape
    {
        private double width;
        private double height;

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value >= 0.0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative values are not acceptable!");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value >= 0.0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative values are not acceptable!");
                }
            }
        }

        public abstract double CalculateSurface();
    }
}
