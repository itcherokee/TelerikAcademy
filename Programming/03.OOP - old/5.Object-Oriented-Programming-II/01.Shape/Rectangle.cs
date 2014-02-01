namespace MyShape
{
    using System;

    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
