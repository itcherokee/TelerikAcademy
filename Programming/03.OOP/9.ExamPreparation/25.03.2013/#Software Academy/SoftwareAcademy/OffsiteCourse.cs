﻿namespace SoftwareAcademy
{
    using System;
    using System.Text;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town cannot be null!");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            output.AppendFormat(" Town={0}", this.Town);
            return output.ToString();
        }
    }
}