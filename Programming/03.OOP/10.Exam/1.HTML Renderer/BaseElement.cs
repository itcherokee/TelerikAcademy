using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public abstract class BaseElement : IElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseElement" /> class.
        /// </summary>
        public BaseElement(string name = null, string textcontent = null)
        {
            if (name == null || textcontent == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.name = name;
                this.TextContent = textcontent;
                this.childElements = new List<IElement>();
                finalOutput = new StringBuilder();
            }

        }

        StringBuilder finalOutput;

        private string name;

        private List<IElement> childElements;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {

        }

        public override string ToString()
        {
            //TODO: to implement ToString()
            return string.Empty;
        }
    }
}

