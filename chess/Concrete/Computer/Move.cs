using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    struct Move
    {
        public Point From, To;

        public Move(Point from, Point to)
        {
            this.From = from;
            this.To = to;
        }
    }
}