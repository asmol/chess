using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    class King : IFigure
    {
        private readonly ETeam team;
        private readonly EType type = EType.King;

        public ETeam Team
        {
            get {return team;}
        }
        public EType Type
        {
            get {return type;}
        }

        public King(ETeam team)
        {
            this.team = team;
        }

        public bool CanReachTile(Point from, Point to, IFigure[,] figures)
        {
            int x = Math.Abs(from.X-to.X),
                y = Math.Abs(from.Y-to.Y);
            Point[] between = AreaF.BetweenPoints(from,to);
            if ((x == 0 && y == 1) || ((x == 1 || (from.X == 4 && x == 2 && ((team == ETeam.White && to.Y == 7) || (team == ETeam.Black && to.Y == 0)))) && y == 0) || (x == 1 && y == 1))
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