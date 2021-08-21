using ConsoleDraw.Domain;

namespace ConsoleDraw.Interfaces
{
    public interface IRectangleDrawer
    {
        void Draw(ICanvas canvas, Rectangle rect, ILineDrawerHandler linedrawer);
    }
}
