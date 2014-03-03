namespace WarMachines.Machines
{
    using System.Text;
    using Interfaces;

    internal class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoints = 200d;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.StealthMode = stealthMode;
        }

        /// <summary>
        /// Gets or sets the stealth mode of a fighter.
        /// </summary>
        public bool StealthMode { get; private set; }

        /// <summary>
        /// Togles (on/off) the stealth mode of a fighter.
        /// </summary>
        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        /// <summary>
        /// Converts the value of this instance to a System.String.
        /// </summary>
        /// <returns>Instance as a string representation.</returns>
        public override string ToString()
        {
            var report = new StringBuilder(base.ToString());
            report.AppendFormat(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF");
            return report.ToString();
        }
    }
}