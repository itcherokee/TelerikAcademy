namespace DocSystem
{
    using System.Collections.Generic;

    public class WordDocument : OfficeDocument, IEditable
    {
        private const string KeyCharactersCount = "chars";

        public int? CharactersCount { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyCharactersCount:
                    this.CharactersCount = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeyCharactersCount, this.CharactersCount));
        }

        public void ChangeContent(string newContent)
        {
            this.LoadProperty(KeyContent, newContent);
        }
    }
}
