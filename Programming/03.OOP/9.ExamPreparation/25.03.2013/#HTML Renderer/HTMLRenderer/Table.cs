namespace HTMLRenderer
{
    using System;
    using System.Text;

    public class Table : HTMLElement, ITable
    {
        private const string DefaultName = "table";
        private readonly IElement[,] table;

        public Table(int rows, int columns)
            : base(Table.DefaultName)
        {
            this.Rows = rows;
            this.Cols = columns;
            this.table = new IElement[this.Rows, this.Cols];
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public IElement this[int row, int col]
        {
            get
            {
                if (row >= 0 && row <= this.table.GetLength(0) && col >= 0 && col <= this.table.GetLength(1))
                {
                    return this.table[row, col];
                }

                throw new ArgumentOutOfRangeException("Index is out of range!");
            }

            set
            {
                if (value != null)
                {
                    if (row >= 0 && row <= this.table.GetLength(0) && col >= 0 && col <= this.table.GetLength(1))
                    {
                        this.table[row, col] = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Index is out of range!");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Element cannot be null!");
                }
            }
        }

        public override void Render(StringBuilder output)
        {
            base.Render(output);
            StringBuilder renderedTableContent = null;
            if (this.Rows != 0 && this.Cols != 0)
            {
                renderedTableContent = new StringBuilder();
                for (int row = 0; row < this.Rows; row++)
                {
                    renderedTableContent.Append("<tr>");
                    for (int col = 0; col < this.Cols; col++)
                    {
                        renderedTableContent.Append("<td>");
                        StringBuilder content = new StringBuilder();
                        this[row, col].Render(content);
                        renderedTableContent.Append(content);
                        renderedTableContent.Append("</td>");
                    }

                    renderedTableContent.Append("</tr>");
                }
            }

            int indexClosingAngleBracket = output.ToString().IndexOf("</" + this.Name, System.StringComparison.Ordinal);
            indexClosingAngleBracket = indexClosingAngleBracket < 0 ? 0 : indexClosingAngleBracket;
            output.Insert(indexClosingAngleBracket, renderedTableContent);
        }
    }
}