using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    class Pawn : IFigure
    {
        private readonly ETeam team;
        private readonly EType type = EType.Pawn;

        public ETeam Team
        {
            get {return team;}
        }
        public EType Type
        {
            get {return type;}
        }

        public Pawn(ETeam team)
        {
            this.team = team;
        }

        public bool CanReachTile(Point from, Point to, IFigure[,] figures)
        {
            int x = Math.Abs(from.X - to.X),
                y = from.Y - to.Y,
                absY = Math.Abs(y);
            Point[] between = AreaF.BetweenPoints(from, to);
            if ((team == ETeam.White && (y == 1 || (y == 2 && from.Y == 6))) || (team == ETeam.Black && (y == -1 || (y == -2 && from.Y == 1))))
            {
                if (absY == 2)
                    for (int i = 0; i < between.Length; i++)
                        if (figures[between[i].Y, between[i].X] != null)
                            return false;
<<<<<<< HEAD
                int offset = team == ETeam.White ? to.Y+1 : to.Y-1;
                if ((x == 0 && figures[to.Y, to.X] == null) || (x == 1 && absY == 1 && ((figures[to.Y, to.X] != null && figures[to.Y, to.X].Team != team) || (figures[offset,to.X] != null && figures[offset,to.X].Type == EType.Pawn && figures[offset,to.X].Team != team))))
=======
                if ((x == 0 && figures[to.Y, to.X] == null) || (x == 1 && absY == 1 && figures[to.Y, to.X] != null && figures[to.Y, to.X].Team != team))
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
                    return true;
            }
            return false;
        }
    }
}