using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public class Turn
    {
<<<<<<< HEAD
        public Turn(Point2 from, Point2 to, int timePerTurn,EPawnPromotion? pawnPromotion)
=======
        public Turn(Point2 from, Point2 to, int timePerTurn)
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
        {
            this.From = from;
            this.To = to;
            this.TimePerTurn = timePerTurn;
<<<<<<< HEAD
            this.PawnPromotion = pawnPromotion;
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
        }
        public Point2 From { get; set; }
        public Point2 To { get; set; }
        public int TimePerTurn { get; set; }
<<<<<<< HEAD
        public EPawnPromotion? PawnPromotion {get;set;}
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
    }
}
