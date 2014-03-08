using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private readonly decimal normalStateHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.normalStateHeight = height;
            this.IsConverted = false;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }

            set
            {
                if (value)
                {
                    this.Height = 0.10m;
                    this.isConverted = true;
                }
                else
                {
                    this.Height = this.normalStateHeight;
                    this.isConverted = false;
                }
            }
        }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            output.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");
            return output.ToString();
        }
    }
}