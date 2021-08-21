using ConsoleDraw.Domain;

namespace ConsoleDraw.Interfaces
{
    public interface ILineDrawerHandler
    {
        void Draw(ICanvas canvas, Point from, Point to);
    }
}
