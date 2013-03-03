// Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. Ensure all fields hold correct data at any given time.

namespace MobilePhone
{
    using System;

    internal class Battery
    {
        internal enum BatteryType
        {
            Unknown,
            LiIon,
            LiPolymer,
            NiMH,
            NiCd
        }

        // fields declaration
        private BatteryType batType;
        private string model;
        private TimeSpan idle;
        private TimeSpan talk;

        // Property that exposes the batType field
        public BatteryType BatType
        {
            get 
            {
                return this.batType; 
            }

            set
            {
                switch (value)
                {
                    case BatteryType.LiIon:
                    case BatteryType.LiPolymer:
                    case BatteryType.NiCd:
                    case BatteryType.NiMH:
                    case BatteryType.Unknown:
                        this.batType = value;
                        break;
                    default:
                        this.batType = BatteryType.Unknown;
                        throw new ArgumentOutOfRangeException("Uncorrect value for Battery type has been provided!");
                }
            }
        }

        // battery model
        public string Model
        {
            get 
            { 
                return this.model; 
            }

            set
            {
                // checking for wrong value type
                if (!(value is string))
                {
                    this.model = "Unknown";
                    throw new ArgumentOutOfRangeException("Wrong value type provided!");
                }

                this.model = value;
            }
        }

        // Battery hours idle
        public TimeSpan Idle
        {
            get
            {
                return this.idle;
            }

            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("Idle time can not be negative!");
                }

                this.idle = value;
            }
        }

        // Propertie managing Battery time spent for talks
        public TimeSpan Talk
        {
            get
            {
                return this.talk;
            }

            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("Talk time can not be negative!");
                }

                this.talk = value;
            }
        }

        // parameterless constructor chains the constructor with full formal parameters list with default values
        public Battery()
            : this("Generic", TimeSpan.Zero, TimeSpan.Zero, BatteryType.Unknown)
        {
        }

        // Full formal parameters constructor, all fields are mandatory if used
        public Battery(string model, TimeSpan idle, TimeSpan talk, BatteryType typeOfBattery)
        {
            this.Model = model;
            this.Idle = idle;
            this.Talk = talk;
            this.BatType = typeOfBattery;
        }
    }
}