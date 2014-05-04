using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    class Queen : Figure, IFigure
    {
        public ETeam Team
        {
            get {return team;}
        }
        public EType Type
        {
            get {return type;}
        }

        public Queen(ETeam team): base(team,EType.Queen) { }

        public bool CanReachTile(Point from, Point to, IFigure[,] figures)
        {
            if (new Bishop(team).CanReachTile(from, to, figures) || new Rook(team).CanReachTile(from, to, figures))
                return true;
            return false;
        }
    }
}