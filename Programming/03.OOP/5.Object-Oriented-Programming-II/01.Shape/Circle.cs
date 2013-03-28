namespace MyShape
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Width = this.Height = radius;
        }

        public override double CalculateSurface()
        {
            return Math.PI * (this.Width * this.Width);
        }
    }
}
