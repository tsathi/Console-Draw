using ConsoleDraw.Interfaces;

namespace ConsoleDraw
{
    public class Canvas : ICanvas
    {
        private char[,] array;
        private IConsoleWriter _consoleWriter;

        public int Width => array.GetLength(0);
        public int Height => array.GetLength(1);
        public char[,] GetCanvas() => array;

        public Canvas(IConsoleWriter consoleWriter) => _consoleWriter = consoleWriter;

        public bool IsInitialized() => array != null;

        public bool IsPointOnCanvas(int col, int row) => col - 1 < Width && row - 1 < Height;

        public bool IsPixelEmpty(int col, int row) => col - 1 >= 0 && row - 1 >= 0 && array[col - 1, row - 1] == ' ';

        public void CreateNew(int col, int row)
        {
            array = new char[col, row];

            for (int c = 0; c < col; c++)
                for (int r = 0; r < row; r++)
                    array[c, r] = ' ';
        }

        public void DrawAt(int y, int x, char c)
        {
            if (y - 1 > Width || x - 1 > Height || y - 1 < 0 || x - 1 < 0)
                return;

            array[y - 1, x - 1] = c;
        }

        public void Display()
        {
            DisplayBoder();
            DisplayBody();
            DisplayBoder();
        }

        private void DisplayBody()
        {
            for (int r = 0; r < Height; r++)
            {
                _consoleWriter.Write('|');

                for (int c = 0; c < Width; c++)
                    _consoleWriter.Write(array[c, r]);

                _consoleWriter.Write('|');
                _consoleWriter.WriteLine();
            }
        }

        private void DisplayBoder()
        {
            for (int c = 0; c <= array.GetLength(0); c++)
                _consoleWriter.Write('-');

            _consoleWriter.WriteLine();
        }
    }
}
