using ConsoleDraw.Domain;

namespace ConsoleDraw.Interfaces
{
    public interface ILineDrawer
    {
        bool Test(Point from, Point to);
        void Draw(ICanvas canvas, Point from, Point to);
    }
}
