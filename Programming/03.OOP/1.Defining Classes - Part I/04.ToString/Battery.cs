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

        // battery enumeration type
        private BatteryType batType;

        // Property that exposes the batType field
        public BatteryType BatType
        {
            get { return this.batType; }
            set { this.batType = value; }
        }

        // battery model
        public string Model { get; set; }

        // Battery hours idle
        public TimeSpan Idle { get; set; }

        // Battery hours talk
        public TimeSpan Talk { get; set; }

        public Battery() : this("Generic", TimeSpan.Zero, TimeSpan.Zero, BatteryType.Unknown)
        {
        }

        public Battery(string model, TimeSpan idle, TimeSpan talk, BatteryType typeOfBattery)
        {
            this.Model = model;
            this.Idle = idle;
            this.Talk = talk;
            this.BatType = typeOfBattery;
        }
    }
}