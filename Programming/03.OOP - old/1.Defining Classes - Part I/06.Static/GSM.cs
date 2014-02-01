// Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.

namespace MobilePhone
{
    using System;
    using System.Text;

    internal class GSM
    {
        // fields declarations
        private static readonly GSM iPhone4S =
            new GSM("IPhone 4S", "Apple", 1000, "Nobody", new Battery("Unknown", new TimeSpan(300, 0, 0), new TimeSpan(7, 0, 0), Battery.BatteryType.LiIon), new Display(3.5, 16777216));
        
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery gsmBattery;
        private Display gsmDisplay;

        // Static Property for managing the IPhone concrete implementation by the GSM class
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        // mobile model
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        // mobile manufacturer
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                this.manufacturer = value;
            }
        }

        // mobile price
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0.0M)
                {
                    throw new ArgumentOutOfRangeException("Price can not be negative!");
                }

                this.price = value;
            }
        }

        // owner of the mobile
        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        // Parameterless constructor calls (chaining) the constructor with full formal parameter list
        public GSM()
            : this("Generic", "Unknown")
        {
        }

        // Full formal parameter constructor that requires only model & manufacturer fields as mandatory, the rest are optional (default values)
        public GSM(string model, string manufacturer, decimal price = 0.0M, string owner = "", Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.gsmBattery = battery ?? new Battery();
            this.gsmDisplay = display ?? new Display();
        }

        // Overiding ToString method in order to "print" whole information of the GSM class fileds(properties)
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Model: " + this.Model);
            output.Append("\nManufacturer: " + this.Manufacturer);
            output.Append(string.Format("\nPrice: {0:C}\n", this.Price));
            output.Append("Owner: " + this.Owner);
            output.Append("\nBattery Model: " + this.gsmBattery.Model);
            output.Append(string.Format("\nBattery Idle Time: {0:F2}\n", this.gsmBattery.Idle.ToString()));
            output.Append(string.Format("Battery Talk Time: {0:F2}\n", this.gsmBattery.Talk.ToString()));
            output.Append("Battery Type: " + this.gsmBattery.BatType);
            output.Append(string.Format("\nDisplay Size: {0:F2}\n", this.gsmDisplay.Size));
            output.Append(string.Format("Display Colors: {0:N}", this.gsmDisplay.Colors));

            // return is calling the base (object) ToString method to print the content of the StringBuilder value output
            return output.ToString();
        }
    }
}