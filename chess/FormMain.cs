using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace chess
{
    public partial class FormMain : Form, IForm
    {
        private readonly Size maxClientSize = new Size(1920, 1080);
        private const int heightCorrection = 21;

        private Graphics canvas, screen;
        private Bitmap bitmap;
        private IPainter painter;

        private FormWindowState lastWindowState = FormWindowState.Normal;
        private AreaF field;
        private IFigure[,] figures;
        private List<Point> selectedCells = new List<Point>();
        private Point selectedFigure = AreaF.Empty;

        public FormMain()
        {
            InitializeComponent();

            Size oldClientSize = ClientSize;
            ClientSize = maxClientSize;
            screen = CreateGraphics();
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            canvas = Graphics.FromImage(bitmap);
            canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            painter = new PainterDefault();
            ClientSize = new Size(oldClientSize.Width, oldClientSize.Height - heightCorrection);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState != lastWindowState)
            {
                draw();
                lastWindowState = WindowState;
            }
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            draw();
        }

        private void FormMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (field.InArea(e.Location))
            {
                Point selectedCell = new Point((int)Math.Floor((e.X - field.Position.X) / (field.Size.Width / 8)), (int)Math.Floor((e.Y - field.Position.Y) / (field.Size.Height / 8)));
                if (selectedFigure == AreaF.Empty)
                {
                    if (figures[selectedCell.Y, selectedCell.X] != null)
                    {
                        selectedFigure = selectedCell;
                        selectedCells.Clear();
                        selectedCells.Add(selectedCell);
                        draw();
                    }
                }
                else
                {
                    selectedFigure = AreaF.Empty;
                    selectedCells.Add(selectedCell);
                    if (FigureMoved != null)
                        FigureMoved(this, new FigureMovedEventArgs(selectedCells[0],selectedCells[1]));
                }
            }
        }

        private void MIUndo_Click(object sender, EventArgs e)
        {
            MoveCancelled(this,new EventArgs());
        }

        private void MIRedo_Click(object sender, EventArgs e)
        {
            MoveRepeated(this,new EventArgs());
        }

        private void draw()
        {
            if (canvas == null)
                return;
            field = painter.Draw(canvas,new Size(ClientSize.Width,ClientSize.Height-heightCorrection),figures,selectedCells);
            screen.DrawImage(bitmap,new Point(0,0));
        }

        public event FigureMovedHandler FigureMoved;
        public event MoveCancelledHandler MoveCancelled;
        public event MoveRepeatedHandler MoveRepeated;

        private List<Point> detectChanges(IFigure[,] figures)
        {
            List<Point> result = new List<Point>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (this.figures[i,j] != figures[i,j])
                        result.Add(new Point(j,i));
            return result;
        }

        public void DrawBoard(IFigure[,] figures)
        {
            if (this.figures != null)
                selectedCells = detectChanges(figures);
            this.figures = (IFigure[,])figures.Clone();
            draw();
        }

        public void UpdateData(Player[] players, int activePlayer, int currentMove)
        {
            TimeSpan white = TimeSpan.FromSeconds(players[0].Time),
                black = TimeSpan.FromSeconds(players[1].Time);
            SBPMove.Text = "Move #"+currentMove+": "+(activePlayer == 0 ? "white" : "black")+"'s turn";
            SBPWhite.Text = "White: "+white.Minutes+":"+white.Seconds;
            SBPBlack.Text = "Black: "+black.Minutes+":"+black.Seconds;
        }
    }
}