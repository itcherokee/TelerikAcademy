namespace DocSystem
{
    using System.Collections.Generic;

    public abstract class OfficeDocument : EcryptableDocument
    {
        private const string KeyVersion = "version";

        protected string Version { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyVersion:
                    this.Version = value;
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeyVersion, this.Version));
        }
    }
}