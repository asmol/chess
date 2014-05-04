using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace chess
{
    class SimpleTurnProcessor:ITurnProcessor
    {
        public bool IsCapture(IFigure[,] field, Point2 from, Point2 to)
        {
            return field[to.Y,to.X] != null && (field[from.Y,from.X].Team != field[to.Y,to.X].Team);
        }

        public bool IsCheck(IFigure[,] field, ETeam enemy)
        {
            return IsPointUnderAttack(field,FindKing(field,EnemyTeam(enemy)),enemy);
        }

        public ETeam EnemyTeam(ETeam team)
        {
            return team == ETeam.White ? ETeam.Black : ETeam.White;
        }

        bool IsFigureBelongsTeam(IFigure figure, ETeam team)
        {
            return figure != null && figure.Team == team;
        }

        bool IsFigureCanReachTile(IFigure[,] field, Point2 from, Point2 to)
        {
            return field[from.Y, from.X].CanReachTile(
                new Point(from.X, from.Y), new Point(to.X, to.Y), field
                );
        }

        public bool IsKingsideCastling(int fromX, int toX)
        {
            return fromX-toX == -2;
        }

        public bool IsCastling(IFigure figure,  Point2 from, Point2 to)
        {
            return figure.Type == EType.King && Math.Abs(from.X - to.X) == 2;
        }

        bool IsProhibitedCastling(IFigure[,] field, Point2 from, Point2 to, List<IFigure> movedKingsOrRooks)
        {
            IFigure figure = field[from.Y, from.X];
            ETeam enemy = figure.Team == ETeam.Black ? ETeam.White : ETeam.Black;
            // castling
            if (IsCastling(figure, from, to))
            {
                if (IsPointUnderAttack(field, from, enemy) ||
                    IsPointUnderAttack(field, new Point2((from.X + to.X) / 2, from.Y), enemy))
                {
                    return true;
                }
                IFigure rook = to.X > from.X ?
                    field[to.Y, field.GetLength(1) - 1] :
                    field[to.Y, 0];

                if (movedKingsOrRooks.Contains(rook) || movedKingsOrRooks.Contains(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPassantCapture(IFigure[,] field,  Point2 from, Point2 to)
        {
            IFigure figure = field[from.Y, from.X];
            return figure.Type == EType.Pawn && to.X != from.X && field[to.Y, to.X] == null;
        }

        bool IsProhibitedPassantCapture(IFigure[,] field, Point2 from, Point2 to, Point2 lastEnemyTurnFrom, Point2 lastEnemyTurnTo)
        {
            //if pawn kills empty field it's passant capture
            if (IsPassantCapture(field, from,to))
            {
                IFigure previouslyMovedByEnemy = field[lastEnemyTurnTo.Y, lastEnemyTurnTo.X];
                IFigure victim = field[from.Y, to.X];
                if (
                    Math.Abs(lastEnemyTurnFrom.Y - lastEnemyTurnTo.Y) == 2
                    && previouslyMovedByEnemy.Type == EType.Pawn
                    && victim == previouslyMovedByEnemy
                    )
                {
                    //everything ok
                }
                else return true;
            }
            return false;
        }

        public bool IsAllowedTurnLight(IFigure[,] field, ETeam team, Point2 from, Point2 to)
        {
            if (IsFigureCanReachTile(field,from,to))
            {
                IFigure[,] newField = MimicTurn(field,from,to);
                if (IsPointUnderAttack(newField,FindKing(newField,team),EnemyTeam(team)))
                    return false;
                return true;
            }
            return false;
        }

        public List<Point2> FiguresOfType(IFigure[,] field, EType type, ETeam team)
        {
            List<Point2> result = new List<Point2>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (field[i,j] != null && field[i,j].Type == type && field[i,j].Team == team)
                        result.Add(new Point2(j,i));
            return result;
        }

        public bool IsAllowedTurn(IFigure[,] field, ETeam team, Point2 from, Point2 to
            , List<IFigure> movedKingsOrRooks, Point2 lastEnemyTurnFrom, Point2 lastEnemyTurnTo)
        {
            IFigure figure = field[from.Y, from.X];
            ETeam enemy = team == ETeam.Black ? ETeam.White : ETeam.Black;

            //main checks + special cases
            if( ! IsFigureBelongsTeam(figure, team)
                || ! IsFigureCanReachTile(field, from,to)
                || IsProhibitedCastling(field, from, to, movedKingsOrRooks)
                || IsProhibitedPassantCapture(field, from, to, lastEnemyTurnFrom, lastEnemyTurnTo))
            {
                return false;
            }

            //if king in check after doing turn
            IFigure[,] newField = MimicTurn(field, from, to); // "field" won't be changed
            
            Point2 kingPoint = FindKing(newField, team);
            if (IsPointUnderAttack(newField, kingPoint, enemy))
            {
                return false;
            }


            return true;
        }

        bool IsPawnPromotion(IFigure figure, Point2 to, int fieldVerticalSize){
            return figure.Type == EType.Pawn && (to.Y == 0 || to.Y == fieldVerticalSize-1);
        }

        public ETurnResult DoAllowedTurn(ref IFigure[,] field, Point2 from, Point2 to
            , ChoosePawnPromotionDelegate ChoosePawnPromotion, ref List<IFigure> movedKingsOrRooks,
            out EPawnPromotion? wasPawnPromotion)
        {
            //1. do turn
            IFigure figure = field[from.Y, from.X];
            if (figure.Type == EType.King || figure.Type == EType.Rook)
            {
                if(!movedKingsOrRooks.Contains(figure))
                    movedKingsOrRooks.Add(figure);
            }
            field = MimicTurn(field, from, to);

            wasPawnPromotion = null;
            if (IsPawnPromotion(figure, to, field.GetLength(0)))
            {
                wasPawnPromotion = ChoosePawnPromotion();
                IFigure pawn = field[to.Y, to.X];
                switch (wasPawnPromotion)
                {
                    case EPawnPromotion.Bishop: field[to.Y, to.X] = new Bishop(pawn.Team); break;
                    case EPawnPromotion.Knight: field[to.Y, to.X] = new Knight(pawn.Team); break;
                    case EPawnPromotion.Queen: field[to.Y, to.X] = new Queen(pawn.Team); break;
                    case EPawnPromotion.Rook: field[to.Y, to.X] = new Rook(pawn.Team); break;
                }
                
            }

            //2. define turn result
            ETeam enemy = figure.Team == ETeam.Black ? ETeam.White : ETeam.Black;
            if (IsTeamHasNonProhibitedTurn(field, figure.Team, from, to))
            {
                return ETurnResult.normal;
            }
            else
            {
                Point2 kingPoint = FindKing(field, figure.Team);

                if (IsPointUnderAttack(field, kingPoint, enemy)) 
                    return ETurnResult.checkmate;
                else 
                    return ETurnResult.stalemate;
            }
        }

        /*
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
        */
        IFigure[,] MimicTurn(IFigure[,] field, Point2 from, Point2 to)
        {
            //!! not full mimic, only for check if king under attack after
            IFigure[,] newField = (IFigure[,])field.Clone();

            IFigure figure = newField[from.Y, from.X];
            newField[from.Y, from.X] = null;
            newField[to.Y, to.X] = figure;
            if(IsPassantCapture(field, from, to)) 
            {
                newField[from.Y, to.X] = null;
            }
            if(IsCastling(figure, from, to))
            {
                Point2 moveRookFrom = from.X > to.X ? 
                       new Point2(0, from.Y) 
                    :  new Point2(field.GetLength(1)-1, from.Y);

                //newField[from.Y, (to.X+to.Y)/2] = newField[moveRookFrom.Y, moveRookFrom.X];
                newField[from.Y, (from.X+to.X)/2] = newField[moveRookFrom.Y, moveRookFrom.X]; // fixed
                newField[moveRookFrom.Y, moveRookFrom.X]=null;
            }
            //pawn promotion is not avoiding king check if it is
            return newField;
        }

        public IFigure[,] SimulateMove(IFigure[,] field, Point2 from, Point2 to, EPawnPromotion? promotion)
        {
            IFigure[,] newField = (IFigure[,])field.Clone();
            IFigure figure = newField[from.Y,from.X];

            newField[from.Y,from.X] = null;
            newField[to.Y,to.X] = figure;

            if (IsPassantCapture(field,from,to))
                newField[from.Y,to.X] = null;
            if (IsCastling(figure,from,to))
            {
                Point2 moveRookFrom = from.X > to.X ? new Point2(0, from.Y) : new Point2(field.GetLength(1)-1,from.Y);
                newField[from.Y,(from.X+to.X)/2] = newField[moveRookFrom.Y,moveRookFrom.X];
                newField[moveRookFrom.Y,moveRookFrom.X] = null;
            }
            if (promotion != null)
            {
                ETeam team = newField[to.Y,to.X].Team;
                IFigure replacement = new Queen(team);
                switch (promotion)
                {
                    case EPawnPromotion.Rook: replacement = new Rook(team); break;
                    case EPawnPromotion.Bishop: replacement = new Bishop(team); break;
                    case EPawnPromotion.Knight: replacement = new Knight(team); break;
                }
                newField[to.Y,to.X] = replacement;
            }
            return newField;
        }

        bool IsPointUnderAttack(IFigure[,] field, Point2 point, ETeam enemy)
        {

            int n = field.GetLength(0);
            int m = field.GetLength(1);

            for(int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    IFigure f = field[i, j];
                    if (f!= null && f.Team == enemy && f.CanReachTile(new Point(j, i)
                        , new Point(point.X, point.Y), field))
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

        public bool IsTeamHasNonProhibitedTurn(IFigure[,] field, ETeam team, Point2 prevFrom, Point2 prevTo)
        {
            int n = field.GetLength(0);
            int m = field.GetLength(1);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    for (int ii = 0; ii < n; ii++)
                        for (int jj = 0; jj < m; jj++)
                        {
                            if (IsAllowedTurn(field, team, new Point2(j, i), new Point2(jj, ii)
                                , new List<IFigure>(), prevFrom, prevTo ))
                            {
                                return true;
                            }
                        }
                }

            return false;
        }
    }
}