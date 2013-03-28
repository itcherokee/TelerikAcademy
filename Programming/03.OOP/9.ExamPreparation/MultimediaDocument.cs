using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class MultimediaDocument : BinaryDocument
    {
        public TimeSpan Length { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "lenght":
                    this.Length = TimeSpan.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }
}
