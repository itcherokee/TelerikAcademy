namespace KpkPracticalExam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contCat, ICommand c, StringBuilder sb)
        {
            switch (c.Type)
            {
                case CommandType.AddBook:
                    {
                        contCat.Add(new Content(ContentType.Book, c.Parameters));
                        sb.AppendLine("Books Added");
                    }

                    break;
                case CommandType.AddMovie:
                    {
                        contCat.Add(new Content(ContentType.Movie, c.Parameters));
                        sb.AppendLine("Movie added");
                    }

                    break;
                case CommandType.AddSong:
                    {
                        contCat.Add(new Content(ContentType.Music, c.Parameters));
                        sb.Append("Song added");
                    }

                    break;
                case CommandType.AddApplication:
                    {
                        contCat.Add(new Content(ContentType.Application, c.Parameters));
                        sb.AppendLine("Application added");
                    }

                    break;
                case CommandType.Update:
                    {
                        if (c.Parameters.Length == 2)
                        {
                        }
                        else
                        {
                            throw new FormatException("невалидни параметри!");
                        }

                        sb.AppendLine(String.Format("{0} items updated", contCat.Update(c.Parameters[0], c.Parameters[1]) - 1));
                    }

                    break;
                case CommandType.Find:
                    {
                        if (c.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new Exception("Invalid number of parameters!");
                        }

                        int numberOfElementsToList = int.Parse(c.Parameters[1]);
                        IEnumerable<IContent> foundContent = contCat.GetListContent(c.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            sb.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (IContent content in foundContent)
                            {
                                sb.AppendLine(content.TextRepresentation);
                            }
                        }
                    }

                    break;
                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }
    }
}
