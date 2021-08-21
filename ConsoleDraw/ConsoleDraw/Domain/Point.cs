using System;

namespace ConsoleDraw.Domain
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int y, int x)
        {
            if (x < 0 || y < 0)
                throw new ArgumentException("Please enter a valid coordinate for a line");

            X = x;
            Y = y;
        }
    }
}
