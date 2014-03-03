namespace DocSystem
{
    using System.Collections.Generic;

    public abstract class MultimediaDocument : BinaryDocument
    {
        private const string KeyLength = "length";

        /// <summary>
        /// Gets and sets the length of multmedia content.
        /// </summary>
        protected int? Length { get; private set; }
        
        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyLength:
                    this.Length = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeyLength, this.Length));
        }
    }
}