using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IEncryptable
    {

        public int Pages { get; set; }

        public bool IsEncrypted { get; set; }

        public void Encrypt()
        {
            if (!IsEncrypted)
            {
                this.IsEncrypted = true;
            };
        }

        public void Decrypt()
        {
            if (IsEncrypted)
            {
                this.IsEncrypted = false;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "pages":
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
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        }
    }
}
