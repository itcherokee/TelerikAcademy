namespace DocSystem
{
    using System.Collections.Generic;

    public class PDFDocument : EcryptableDocument
    {
        private const string KeyPages = "pages";

        public int? Pages { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyPages:
                    this.Pages = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeyPages, this.Pages));
        }
    }
}
