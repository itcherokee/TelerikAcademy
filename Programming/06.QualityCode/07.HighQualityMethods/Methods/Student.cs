// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Methods
{
    using System;

    /// <summary>
    /// Represents an student with its properties
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">Student first name.</param>
        /// <param name="lastName">Student last name.</param>
        /// <param name="otherInfo">Student other information.</param>
        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        /// <summary>
        /// Gets or sets first name of the student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets additional info about the student (last 10 chars represent birth date).
        /// </summary>
        public string OtherInfo { get; set; }

        /// <summary>
        /// Finds out does current student is older then referenced one.
        /// </summary>
        /// <param name="other">Other referenced student.</param>
        /// <returns>True if current student is older else false.</returns>
        public bool IsOlderThan(Student other)
        {
            DateTime firstDate;
            DateTime secondDate;
            if (DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out firstDate))
            {
                if (DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out secondDate))
                {
                    return firstDate < secondDate;
                }
                else
                {
                    throw new ArgumentException("Missing or incorrect date in referenced student.");
                }
            }
            else
            {
                throw new ArgumentException("Missing or incorrect date in current student.");
            }
        }
    }
}
