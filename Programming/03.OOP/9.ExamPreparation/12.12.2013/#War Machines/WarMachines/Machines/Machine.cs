namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Targets = new List<string>();
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null!");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        /// <summary>
        /// Adds machine to the list of attacked ones.
        /// </summary>
        /// <param name="target">Name of the machine to be attacked.</param>
        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        /// <summary>
        /// Converts the value of this instance to a System.String.
        /// </summary>
        /// <returns>Instance as a string representation.</returns>
        public override string ToString()
        {
            var report = new StringBuilder();
            report.Append(string.Format("- {0}\n", this.Name));
            report.AppendFormat(" *Type: {0}\n", this.GetType().Name);
            report.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            report.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            report.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            report.AppendFormat(" *Targets: {0}\n", this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets));
            return report.ToString();
        }
    }
}