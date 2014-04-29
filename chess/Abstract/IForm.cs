using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
<<<<<<< HEAD
    public enum EPawnPromotion {Queen,Bishop,Knight,Rook}

=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
    public delegate void FigureMovedHandler(object sender, FigureMovedEventArgs e);
    public delegate void MoveCancelledHandler(object sender, EventArgs e);
    public delegate void MoveRepeatedHandler(object sender, EventArgs e);

<<<<<<< HEAD
    public delegate EPawnPromotion ChoosePawnPromotionDelegate();

=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
    public class FigureMovedEventArgs : EventArgs
    {
        public Point From {get; set;}
        public Point To {get; set;}

        public FigureMovedEventArgs(Point from, Point to)
        {
            From = from;
            To = to;
        }
    }

    public interface IForm
    {
        event FigureMovedHandler FigureMoved;
        event MoveCancelledHandler MoveCancelled;
        event MoveRepeatedHandler MoveRepeated;
<<<<<<< HEAD
        void DrawBoard(IFigure[,] figures, bool reverse, List<Turn> moves, int activePlayer, int currentMove);
        void UpdateData(Player[] players, int activePlayer, int currentMove);
        EPawnPromotion ChoosePawnPromotion();
=======
        void DrawBoard(IFigure[,] figures);
        void UpdateData(Player[] players, int activePlayer, int currentMove);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
    }
}