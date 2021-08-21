using System.Collections.Generic;
using ConsoleDraw.Domain;
using ConsoleDraw.Interfaces;

namespace ConsoleDraw.Drawers
{
    public class LineDrawerHandler : ILineDrawerHandler
    {
        private IEnumerable<ILineDrawer> _lineDraws;

        public LineDrawerHandler(IEnumerable<ILineDrawer> lineDraws) => _lineDraws = lineDraws;
      
        public void Draw(ICanvas canvas, Point from, Point to)
        {
            foreach (var ld in _lineDraws)
            {
                if (ld.Test(from, to))
                {
                    ld.Draw(canvas, from, to);
                    break;
                }
            }
        }
    }
}
