namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course : ICourse
    {
        private readonly IList<string> topics;
        private string name;

        protected Course(string name, ITeacher teacher = null)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            if (topic != null)
            {
                this.topics.Add(topic);
            }
            else
            {
                throw new ArgumentNullException("Topic cannot be null!");
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}:", this.GetType().Name);
            output.AppendFormat(" Name={0};", this.Name);
            if (this.Teacher != null)
            {
                output.AppendFormat(" Teacher={0};", this.Teacher.Name);
            }

            if (this.topics.Count > 0)
            {
                output.AppendFormat(" Topics=[{0}];", string.Join(", ", this.topics));
            }

            return output.ToString();
        }
    }
}