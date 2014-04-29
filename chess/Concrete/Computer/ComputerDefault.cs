using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    class ComputerDefault : Player
    {
        private enum EValue
        {
            Pawn = 1,
            Knight = 3,
            Bishop = 3,
            Rook = 5,
            Queen = 9,
            King = 0
        };
        private ITurnProcessor processor = new SimpleTurnProcessor();
        private int movesCount = 0;
        
        public ComputerDefault(ETeam team, int time): base(team,time) { }

        public override void AllowToDoTurn(Game game)
        {
            Move target = minimax(game.Field);
            game.TryToDoTurn(new Point2(target.From.X,target.From.Y),new Point2(target.To.X,target.To.Y));
            movesCount++;
        }

        private Move minimax(IFigure[,] field)
        {
            List<Move> moves = AvailableMoves(field,_team);
            int max = -999,
                target = 0;
            for (int i = 0; i < moves.Count; i++)
            {
                IFigure[,] tempField = (IFigure[,])field.Clone();
                performMove(moves[i].From,moves[i].To,tempField);
                int sum = valuesSum(tempField),
                    enemySum = 0;
                List<Move> enemyMoves = AvailableMoves(field,ETeam.Black == _team ? ETeam.White : ETeam.Black);
                for (int j = 0; j < enemyMoves.Count; j++)
                {
                    IFigure[,] enemyField = (IFigure[,])tempField.Clone();
                    performMove(enemyMoves[j].From,enemyMoves[j].To,enemyField);
                    enemySum += valuesSum(enemyField);
                }
                int result = sum+enemySum;
                if (max < result)
                {
                    max = result;
                    target = i;
                }
            }
            return moves[target];
        }

        #region Утилиты

        private void performMove(Point from, Point to, IFigure[,] field)
        {
            field[to.Y,to.X] = field[from.Y,from.X];
            field[from.Y,from.X] = null;
        }

        private void randomMove(Game game)
        {
            List<Move> moves = AvailableMoves(game.Field,_team);
            Random generator = new Random();
            int m = generator.Next(moves.Count);
            game.TryToDoTurn(new Point2(moves[m].From.X,moves[m].From.Y),new Point2(moves[m].To.X,moves[m].To.Y));
        }

        private int valuesSum(IFigure[,] field)
        {
            int result = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (field[i,j] != null)
                        result += (field[i,j].Team == _team? 1 : -1)*(int)Enum.Parse(typeof(EValue),field[i,j].Type.ToString());
            return result;
        }

        private List<Move> AvailableMoves(IFigure[,] field, ETeam team)
        {
            List<Move> result = new List<Move>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (field[i,j] == null || field[i,j].Team != team)
                        continue;
                    for (int k = 0; k < 8; k++)
                        for (int l = 0; l < 8; l++)
                            if (isMovePossible(new Point(j,i),new Point(l,k),field,team))
                                result.Add(new Move(new Point(j,i),new Point(l,k)));
                }
            return result;
        }

        private bool isMovePossible(Point from, Point to, IFigure[,] field, ETeam team)
        {
            return true;
            //return processor.CheckTurn(field,team,new Point2(from.X,from.Y),new Point2(to.X,to.Y)) != ETurnResult.prohibited;
        }

        #endregion
    }
}