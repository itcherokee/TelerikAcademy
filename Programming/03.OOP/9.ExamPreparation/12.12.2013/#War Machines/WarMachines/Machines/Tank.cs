namespace WarMachines.Machines
{
    using System.Text;
    using Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100d;
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        /// <summary>
        /// Gets or sets (throught constructor) the defense mode of a tank.
        /// </summary>
        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }

            private set
            {
                if (value)
                {
                    this.DefensePoints += 30;
                    this.AttackPoints -= 40;
                }
                else
                {
                    this.DefensePoints -= 30;
                    this.AttackPoints += 40;
                }

                this.defenseMode = value;
            }
        }

        /// <summary>
        /// Togles (on/off) the defence mode of a tank.
        /// </summary>
        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
        }

        /// <summary>
        /// Converts the value of this instance to a System.String.
        /// </summary>
        /// <returns>Instance as a string representation.</returns>
        public override string ToString()
        {
            var report = new StringBuilder(base.ToString());
            report.AppendFormat(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF");
            return report.ToString();
        }
    }
}