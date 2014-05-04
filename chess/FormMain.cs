using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace chess
{
    public partial class FormMain : Form, IForm
    {
        private readonly FormPreferences preferences = new FormPreferences();
        private readonly FormPromotion promotion = new FormPromotion();

        private readonly Size maxSize = new Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
        private const int heightCorrection = 21;

        private Graphics canvas, screen;
        private Bitmap bitmap;
        private IPainter painter;

        private FormWindowState lastWindowState = FormWindowState.Normal;
        private AreaF field;

        private IFigure[,] figures;
        private bool boardReversed;
        private List<Point> selectedCells = new List<Point>();
        private Point selectedFigure = AreaF.Empty;
        private EPawnPromotion? promotionFigure;

        public FormMain()
        {
            InitializeComponent();

            Size oldClientSize = ClientSize;
            ClientSize = maxSize;
            screen = PBoard.CreateGraphics();
            bitmap = new Bitmap(ClientSize.Width,ClientSize.Height);
            canvas = Graphics.FromImage(bitmap);
            canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            painter = new PainterDefault(PBoard.BackColor);
            ClientSize = new Size(oldClientSize.Width,oldClientSize.Height-heightCorrection);
            MaximumSize = maxSize;

            promotion.FigureChosen += promotionFigureChosen;
        }

        #region События формы

        public event FigureMovedHandler FigureMoved;
        public event MoveCancelledHandler MoveCancelled;
        public event MoveRepeatedHandler MoveRepeated;

        #endregion
        #region Обработчики событий формы

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width-Size.Width)/2,(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height-Size.Height)/2);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState != lastWindowState)
            {
                draw();
                scrollHistoryDown();
                lastWindowState = WindowState;
            }
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            draw();
            scrollHistoryDown();
        }

        #endregion
        #region Обработчики событий компонентов

        private void PBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (field.InArea(e.Location))
            {
                Point selectedCell = new Point((int)Math.Floor((e.X-field.Position.X)/(field.Size.Width/8)),(int)Math.Floor((e.Y-field.Position.Y)/(field.Size.Height/8)));
                if (selectedFigure == AreaF.Empty)
                {
                    if (figures[!boardReversed ? selectedCell.Y : AreaF.ReverseCell(selectedCell.Y),!boardReversed ? selectedCell.X : AreaF.ReverseCell(selectedCell.X)] != null)
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
                        FigureMoved(this,new FigureMovedEventArgs(!boardReversed ? selectedCells[0] : AreaF.ReverseCell(selectedCells[0]),!boardReversed ? selectedCells[1] : AreaF.ReverseCell(selectedCells[1])));
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

        private void MIPreferences_Click(object sender, EventArgs e)
        {
            preferences.ShowDialog();
        }

        private void MIAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("","About");
        }

        private void TSBUndo_Click(object sender, EventArgs e)
        {
            MoveCancelled(this,new EventArgs());
        }

        private void TSBRedo_Click(object sender, EventArgs e)
        {
            MoveRepeated(this,new EventArgs());
        }

        private void TSBPreferences_Click(object sender, EventArgs e)
        {
            preferences.ShowDialog();
        }

        #endregion
        #region Обработчики событий игры

        public void DrawBoard(IFigure[,] figures, bool reverse, List<Turn> moves, int activePlayer, int currentMove)
        {
            if (reverse)
                boardReversed = !boardReversed;
            selectedCells = detectChanges(figures);
            this.figures = (IFigure[,])figures.Clone();
            draw();

            invokeEx(this,new Action(delegate()
                {
                    SBPMove.Text = "Move #"+((currentMove/2)+1)+": "+(activePlayer == 0 ? "white" : "black")+"’s turn";
                    TBHistory.Text = History.GetHistory(moves,currentMove);
                    scrollHistoryDown();

                    TSBUndo.Enabled = currentMove > 0;
                    TSBRedo.Enabled = currentMove != moves.Count;
                    MIUndo.Enabled = TSBUndo.Enabled;
                    MIRedo.Enabled = TSBRedo.Enabled;
                }
                ));
            
        }

        public void UpdateData(Player[] players, int activePlayer)
        {
            if (activePlayer == 0)
            {
                TimeSpan white = TimeSpan.FromSeconds(players[0].Time);
                invokeEx(this,new Action(delegate() {SBPWhite.Text = "White: "+white.Minutes+":"+white.Seconds;}));
            }
            else
            {
                TimeSpan black = TimeSpan.FromSeconds(players[1].Time);
                invokeEx(this,new Action(delegate() {SBPBlack.Text = "Black: "+black.Minutes+":"+black.Seconds;}));
            }
        }

        public EPawnPromotion ChoosePawnPromotion()
        {
            promotionFigure = null;
            invokeEx(this,new Action(delegate() {promotion.ShowDialog();}));
            while (promotionFigure == null);
            return promotionFigure ?? EPawnPromotion.Queen;
        }

        /* TODO:
        public void FinishGame(EFinishGameReason, Player winner, Player loser)
        {

        }*/

        #endregion
        #region Обработчики прочих событий

        private void promotionFigureChosen(object sender, FigureChosenEventArgs e)
        {
            promotionFigure = e.Figure;
        }

        #endregion
        #region Основные методы

        private void draw()
        {
            if (this.figures == null)
                return;
            field = painter.Draw(canvas,PBoard.Size,figures,selectedCells,boardReversed);
            screen.DrawImage(bitmap,new Point(0,0));
        }

        private List<Point> detectChanges(IFigure[,] figures)
        {
            List<Point> result = new List<Point>();
            if (this.figures != null)
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        if (!areFiguresEqual(this.figures[i,j],figures[i,j]))
                            result.Add(!boardReversed ? new Point(j,i) : AreaF.ReverseCell(new Point(j,i)));
            return result;
        }

        #endregion
        #region Вспомогательные методы

        delegate void Action();

        private void invokeEx(Control target, Action action)
        {
            if (target.InvokeRequired)
                target.Invoke((MethodInvoker)delegate() {invokeEx(target,action);});
            else
                action();
        }

        private bool areFiguresEqual(IFigure one, IFigure two)
        {
            if (one == two || (one != null && two != null && one.Team == two.Team && one.Type == two.Type))
                return true;
            return false;
        }

        private void scrollHistoryDown()
        {
            TBHistory.SelectionStart = TBHistory.TextLength;
            TBHistory.ScrollToCaret();
        }

        #endregion
    }
}