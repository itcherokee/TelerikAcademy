namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class HTMLElement : IElement
    {
        protected HTMLElement(string name = null)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements { get; private set; }

        public virtual void AddElement(IElement element)
        {
        }

        public virtual void Render(StringBuilder output)
        {
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                string renderedOutput = this.Parse(this.Name);
                output.Append("<");
                output.Append(renderedOutput);
                output.Append(">");
                output.Append("</");
                output.Append(renderedOutput);
                output.Append(">");
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }

        protected virtual string Parse(string text)
        {
            string parsed = text;
            if (text.Contains("&"))
            {
                parsed = parsed.Replace("&", "&amp;");
            }

            if (text.Contains("<"))
            {
                parsed = parsed.Replace("<", "&lt;");
            }

            if (text.Contains(">"))
            {
                parsed = parsed.Replace(">", "&gt;");
            }

            return parsed;
        }
    }
}