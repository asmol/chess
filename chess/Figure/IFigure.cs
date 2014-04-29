using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    public enum ETeam {White, Black}
    public enum EType {Pawn, Knight, Bishop, Rook, Queen, King}

    public interface IFigure
    {
        ETeam Team {get;}
        EType Type {get;}
        bool CanReachTile(Point from, Point to, IFigure[,] figures);
    }
}