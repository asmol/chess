using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public delegate void FigureChosenHandler(object sender, FigureChosenEventArgs e);

    public class FigureChosenEventArgs : EventArgs
    {
        public EPawnPromotion Figure;

        public FigureChosenEventArgs(EPawnPromotion figure)
        {
            Figure = figure;
        }
    }

    interface IFormPromotion
    {
        event FigureChosenHandler FigureChosen;
    }
}