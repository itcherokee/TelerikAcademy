using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "rows":
                    this.NumberOfRows = int.Parse(value);
                    break;
                case "cols":
                    this.NumberOfColumns = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
        }
    }
}
