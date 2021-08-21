using System;

namespace ConsoleDraw.Domain
{
    public class Rectangle
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Rectangle(int y1, int x1, int y2, int x2)
        {
            if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0)
                throw new ArgumentException("Please enter a valid coordinate for a rectangle");

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
    }
}
