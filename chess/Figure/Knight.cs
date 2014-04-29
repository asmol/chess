using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    class Knight : IFigure
    {
        private readonly ETeam team;
        private readonly EType type = EType.Knight;

        public ETeam Team
        {
            get {return team;}
        }
        public EType Type
        {
            get {return type;}
        }

        public Knight(ETeam team)
        {
            this.team = team;
        }

        public bool CanReachTile(Point from, Point to, IFigure[,] figures)
        {
            int x = Math.Abs(from.X-to.X),
                y = Math.Abs(from.Y-to.Y);
            if ((x == 1 && y == 2) || (x == 2 && y == 1))
                if (figures[to.Y,to.X] == null || (figures[to.Y,to.X] != null && figures[to.Y,to.X].Team != team))
                    return true;
            return false;
        }
    }
}