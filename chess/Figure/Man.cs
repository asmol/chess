using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    class Man : IFigure
    {
        private readonly ETeam team;
        private readonly EType type = EType.Man;

        public ETeam Team
        {
            get {return team;}
        }
        public EType Type
        {
            get {return type;}
        }

        public Man(ETeam team)
        {
            this.team = team;
        }

        public EReachResult CanReachTile(Point2 from, Point2 to, IFigure[,] figures)
        {
            int x = Math.Abs(from.X-to.X),
                y = Math.Abs(from.Y-to.Y),
                signedY = from.Y-to.Y;
            Point[] between = AreaF.BetweenPoints(new Point(from.Y,from.X),new Point(from.Y,from.X));
            if (x > 0 && y > 0 && x == y && signedY > 0)
                if (figures[to.Y,to.X] == null)
                {
                    foreach (Point point in between)
                        if (figures[point.Y,point.X] != null)
                            if (figures[point.Y,point.X].Team != team)
                                return EReachResult.capture;
                            else
                                return EReachResult.none;
                    return EReachResult.move;
                }
            return EReachResult.none;
        }

        public void ExecuteMove(ref IFigure[,] field, Point2 from, Point2 to)
        {
            Point[] between = AreaF.BetweenPoints(new Point(from.Y,from.X),new Point(from.Y,from.X));
            foreach (Point point in between)
                if (field[point.Y,point.X] != null && field[point.Y,point.X].Team != team)
                    field[point.Y,point.X] = null;
        }
    }
}