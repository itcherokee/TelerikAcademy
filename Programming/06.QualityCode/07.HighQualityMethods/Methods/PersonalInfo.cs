// ********************************
// <copyright file="PersonalInfo.cs" company="SoftUni Academy">
// Copyright (c) 2014 SoftUni. All rights reserved.
// </copyright>
//
// ********************************
namespace Methods
{
    using System;

    /// <summary>
    /// Represents an additional information, which can be attached to an object,
    /// representing living creature (usually human).
    /// </summary>
    internal class PersonalInfo
    {
        /// <summary>
        /// Holds additional text information (notes).
        /// </summary>
        private string notes;

        /// <summary>
        /// Holds birthday.
        /// </summary>
        private DateTime? birthday;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalInfo"/> class.
        /// </summary>
        /// <param name="birthday">Birthday date.</param>
        /// <param name="notes">Some notes.</param>
        public PersonalInfo(DateTime? birthday = null, string notes = default(string))
        {
            this.birthday = birthday;
            this.notes = notes;
        }

        /// <summary>
        /// Gets or sets notes.
        /// </summary>
        public string Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Notes cannot be null.");
                }

                this.notes = value;
            }
        }

        /// <summary>
        /// Gets or sets birthday.
        /// </summary>
        public DateTime? Birthdate
        {
            get
            {
                return this.birthday;
            }

            set
            {
                if (value <= DateTime.Today || value == null)
                {
                    this.birthday = value;
                }
                else
                {
                    throw new ArgumentException("Birthday must be set appropriately and could not be later than current moment!");
                }
            }
        }
    }
}
