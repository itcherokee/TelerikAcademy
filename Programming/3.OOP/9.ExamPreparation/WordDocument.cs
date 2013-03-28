using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        public int NumberOfChars { get; set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "chars":
                    this.NumberOfChars = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfChars));
        }
    }
}
