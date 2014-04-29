using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
<<<<<<< HEAD
    public enum ETurnResult {normal,checkmate,stalemate}

    public interface ITurnProcessor
    {
        bool IsAllowedTurn(IFigure[,] field, ETeam team, Point2 from, Point2 to
            , List<IFigure> movedKingsOrRooks, Point2 lastEnemyTurnFrom, Point2 lastEnemyTurnTo);
        ETurnResult DoAllowedTurn(ref IFigure[,] field, Point2 from, Point2 to
            , ChoosePawnPromotionDelegate ChoosePawnPromotion, ref List<IFigure> movedKingsOrRooks
            , out EPawnPromotion? wasPawnPromotion);
    }
}
=======
    public enum ETurnResult { prohibited, normal, check, checkmate, stalemate
        , thriceRepeated, withoutChange50 }
    public interface ITurnProcessor
    {
        ETurnResult CheckTurn(IFigure[,] field, ETeam team, Point2 from, Point2 to);
    }
}
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
