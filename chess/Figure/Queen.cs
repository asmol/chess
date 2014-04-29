using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    class Queen : IFigure
    {
        private readonly ETeam team;
        private readonly EType type = EType.Queen;

        public ETeam Team
        {
            get {return team;}
        }
        public EType Type
        {
            get {return type;}
        }

        public Queen(ETeam team)
        {
            this.team = team;
        }

        public bool CanReachTile(Point from, Point to, IFigure[,] figures)
        {
            if (new Bishop(team).CanReachTile(from, to, figures) || new Rook(team).CanReachTile(from, to, figures))
                return true;
            return false;
        }
    }
}