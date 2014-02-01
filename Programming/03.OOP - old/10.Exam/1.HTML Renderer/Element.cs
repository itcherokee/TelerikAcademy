using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class Element : BaseElement
    {
        public Element(string name, string textcontent)
            : base(name, textcontent)
        {
        }

        public Element(string name) : base(name, "")
        {
        }

        public override string ToString()
        {
            // TODO: TO implement ToString()
            return string.Format("");
        }

        public override void Render(StringBuilder output)
        {
            output.Append("<" + this.Name + ">");
            output.Append(this.TextContent);
            foreach (var item in this.ChildElements)
            {
                item.Render(output);
            }
            output.Append("</" + this.Name + ">");
        }

    }
}
