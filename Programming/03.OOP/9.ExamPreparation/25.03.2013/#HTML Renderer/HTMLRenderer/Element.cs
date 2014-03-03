namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Element : HTMLElement
    {
        private readonly List<IElement> childElements;

        public Element(string name = null, string content = null)
            : base(name)
        {
            this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                return new List<IElement>(this.childElements);
            }
        }

        public override void AddElement(IElement element)
        {
            if (element != null)
            {
                this.childElements.Add(element);
            }
        }

        public override void Render(StringBuilder output)
        {
            base.Render(output);

            int indexClosingAngleBracket = output.ToString().IndexOf("</" + this.Name, System.StringComparison.Ordinal);
            indexClosingAngleBracket = indexClosingAngleBracket < 0 ? 0 : indexClosingAngleBracket;

            StringBuilder renderedChieldElements = null;
            if (this.ChildElements.Count(x => x != null) > 0)
            {
                renderedChieldElements = new StringBuilder();
                foreach (var element in this.ChildElements)
                {
                    element.Render(renderedChieldElements);
                }
            }

            if (renderedChieldElements != null)
            {
                output.Insert(indexClosingAngleBracket, renderedChieldElements);
            }

            if (!string.IsNullOrWhiteSpace(this.TextContent))
            {
                string parsedContent = this.Parse(this.TextContent);
                output.Insert(indexClosingAngleBracket, parsedContent);
            }
        }
    }
}