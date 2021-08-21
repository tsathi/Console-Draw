using ConsoleDraw.Domain;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw.Drawers
{
    public class RectangleDrawer : IRectangleDrawer
    {
        public void Draw(ICanvas canvas, Rectangle rect, ILineDrawerHandler linedrawer)
        {
            linedrawer.Draw(canvas,new Point(rect.Y1, rect.X1), new Point(rect.Y2, rect.X1));
            linedrawer.Draw(canvas, new Point(rect.Y1, rect.X1), new Point(rect.Y1, rect.X2));
            linedrawer.Draw(canvas, new Point(rect.Y2, rect.X1), new Point(rect.Y2, rect.X2));
            linedrawer.Draw(canvas, new Point(rect.Y1, rect.X2), new Point(rect.Y2, rect.X2));
        }
    }
}
