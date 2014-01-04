namespace TriangleMath
{
    using System;

    public class Triangle
    {
        private readonly bool noSideBSideCAngle;
        private double sideA;
        private double sideB;
        private double sideC;
        private double altitudeSideA;
        private float angleSideASideB;

        public Triangle(double sideA, double sideB, double sideC)
            : this(sideA)
        {
            this.SideB = sideB;
            this.SideC = sideC;
            this.AltitudeSideA = this.CalculateAltitudeSideAByThreeSides();
            this.AngleSideASideB = (float)this.CalculateAngleSideBSideC();
        }

        public Triangle(double sideA, double altitudeSideA, bool noSideBAndSideCAndAngle)
            : this(sideA, noSideBAndSideCAndAngle)
        {
            // could not find a math algorythm to calculate other two sides, that is way put 
            // a constraint of using them when used this constructor
            this.AltitudeSideA = altitudeSideA;
        }

        public Triangle(double sideA, double sideB, float angleSiseASideB)
            : this(sideA)
        {
            this.SideB = sideB;
            this.SideC = this.CalculateSideC();
            this.AngleSideASideB = angleSiseASideB;
            this.AltitudeSideA = this.CalculateAltitudeSideABySideAndAngle();
        }

        private Triangle(double sideA, bool noSideBAndSideCAndAngle = false)
        {
            this.sideA = sideA;
            this.noSideBSideCAngle = noSideBAndSideCAndAngle;
        }

        public double SideA
        {
            get
            {
                return this.sideA;
            }

            set
            {
                if (value > 0.0000000000000001)
                {
                    this.sideA = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for side A provided. Must be greater than 0");
                }
            }
        }

        public double SideB
        {
            get
            {
                if (this.noSideBSideCAngle)
                {
                    throw new ArgumentException("Not defined property in current instance! Use another constructor");
                }

                return this.sideB;
            }

            set
            {
                if (value > 0.0000000000000001)
                {
                    this.sideB = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for side B provided. Must be greater than 0");
                }
            }
        }

        public double SideC
        {
            get
            {
                if (this.noSideBSideCAngle)
                {
                    throw new ArgumentException("Not defined property in current instance! Use another constructor");
                }

                return this.sideC;
            }

            set
            {
                if (value > 0.0000000000000001)
                {
                    this.sideC = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for side C provided. Must be greater than 0");
                }
            }
        }

        public double AltitudeSideA
        {
            get
            {
                return this.altitudeSideA;
            }

            set
            {
                if (value > 0.0000000000000001)
                {
                    this.altitudeSideA = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for side C provided. Must be greater than 0");
                }
            }
        }

        public float AngleSideASideB
        {
            get
            {
                if (this.noSideBSideCAngle)
                {
                    throw new ArgumentException("Not defined property in current instance! Use another constructor");
                }

                return this.angleSideASideB;
            }

            set
            {
                if (value > 0.0000000000000001)
                {
                    this.angleSideASideB = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value for side C provided. Must be greater than 0");
                }
            }
        }

        // Calculates Semiparameter of the triangle
        private double SemiPerimeter
        {
            get
            {
                if (this.SideA > 0 && this.SideB > 0 && this.SideC > 0)
                {
                    return (this.SideA + this.SideB + this.SideC) / 2;
                }
                else
                {
                    throw new ArgumentException("Missing values for one or more of the three sides of triangle!");
                }
            }
        }

        // Calculates Area based on single side and the altitude to it
        public double AreaSideAltitude()
        {
            return this.SideA * this.AltitudeSideA / 2;
        }

        // Calculates Area based on three sides
        public double AreaThreeSides()
        {
            if (this.noSideBSideCAngle)
            {
                throw new ArgumentException("Not defined property in current instance! Use another constructor");
            }

            var semiPerim = this.SemiPerimeter;
            return Math.Sqrt(semiPerim * (semiPerim - this.SideA) * (semiPerim - this.SideB) * (semiPerim - this.SideC));
        }

        // Calculates Area based on two sides and angle between them
        public double AreaSideAngleSide()
        {
            if (this.noSideBSideCAngle)
            {
                throw new ArgumentException("Not defined property in current instance! Use another constructor");
            }

            // for sin function, value must be converted from degrees to radians
            return (this.SideA * this.SideB) / 2 * Math.Sin(Math.PI * this.AngleSideASideB / 180);
        }

        private double CalculateAltitudeSideAByThreeSides()
        {
            double semiParam = this.SemiPerimeter;
            return (2 * Math.Sqrt(semiParam * (semiParam - this.SideA) * (semiParam - this.SideB) * (semiParam - this.SideC))) / this.SideA;
        }

        private double CalculateAltitudeSideABySideAndAngle()
        {
            return this.SideB * Math.Sin(this.AngleSideASideB * Math.PI / 180);
        }

        private double CalculateAngleSideBSideC()
        {
            double cosine = (((this.SideB * this.SideB) + (this.SideC * this.SideC)) - (this.SideA * this.SideA)) / (this.SideB * this.SideC * 2);
            return Math.Acos(cosine) * 180 / Math.PI;
        }

        private double CalculateSideC()
        {
            return Math.Sqrt(((this.SideA * this.SideA) + (this.SideB * this.SideB)) - ((2 * this.SideA * this.SideB) * Math.Cos((this.AngleSideASideB * Math.PI) / 180)));
        }
    }
}