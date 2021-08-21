namespace ConsoleDraw.Interfaces
{
    public interface IConsoleWriter
    {
        void Write(string message);
        void Write(char c);
        void WriteLine();
    }

    public interface IConsoleReader
    {
        string Read(string message);
    }

}
