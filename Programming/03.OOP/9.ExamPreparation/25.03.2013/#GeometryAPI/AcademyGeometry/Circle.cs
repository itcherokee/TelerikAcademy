using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryAPI
{
    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        private readonly double radius;

        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.radius = radius;
        }

        private Vector3D Center
        {
            get
            {
                return this.vertices[0];
            }

            set
            {
                this.vertices[0] = value;
            }
        }



        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }


        public double GetArea()
        {
            return Math.Pow(this.radius, 2) * Math.PI;
        }


        public Vector3D GetNormal()
        {
         //   Vector3D normal = Vector3D.CrossProduct(
       //         this.Center, new Vector3D(this.Center.X - this.radius, this.Center.Y - this.radius, 0));
            Vector3D normal = new Vector3D(0, 0, 1);
            normal.Normalize();
            return normal;
        }

    }
}
