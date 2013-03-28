using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        public ulong Size { get; set; }


        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "size":
                    this.Size = ulong.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }

    }
}
