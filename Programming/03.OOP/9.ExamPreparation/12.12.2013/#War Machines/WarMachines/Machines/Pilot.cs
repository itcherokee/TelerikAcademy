namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Pilot : IPilot
    {
        private readonly List<IMachine> machinesEngaged;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machinesEngaged = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Add machines that the pilot will drive.
        /// </summary>
        /// <param name="machine">Machine that pilot will drive.</param>
        public void AddMachine(IMachine machine)
        {
            this.machinesEngaged.Add(machine);
        }

        /// <summary>
        /// Reports current status of the pilot.
        /// </summary>
        /// <returns>Pilot report in form of a System.String.</returns>
        public string Report()
        {
            var report = new StringBuilder();
            string numberOfMachines = string.Empty;
            switch (this.machinesEngaged.Count)
            {
                case 0:
                    numberOfMachines = "no machines";
                    break;
                case 1:
                    numberOfMachines = "1 machine\n";
                    break;
                default:
                    numberOfMachines = this.machinesEngaged.Count + " machines\n";
                    break;
            }

            this.machinesEngaged.Sort(this.MachinesComparison);
            report.AppendFormat("{0} - {1}", this.Name, numberOfMachines);
            for (int i = 0; i < this.machinesEngaged.Count; i++)
            {
                report.Append(this.machinesEngaged[i].ToString());
                if (i < this.machinesEngaged.Count - 1)
                {
                    report.AppendLine();
                }
            }

            return report.ToString();
        }

        /// <summary>
        /// Helper function for sorting the list of machines engaged by pilot 
        /// based on sort first by HealthPoints and than by machine's Name.
        /// </summary>
        /// <param name="first">First machine.</param>
        /// <param name="second">Second machine.</param>
        /// <returns>
        /// -1 if first machine is before second one; 
        /// 0 if both are equal;
        /// 1 if second machine is before first one.
        /// </returns>
        private int MachinesComparison(IMachine first, IMachine second)
        {
            if (first == null)
            {
                if (second == null)
                {
                    return 0;
                }

                return -1;
            }

            if (second == null)
            {
                return 1;
            }

            int health = first.HealthPoints.CompareTo(second.HealthPoints);
            if (health != 0)
            {
                return health;
            }

            return string.Compare(first.Name, second.Name, StringComparison.Ordinal);
        }
    }
}
