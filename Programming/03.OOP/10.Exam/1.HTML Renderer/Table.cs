using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class Table : BaseElement, ITable
    {
        public Table(int rows, int cols)
            : base("table", "")
        {
            this.table = new IElement[rows, cols];
        }

        private IElement[,] table;


        public override string ToString()
        {
            // TODO implement ToString()
            return string.Empty;
        }

        public int Rows
        {
            get { return table.GetLength(0); }
        }

        public int Cols
        {
            get { return table.GetLength(1); }
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.table[row, col];
            }
            set
            {
                this.table[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                output.Append("<tr>");
                for (int k = 0; k < table.GetLength(1); k++)
                {
                    output.Append("<td>");
                    foreach (var item in this.ChildElements)
                    {
                        item.Render(output);
                    }
                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.Append("<table>");
            output.Append(this.TextContent);
            foreach (var item in this.ChildElements)
            {
                item.Render(output);
            }
            output.Append("</" + this.Name + ">");

        }
    }
}
