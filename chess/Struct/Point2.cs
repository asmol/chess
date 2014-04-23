using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public struct Point2
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point2(int x=0, int y=0):this()
        {
            X = x; Y = y;
        }
    }
}
