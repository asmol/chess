using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public class Game:IOriginator
    {
        #region initialization

        IForm _form;
        IFigure[,] _field;
        Player[] _players;
        ITurnProcessor _turnProcessor;

        Player _activePlayer;
        GameMemento _memento;
        List<IFigure> _movedKingsOrRooks;

        
        public IFigure[,] Field
        {
            get {return _field;}
        }

        public delegate void StateChangedHandler(IFigure[,] field);
        public event StateChangedHandler StateChanged;

        //абстрактная фабрика или 2 конструктора () и (string file) ?
        public Game( IForm form, Player[] players
            , ITurnProcessor turnProcessor)
        {
            _form = form; 
            _players = players;
            _turnProcessor = turnProcessor;

            StateChanged += form.DrawBoard;

            foreach (var p in _players)
            {
                form.FigureMoved += p.UserDidTurn;
                form.MoveCancelled += p.UserCancelledTurn;
                form.MoveRepeated += p.UserRepeatedTurn;

            }


            _memento = new GameMemento();
            ClearGameState();
        }
        #endregion

        #region public methods
        public void RestoreState(GameMemento memento)
        {
            _memento = memento;
            ClearGameState();
            _activePlayer = memento.CurrentTurn % 2 == 0 ? _players[0] : _players[1];
            for (int i = 0; i < _memento.CurrentTurn; i++)
            {
                Turn t = _memento.Turns[i];
                _turnProcessor.DoAllowedTurn(_field, t.From, t.To, EmptyDelegate, ref _movedKingsOrRooks); 
            }
            StateChanged(_field);
        }

        public void StartGame()
        {
            _memento = new GameMemento();
            StateChanged(_field);
            _activePlayer.AllowToDoTurn(this);
        }

        public void GetCopyOfGameState(out IFigure[,] field, out Point2 previousTurnFrom,
            out Point2 previousTurnTo, out List<IFigure> movedKingsOrRooks)
        {
            field = (IFigure[,])_field.Clone();
            GetPreviousTurn(out previousTurnFrom, out previousTurnTo);
            movedKingsOrRooks = new List<IFigure>(this._movedKingsOrRooks);
        }

        public void TryToDoTurn(Point2 from, Point2 to)
        {
            Point2 prevTo, prevFrom;
            GetPreviousTurn(out prevFrom, out prevTo);
            bool isAllowed = _turnProcessor.IsAllowedTurn(_field, _activePlayer.Team, from, to,
                _movedKingsOrRooks, prevFrom, prevTo);

            if (!isAllowed)
            {
                StateChanged(_field);
                _activePlayer.AllowToDoTurn(this);
                return;
            }

            AddTurnInMemento(from, to, 0);
            ETurnResult result = _turnProcessor.DoAllowedTurn(_field, from, to, EmptyDelegate, ref  _movedKingsOrRooks);

            StateChanged(_field);

            if (result == ETurnResult.normal)
            {
                ChangeActivePlayer();
                _activePlayer.AllowToDoTurn(this);
            }
            else
            {
                //  FinishGame(result);
            }

        }

        public void CancelTurn()
        {
            if (_memento.CurrentTurn > 0)
            {
                _memento.CurrentTurn--;
                RestoreState(_memento);
                _activePlayer.AllowToDoTurn(this);
            }
        }

        public void RedoTurn()
        {
            if (_memento.CurrentTurn < _memento.Turns.Count)
            {
                _memento.CurrentTurn++;
                RestoreState(_memento);
                _activePlayer.AllowToDoTurn(this);
            }
        }

        #endregion

        #region auxiliary methods
        void ClearGameState()
        {
            _movedKingsOrRooks = new List<IFigure>();
            _field = CreateStartFigures();
            _activePlayer = _players[0];
        }

        void GetPreviousTurn(out Point2 previousTurnFrom,
            out Point2 previousTurnTo)
        {
            Turn previousTurn = _memento.CurrentTurn > 0 ? _memento.Turns[_memento.CurrentTurn - 1] : null;
            previousTurnFrom = previousTurn == null ? new Point2(0, 0) : previousTurn.From;
            previousTurnTo = previousTurn == null ? new Point2(0, 0) : previousTurn.To;
        }

       

        void AddTurnInMemento(Point2 from, Point2 to, int time)
        {
            Turn newTurn = new Turn(from, to, 0);
            _memento.Turns.RemoveRange(_memento.CurrentTurn, _memento.Turns.Count - _memento.CurrentTurn);
            _memento.Turns.Add(newTurn);
            _memento.CurrentTurn++;
        }

        EPawnPromotion EmptyDelegate()
        {
            return EPawnPromotion.Rook;
        }

        void ChangeActivePlayer()
        {
            if (_activePlayer == _players[0]) _activePlayer = _players[1];
            else _activePlayer = _players[0];
        }

        


        IFigure[,] CreateStartFigures()
        {
            return new IFigure[8, 8]
            {
                {new Rook(ETeam.Black),new Knight(ETeam.Black),new Bishop(ETeam.Black),new Queen(ETeam.Black),new King(ETeam.Black),new Bishop(ETeam.Black),new Knight(ETeam.Black),new Rook(ETeam.Black)},
                {new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black)},
                {null,null,null,null,null,null,null,null},
                {null,null,null,null,null,null,null,null},
                {null,null,null,null,null,null,null,null},
                {null,null,null,null,null,null,null,null},
                {new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White)},
                {new Rook(ETeam.White),new Knight(ETeam.White),new Bishop(ETeam.White),new Queen(ETeam.White),new King(ETeam.White),new Bishop(ETeam.White),new Knight(ETeam.White),new Rook(ETeam.White)}
            };
        }
        #endregion

        #region game state properties
        public GameMemento Memento { get { return _memento; } }
        public Player[] Players { get { return _players; } }
        #endregion
    }
}
