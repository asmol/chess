using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace chess
{
    public enum ETeam {White, Black}
    public enum EType
    {
        [Description("")]
        Pawn,
        [Description("N")]
        Knight,
        [Description("B")]
        Bishop,
        [Description("R")]
        Rook,
        [Description("Q")]
        Queen,
        [Description("K")]
        King
    }

    public interface IFigure
    {
        ETeam Team {get;}
        EType Type {get;}
        bool CanReachTile(Point from, Point to, IFigure[,] figures);
    }
}