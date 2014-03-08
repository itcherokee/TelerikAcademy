using System;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value > 0.0m)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException(ErrorLessOrEqualToZero);
                }
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value > 0.0m)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException(ErrorLessOrEqualToZero);
                }
            }
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            output.AppendFormat(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
            return output.ToString();
        }
    }
}
