using System;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        protected const string ErrorLessOrEqualToZero = "Value cannot be less or equal to zero!";
        private readonly MaterialType materialtype;
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.materialtype = materialType;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length >= 3)
                    {
                        this.model = value;
                    }
                    else
                    {
                        throw new ArgumentException("Model cannot be with less than 3 symbols!");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Model cannot be null, empty or only white spaces!");
                }
            }
        }

        public string Material
        {
            get
            {
                return this.materialtype.ToString();
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value > 0.0m)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException(ErrorLessOrEqualToZero);
                }
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value > 0.0m)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException(ErrorLessOrEqualToZero);
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name,
                this.Model, this.Material, this.Price, this.Height);
            return output.ToString();
        }
    }
}