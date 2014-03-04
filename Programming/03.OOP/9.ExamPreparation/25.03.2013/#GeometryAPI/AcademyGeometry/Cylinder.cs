using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryAPI
{
    public class Cylinder : Figure, IVolumeMeasurable, IAreaMeasurable
    {
        private readonly double radius;

        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(bottom, top)
        {
            this.radius = radius;
        }

        private Vector3D Bottom
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

        private Vector3D Top
        {
            get
            {
                return this.vertices[1];
            }

            set
            {
                this.vertices[1] = value;
            }
        }

        private double Height
        {
            get
            {
                return new LineSegment(this.Bottom, this.Top).GetLength();
            }
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }


        public double GetVolume()
        {
            return this.GetBasementsArea() * Height;
        }

        public double GetArea()
        {
            var circleArea = this.GetBasementsArea() * 2;
            var sideArea = (2 * Math.PI * this.radius) * this.Height;
            return circleArea + sideArea;
        }

        private double GetBasementsArea()
        {
            return Math.Pow(this.radius, 2) * Math.PI;
        }
    }
}
