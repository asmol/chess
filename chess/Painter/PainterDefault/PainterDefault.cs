using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using chess.Painter.PainterDefault;

namespace chess
{
    class PainterDefault : IPainter
    {
        private readonly Color background;
        private readonly Brush white = new SolidBrush(Color.FromArgb(255,206,158)),
            black = new SolidBrush(Color.FromArgb(209,139,71));
        private readonly Pen border = new Pen(Color.FromArgb(209,139,71)),
            cell = new Pen(Brushes.Black);
        private bool firstDrawn;

        private float cellSize, halfCellSize;
        private PointF startPoint, fieldStartPoint;

        public PainterDefault(Color background)
        {
            this.background = background;
            border.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            cell.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
        }

        public AreaF Draw(Graphics canvas, Size clientSize, IFigure[,] figures, List<Point> selectedCells, bool boardReversed = false)
        {
            cellSize = (float)Math.Min(clientSize.Width,clientSize.Height)/9;
            halfCellSize = cellSize/2;
            startPoint = new PointF(Math.Abs(clientSize.Width-clientSize.Height)/2-(firstDrawn ? 0 : 10),0);
            firstDrawn = true;
            if (clientSize.Width < clientSize.Height)
                startPoint = new PointF(startPoint.Y,startPoint.X);
            fieldStartPoint = new PointF(startPoint.X+halfCellSize,startPoint.Y+halfCellSize);
            canvas.Clear(background);
            AreaF result = drawBoard(canvas,selectedCells,boardReversed);
            drawFigures(canvas,figures,boardReversed);
            return result;
        }

        private AreaF drawBoard(Graphics canvas, List<Point> selectedCells, bool reversed)
        {
            float boardSize = cellSize*9;
            canvas.FillRectangle(white,startPoint.X,startPoint.Y,boardSize,boardSize);
            float fieldSize = cellSize*8;
            Bitmap digits = !reversed ? Resources.Digits : Resources.DigitsReversed,
                letters = !reversed ? Resources.Letters : Resources.LettersReversed;
            canvas.DrawImage(letters,fieldStartPoint.X,startPoint.Y,fieldSize,halfCellSize);
            canvas.DrawImage(letters,fieldStartPoint.X,startPoint.Y+fieldSize+halfCellSize,fieldSize,halfCellSize);
            canvas.DrawImage(digits,startPoint.X,fieldStartPoint.Y,halfCellSize,fieldSize);
            canvas.DrawImage(digits,startPoint.X+fieldSize+halfCellSize,fieldStartPoint.Y,halfCellSize,fieldSize);
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    canvas.FillRectangle(reversed ? black : white,j*cellSize+fieldStartPoint.X,i*cellSize+fieldStartPoint.Y,cellSize,cellSize);
                    if (j != 7)
                        reversed = !reversed;
                }
            border.Width = cellSize/32;
            AreaF result = new AreaF(new PointF(fieldStartPoint.X,fieldStartPoint.Y),new SizeF(fieldSize,fieldSize));
            canvas.DrawRectangle(border,result.Position.X,result.Position.Y,result.Size.Width,result.Size.Height);
            cell.Width = border.Width;
            foreach (Point selectedCell in selectedCells)
                canvas.DrawRectangle(cell,selectedCell.X*cellSize+fieldStartPoint.X,selectedCell.Y*cellSize+fieldStartPoint.Y,cellSize,cellSize);
            return result;
        }

        private void drawFigures(Graphics canvas, IFigure[,] figures, bool boardReversed)
        {
            for (int i = 0; i < figures.GetLength(0); i++)
                for (int j = 0; j < figures.GetLength(1); j++)
                {
                    if (figures[i,j] == null)
                        continue;
                    Bitmap figure = Resources.PawnWhite;
                    switch (figures[i,j].Team)
                    {
                        case ETeam.White:
                            switch (figures[i,j].Type)
                            {
                                case EType.Knight: figure = Resources.KnightWhite; break;
                                case EType.Bishop: figure = Resources.BishopWhite; break;
                                case EType.Rook: figure = Resources.RookWhite; break;
                                case EType.Queen: figure = Resources.QueenWhite; break;
                                case EType.King: figure = Resources.KingWhite; break;
                            }
                            break;
                        case ETeam.Black:
                            switch (figures[i,j].Type)
                            {
                                case EType.Pawn: figure = Resources.PawnBlack; break;
                                case EType.Knight: figure = Resources.KnightBlack; break;
                                case EType.Bishop: figure = Resources.BishopBlack; break;
                                case EType.Rook: figure = Resources.RookBlack; break;
                                case EType.Queen: figure = Resources.QueenBlack; break;
                                case EType.King: figure = Resources.KingBlack; break;
                            }
                            break;
                    }
                    canvas.DrawImage(figure,(!boardReversed ? j : AreaF.ReverseCell(j))*cellSize+fieldStartPoint.X,(!boardReversed ? i : AreaF.ReverseCell(i))*cellSize+fieldStartPoint.Y,cellSize,cellSize);
                }
        }
    }
}