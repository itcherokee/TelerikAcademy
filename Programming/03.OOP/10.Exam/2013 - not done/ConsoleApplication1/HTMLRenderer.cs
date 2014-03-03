using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    #region Original Code
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {

        public IElement CreateElement(string name)
        {
            Element element = new Element(name);
            return element;
        }

        public IElement CreateElement(string name, string content)
        {
            Element element = new Element(name, content);
            return element;
        }

        public ITable CreateTable(int rows, int cols)
        {
            Table table = new Table(rows, cols);
            return table;
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
    #endregion

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

    public class Element : BaseElement
    {
        public Element(string name, string textcontent)
            : base(name, textcontent)
        {
        }

        public Element(string name)
            : base(name, "")
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

    public abstract class BaseElement : IElement
    {

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
