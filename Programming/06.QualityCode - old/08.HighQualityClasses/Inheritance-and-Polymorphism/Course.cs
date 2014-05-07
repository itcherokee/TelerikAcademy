// ********************************
// <copyright file="Course.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represent an abstract course object.
    /// </summary>
    public abstract class Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="teacherName">Course teacher.</param>
        /// <param name="students">Students enrolled in course.</param>
        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        /// <param name="teacherName">Course teacher.</param>
        protected Course(string name, string teacherName)
            : this(name, teacherName, new List<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">Course name.</param>
        protected Course(string name)
            : this(name, null, new List<string>())
        {
        }

        /// <summary>
        /// Gets or sets course name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets course teacher.
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// Gets or sets students enrolled in course.
        /// </summary>
        public IList<string> Students { get; set; }

        /// <summary>
        /// Convert <see cref="Course"/> properties to System.String.
        /// </summary>
        /// <returns>System.String representing <see cref="Course"/> properties.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(" { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

        /// <summary>
        /// Returns all students enrolled in the course.
        /// </summary>
        /// <returns>System.String representing all students enrolled in course.</returns>
        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
