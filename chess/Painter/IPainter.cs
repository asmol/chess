using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace chess
{
    interface IPainter
    {
        AreaF Draw(Graphics canvas, Size clientSize, IFigure[,] figures, List<Point> selectedCells, bool boardReversed = false);
    }
}