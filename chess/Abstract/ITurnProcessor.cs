using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public enum ETurnResult {  normal, checkmate, stalemate }
    public interface ITurnProcessor
    {
        bool IsAllowedTurn(IFigure[,] field, ETeam team, Point2 from, Point2 to
            , List<IFigure> movedKingsOrRooks, Point2 lastEnemyTurnFrom, Point2 lastEnemyTurnTo);
        ETurnResult DoAllowedTurn(ref IFigure[,] field, Point2 from, Point2 to
            , ChoosePawnPromotionDelegate ChoosePawnPromotion, ref List<IFigure> movedKingsOrRooks
            , out EPawnPromotion? wasPawnPromotion);
       
    }
}
