using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    public delegate void FigureMovedHandler(object sender, FigureMovedEventArgs e);
    public delegate void MoveCancelledHandler(object sender, EventArgs e);
    public delegate void MoveRepeatedHandler(object sender, EventArgs e);

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
        void DrawBoard(IFigure[,] figures, List<Turn> moves, int currentMove);
        void UpdateData(Player[] players, int activePlayer, int currentMove);
    }
}