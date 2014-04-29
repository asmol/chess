using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    struct AreaF
    {
<<<<<<< HEAD
        public static readonly Point Empty = new Point(-1,0);
=======
        public static readonly Point Empty = new Point(-1, 0);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439

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
<<<<<<< HEAD
            Point d = new Point(Math.Abs(left.X-right.X),Math.Abs(left.Y-right.Y)),
                min = new Point(Math.Min(left.X,right.X)+1,Math.Min(left.Y,right.Y)+1);
=======
            Point d = new Point(Math.Abs(left.X - right.X), Math.Abs(left.Y - right.Y)),
                min = new Point(Math.Min(left.X, right.X) + 1, Math.Min(left.Y, right.Y) + 1);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            Point[] result = new Point[0];
            if (d != Point.Empty)
                if (d.X == 0)
                {
<<<<<<< HEAD
                    result = new Point[d.Y-1];
                    for (int i = 0; i < result.Length; i++)
                        result[i] = new Point(left.X,min.Y+i);
=======
                    result = new Point[d.Y - 1];
                    for (int i = 0; i < result.Length; i++)
                        result[i] = new Point(left.X, min.Y + i);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
                }
                else if (d.Y == 0)
                {
                    result = new Point[d.X - 1];
                    for (int i = 0; i < result.Length; i++)
<<<<<<< HEAD
                        result[i] = new Point(min.X+i,left.Y);
=======
                        result[i] = new Point(min.X + i, left.Y);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
                }
                else if (d.X == d.Y)
                {
                    result = new Point[d.X - 1];
<<<<<<< HEAD
                    Point min2 = new Point(min.X-1,min.Y-1);
                    int maxY = Math.Max(left.Y,right.Y)-1;
                    for (int i = 0; i < result.Length; i++)
                        result[i] = new Point(min.X+i,(min2 == left || min2 == right) ? min.Y+i : maxY-i);
                }
            return result;
        }

        public static Point ReverseCell(Point source)
        {
            return new Point(Math.Abs(source.X-7),Math.Abs(source.Y-7));
        }

        public static int ReverseCell(int source)
        {
            return Math.Abs(source-7);
        }
=======
                    Point min2 = new Point(min.X - 1, min.Y - 1);
                    int maxY = Math.Max(left.Y, right.Y) - 1;
                    for (int i = 0; i < result.Length; i++)
                        result[i] = new Point(min.X + i, min2 == left || min2 == right ? min.Y + i : maxY - i);
                }
            return result;
        }
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
    }
}