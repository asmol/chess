using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    class CheckersTurnProcessor
    {
        public bool IsTurnPossible(IFigure[,] field, Point2[] way)
        {
            IFigure[,] f = (IFigure[,])field.Clone();
            for (int i = 1; i < way.Length; i++)
            {
                Point2 from = way[i];
                Point2 to = way[i - 1];
                EReachResult res = field[from.Y, from.X].CanReachTile(from, to, f);

                bool lastMove = i == way.Length - 1;

                //дальше 3 варианта
                if (lastMove && res == EReachResult.move) return true;
                if(
            }
        }

        IFigure[,] DoMove(IFigure[,] field, Point2 from, Point2 to)
        {
            IFigure[,] res = (IFigure[,])field.Clone();
            field[from.X, from.X].ExecuteMove(ref res, from, to);
            return res;
        }
    }
}
