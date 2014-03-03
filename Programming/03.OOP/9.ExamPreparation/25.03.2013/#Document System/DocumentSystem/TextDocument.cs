namespace DocSystem
{
    using System.Collections.Generic;

    public class TextDocument : Document, IEditable
    {
        private const string KeyCharset = "charset";

        /// <summary>
        /// Gets or sets charset used in text document.
        /// </summary>
        public string CharSet { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyCharset:
                    this.CharSet = value;
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeyCharset, this.CharSet));
        }

        public void ChangeContent(string newContent)
        {
            this.LoadProperty(KeyContent, newContent);
        }
    }
}