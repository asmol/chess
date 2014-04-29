using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    interface IPainter
    {
<<<<<<< HEAD
        AreaF Draw(Graphics canvas, Size clientSize, IFigure[,] figures, List<Point> selectedCells, bool boardReversed = false);
=======
        AreaF Draw(Graphics canvas, Size clientSize, IFigure[,] figures, List<Point> selectedCells);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
    }
}