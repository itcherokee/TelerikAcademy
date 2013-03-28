using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        private string charset;

        public string Charset
        {
            get
            {
                return charset;
            }
            set
            {
                if (value == "utf-8" || value == "windows-1251")
                {
                    this.charset = value;
                }
                else
                {
                    this.charset = string.Empty;
                }
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "charset":
                    this.Charset = value;
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        }
    }
}
