using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public enum ETurnResult { prohibited, normal, check, checkmate, stalemate
        , thriceRepeated, withoutChange50 }
    public interface ITurnProcessor
    {
        ETurnResult CheckTurn(IFigure[,] field, ETeam team, Point2 from, Point2 to);
    }
}
