namespace MyShape
{
    using System;

    public class Triangle : Shape
    {
        public Triangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateSurface()
        {
            return (this.Height * this.Width) / 2;
        }
    }
}
