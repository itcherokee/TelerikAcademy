// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
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
        /// <param name="firstName">Student's first name.</param>
        /// <param name="lastName">Student's last name.</param>
        /// <param name="birthday">Student's birthday.</param>
        /// <param name="notes">Additional notes for student.</param>
        public Student(string firstName, string lastName, DateTime? birthday = null, string notes = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AdditionalInfo = new PersonalInfo(birthday, notes);
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
        /// Gets or sets additional information about the student (birthday and additional notes).
        /// </summary>
        public PersonalInfo AdditionalInfo { get; set; }

        /// <summary>
        /// Finds out does current student is older then referenced one.
        /// </summary>
        /// <param name="otherStudent">Other referenced student.</param>
        /// <exception cref="ArgumentNullException">Thrown when null object provided to be compared or when one or both Student object have no valid birthday.</exception>
        /// <returns>True if current student is older else false.</returns>
        public bool IsOlderThan(Student otherStudent)
        {
            if (otherStudent != null)
            {
                if (this.AdditionalInfo.Birthdate != null && otherStudent.AdditionalInfo.Birthdate != null)
                {
                    return this.AdditionalInfo.Birthdate < otherStudent.AdditionalInfo.Birthdate;
                }

                throw new ArgumentNullException("One or both of the Students, have no birthday setup. Comparison is not possible!");
            }

            throw new ArgumentNullException("Not a valid object provided to compare birthdays!");
        }
    }
}
