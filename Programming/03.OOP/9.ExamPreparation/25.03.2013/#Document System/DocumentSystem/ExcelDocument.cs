namespace DocSystem
{
    using System.Collections.Generic;

    public class ExcelDocument : OfficeDocument
    {
        private const string KeyRows = "rows";
        private const string KeyColumns = "cols";

        public int? Rows { get; private set; }

        public int? Columns { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyRows:
                    this.Rows = int.Parse(value);
                    break;
                case KeyColumns:
                    this.Columns = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeyRows, this.Rows));
            output.Add(new KeyValuePair<string, object>(KeyColumns, this.Columns));
        }
    }
}