using ConsoleDraw.Domain;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw.Drawers
{
    public class VerticalLineDrawer : ILineDrawer
    {
        public bool Test(Point from, Point to) => from.Y == to.Y;
        
        public void Draw(ICanvas canvas, Point from, Point to)
        {
            for (int r = from.X; r <= to.X; r++)
                canvas.DrawAt(from.Y, r, 'x');
        }
    }
}
