using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public class Turn
    {
        public Turn(Point2 from, Point2 to, int timePerTurn,EPawnPromotion? pawnPromotion)
        {
            this.From = from;
            this.To = to;
            this.TimePerTurn = timePerTurn;
            this.PawnPromotion = pawnPromotion;
        }
        public Point2 From { get; set; }
        public Point2 To { get; set; }
        public int TimePerTurn { get; set; }
        public EPawnPromotion? PawnPromotion {get;set;}
    }
}