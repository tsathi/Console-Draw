namespace ConsoleDraw.Interfaces
{
    public interface ICanvas
    {
        void CreateNew(int v1, int v2);
        void Display();
        void DrawAt(int x, int y, char c);
        bool IsPointOnCanvas(int row, int col);
        bool IsPixelEmpty(int y,int x);
        bool IsInitialized();
    }
}
