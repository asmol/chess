using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    public class Bishop : IFigure
    {
        private readonly ETeam team;
        private readonly EType type = EType.Bishop;

        public ETeam Team
        {
            get {return team;}
        }
        public EType Type
        {
            get {return type;}
        }

        public Bishop(ETeam team)
        {
            this.team = team;
        }

        public bool CanReachTile(Point from, Point to, IFigure[,] figures)
        {
            int x = Math.Abs(from.X-to.X),
                y = Math.Abs(from.Y-to.Y);
            Point[] between = AreaF.BetweenPoints(from,to);
            if (x > 0 && y > 0 && x == y)
            {
                for (int i = 0; i < between.Length; i++)
                    if (figures[between[i].Y,between[i].X] != null)
                        return false;
                if (figures[to.Y,to.X] == null || (figures[to.Y,to.X] != null && figures[to.Y,to.X].Team != team))
                    return true;
            }
            return false;
        }
    }
}