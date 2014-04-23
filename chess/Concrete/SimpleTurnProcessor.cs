using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace chess
{
    class SimpleTurnProcessor:ITurnProcessor
    {

        public ETurnResult CheckTurn(IFigure[,] field, ETeam team, Point2 from, Point2 to)
        {
            return CheckTurn(field, team, from, to, false);
        }

        ETurnResult CheckTurn(IFigure[,] field, ETeam team, Point2 from, Point2 to
            , bool onlyProhibitedCheckRequired)
        {
            IFigure[,] fieldCopy = (IFigure[,])field.Clone(); // to prevent change

            IFigure figure = fieldCopy[from.Y, from.X];
            ETeam enemy = team == ETeam.Black ? ETeam.White : ETeam.Black;

            //-------------0
            if(figure == null || figure.Team != team) return ETurnResult.prohibited;

            //---------1
            if (!figure.CanReachTile(new Point(from.X, from.Y), new Point(to.X, to.Y), fieldCopy)) return ETurnResult.prohibited;

            MimicTurn(fieldCopy,from, to);
            //----------2
            if (IsKingUnderAttack(fieldCopy,team, enemy))
            {
                return ETurnResult.prohibited;
            }

            //for turn possibility check
            //we don't need to go recursion
            if (onlyProhibitedCheckRequired) return ETurnResult.normal;
            //---------3
            if (IsTeamHasNonProhibitedTurn(fieldCopy,enemy))
            {
                return ETurnResult.normal;
            } else
            {
                //--------4
                if (IsKingUnderAttack(fieldCopy,team, enemy)) return ETurnResult.checkmate;
                //--------5
                else return ETurnResult.stalemate;
            }
        }

        void MimicTurn(IFigure[,] field, Point2 from, Point2 to)
        {
            IFigure figure = field[from.Y, from.X];
            field[from.Y, from.X] = null;
            field[to.Y, to.X] = figure;
        }

        bool IsKingUnderAttack(IFigure[,] field, ETeam team, ETeam enemy)
        {
            Point2 kingPoint = FindKing(field,team);

            int n = field.GetLength(0);
            int m = field.GetLength(1);

            for(int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    IFigure f = field[i, j];
                    if (f!= null && f.Team == enemy && f.CanReachTile(new Point(j, i)
                        , new Point(kingPoint.X, kingPoint.Y), field))
                    {
                        return true;
                    }
                }
                    
            return false;
        }

        Point2 FindKing(IFigure[,] field, ETeam team)
        {
            int n = field.GetLength(0);
            int m = field.GetLength(1);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (field[i, j] is King && field[i,j].Team == team)
                        return new Point2(j, i);

            return new Point2(); // unreachable
        }

        bool IsTeamHasNonProhibitedTurn(IFigure[,] field, ETeam team)
        {
            int n = field.GetLength(0);
            int m = field.GetLength(1);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    for (int ii = 0; ii < n; ii++)
                        for (int jj = 0; jj < m; jj++)
                        {
                            if (CheckTurn(field, team, new Point2(j, i), new Point2(jj, ii), true)
                                != ETurnResult.prohibited)
                            {
                                return true;
                            }
                        }
                }

            return false;
        }
    }
}
