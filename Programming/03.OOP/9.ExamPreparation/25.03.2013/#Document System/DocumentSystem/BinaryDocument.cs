namespace DocSystem
{
    using System.Collections.Generic;

    public abstract class BinaryDocument : Document
    {
        private const string KeySize = "size";

        /// <summary>
        /// Get and sets size of document in bytes.
        /// </summary>
        public int? Size { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeySize:
                    this.Size = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeySize, this.Size));
        }
    }
}