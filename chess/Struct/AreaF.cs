using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    struct AreaF
    {
        public static readonly Point Empty = new Point(-1, 0);

        public PointF Position;
        public SizeF Size;

        public AreaF(PointF position, SizeF size)
        {
            Position = position;
            Size = size;
        }

        public bool InArea(PointF position)
        {
            if (position.X >= Position.X && position.Y >= Position.Y && position.X <= Position.X + Size.Width && position.Y <= Position.Y + Size.Height)
                return true;
            return false;
        }

        public static Point[] BetweenPoints(Point left, Point right)
        {
            Point d = new Point(Math.Abs(left.X - right.X), Math.Abs(left.Y - right.Y)),
                min = new Point(Math.Min(left.X, right.X) + 1, Math.Min(left.Y, right.Y) + 1);
            Point[] result = new Point[0];
            if (d != Point.Empty)
                if (d.X == 0)
                {
                    result = new Point[d.Y - 1];
                    for (int i = 0; i < result.Length; i++)
                        result[i] = new Point(left.X, min.Y + i);
                }
                else if (d.Y == 0)
                {
                    result = new Point[d.X - 1];
                    for (int i = 0; i < result.Length; i++)
                        result[i] = new Point(min.X + i, left.Y);
                }
                else if (d.X == d.Y)
                {
                    result = new Point[d.X - 1];
                    Point min2 = new Point(min.X - 1, min.Y - 1);
                    int maxY = Math.Max(left.Y, right.Y) - 1;
                    for (int i = 0; i < result.Length; i++)
                        result[i] = new Point(min.X + i, min2 == left || min2 == right ? min.Y + i : maxY - i);
                }
            return result;
        }
    }
}