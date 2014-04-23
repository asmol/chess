using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public class Turn
    {
        public Turn(Point2 from, Point2 to, int timePerTurn)
        {
            this.From = from;
            this.To = to;
            this.TimePerTurn = timePerTurn;
        }
        public Point2 From { get; set; }
        public Point2 To { get; set; }
        public int TimePerTurn { get; set; }
    }
}
