using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    public enum ETeam {White, Black}
    public enum EType {Pawn, Knight, Bishop, Rook, Queen, King}
    public enum EReachResult { none, move, capture } // не возможен ход, простое передвижение, захват
    public interface IFigure
    {
        ETeam Team {get;}
        EType Type {get;}
        EReachResult CanReachTile(Point2 from, Point2 to, IFigure[,] figures);
        //сюда будут передаваться только проверенные ходы для их осуществления
        void ExecuteMove(ref IFigure[,] field, Point2 from, Point2 to); 
    }
}