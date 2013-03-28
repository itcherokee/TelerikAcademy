using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "name":
                    this.Name = value;
                    break;
                case "content":
                    this.Content = value;
                    break;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("key", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            List<KeyValuePair<string, object>> contents = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(contents);
            contents.Sort((x, y) => x.Key.CompareTo(y.Key));
            output.Append(this.GetType().Name);
            output.Append("[");
            List<string> attributes = new List<string>();
            foreach (var item in contents)
            {
                attributes.Add(item.Key + "=" + item.Value);
            }
            output.Append(string.Join(";", attributes));
            output.Append("]");
            return output.ToString();
        }

        //public int Compare(IDocument x, IDocument y)
        //{
        //    if (x.Name.CompareTo(y.Name) < 0)
        //    {
        //        return -1;
        //    }
        //    else if (x.Name.CompareTo(y.Name) > 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public int CompareTo(IDocument other)
        //{
        //    IDocument secondDoc = other as IDocument;
        //    if (this.Name.CompareTo(secondDoc.Name) < 0)
        //    {
        //        return -1;
        //    }
        //    else if (this.Name.CompareTo(secondDoc.Name) > 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}
