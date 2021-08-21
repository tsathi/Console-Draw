using ConsoleDraw.Domain;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw.Drawers
{
    public class HorizontalLineDrawer : ILineDrawer
    {
        public bool Test(Point from, Point to) => from.X == to.X;
        
        public void Draw(ICanvas canvas, Point from, Point to)
        {
            for (int y = from.Y; y <= to.Y; y++)
                canvas.DrawAt(y, from.X, 'x');
        }
    }
}
