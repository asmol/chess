using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    enum ECkechersTurnResult { normal, allEnemiesCaptured, enemyHasNoTurns };
    interface ICheckersTurnProcessor
    {
        bool IsTurnAllowed(IFigure[,] field, Point2[] way, ETeam team);
        ECkechersTurnResult DoAllowedTurn(ref IFigure[,] field, Point2[] way);
    }
}
