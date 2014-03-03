namespace DocSystem
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Document : IDocument
    {
        protected const string KeyContent = "content";
        private const string KeyName = "name";

        public string Name { get; private set; }

        public string Content { get; protected set; }

        /// <summary>
        /// Loads instance properties
        /// </summary>
        /// <param name="key">Property of an instance.</param>
        /// <param name="value">Value to be assigned to that property.</param>
        public virtual void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyName:
                    this.Name = value;
                    break;
                case KeyContent:
                    this.Content = value;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Saves all instance properties in key/value pairs into an list.
        /// </summary>
        /// <param name="output">List where to store the instace properties as key/value pairs.</param>
        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Clear();
            output.Add(new KeyValuePair<string, object>(KeyName, this.Name));
            output.Add(new KeyValuePair<string, object>(KeyContent, this.Content));
        }

        public override string ToString()
        {
            var properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            properties.Sort((x, y) => string.Compare(x.Key, y.Key, System.StringComparison.Ordinal));
            var output = new StringBuilder(this.GetType().Name);
            output.Append("[");
            var rendered = (from pair in properties
                            where pair.Value != null
                            select string.Format("{0}={1}", pair.Key, pair.Value))
                            .ToList();

            output.Append(string.Join(";", rendered));
            output.Append("]");

            return output.ToString();
        }
    }
}