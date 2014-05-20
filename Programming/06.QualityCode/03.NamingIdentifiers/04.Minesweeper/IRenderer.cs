namespace Mines
{
    public interface IRenderer
    {
        void PrintMessage(string message);
        void PrintMessage(string message, params string[] arguments);
    }
}