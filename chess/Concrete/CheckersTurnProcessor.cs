using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    class CheckersTurnProcessor : ICheckersTurnProcessor
    {

        public bool IsTurnAllowed(IFigure[,] field, Point2[] way, ETeam team)
        {
            if (!IsFigureBelongsTeam(field[way[0].Y, way[0].X], team)) return false;

            IFigure[,] f = (IFigure[,])field.Clone();
            for (int i = 1; i < way.Length; i++)
            {
                Point2 from = way[i];
                Point2 to = way[i - 1];

                //понадобятся 3 переменные
                EReachResult res = field[from.Y, from.X].CanReachTile(from, to, f);
                bool canCaptureMore = IsCanCaptureMore(f, to);
                bool isLastMove = i == way.Length - 1;

                //дальше варианты
                if (res == EReachResult.none) { return false; }
                else if (res == EReachResult.move)
                {
                    return isLastMove;
                }
                else
                {
                    if (isLastMove)
                    {
                        return !canCaptureMore;
                    }
                }

                //если проверка продолжается, делаем ход
                f = DoMove(f, from, to);
            }

            return false;// недостижимый код
        }

        public ECkechersTurnResult DoAllowedTurn(ref IFigure[,] field, Point2[] way)
        {
            for (int i = 1; i < way.Length; i++)
            {
                field = DoMove(field, way[i-1], way[i]);
            }

            IFigure figure = field[way[0].Y, way[0].X];
            ETeam enemy = figure.Team == ETeam.Black ? ETeam.White : ETeam.Black;

            if (!isAnyAliveCheckers(field, enemy)) return ECkechersTurnResult.allEnemiesCaptured;
            if (!IsTeamHasNonProhibitedTurn(field, enemy)) return ECkechersTurnResult.enemyHasNoTurns;
            return ECkechersTurnResult.normal;
        }

        IFigure[,] DoMove(IFigure[,] field, Point2 from, Point2 to)
        {
            IFigure[,] res = (IFigure[,])field.Clone();
            field[from.X, from.X].ExecuteMove(ref res, from, to);
            return res;
        }

        bool IsCanCaptureMore(IFigure[,] field, Point2 from)
        {
            int n = field.GetLength(0);
            int m = field.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[from.Y, from.X].CanReachTile(from, new Point2(j, i), field)
                        == EReachResult.capture)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        bool IsFigureBelongsTeam(IFigure figure, ETeam team)
        {
            return figure != null && figure.Team == team;
        }

        bool isAnyAliveCheckers(IFigure[,] field, ETeam team)
        {
            int n = field.GetLength(0);
            int m = field.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i, j].Team == team) return true;
                }
            }
            return false;
        }

        bool IsTeamHasNonProhibitedTurn(IFigure[,] field, ETeam team)
        {
            int n = field.GetLength(0);
            int m = field.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (field[i,j]==null || field[i, j].Team != team) continue;
                    for (int ii = 0; ii < n; ii++)
                        for (int jj = 0; jj < m; jj++)
                        {
                            if (field[i, j].CanReachTile(new Point2(i, j),
                                new Point2(ii, jj), field) != EReachResult.none)
                            {
                                return true;
                            }
                        }
                }

            return false;
        }
    }
}