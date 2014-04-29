using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Drawing;
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439

namespace chess
{
    public class Game:IOriginator
    {
<<<<<<< HEAD
        #region initialization
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439

        IForm _form;
        IFigure[,] _field;
        Player[] _players;
        ITurnProcessor _turnProcessor;

        Player _activePlayer;
        GameMemento _memento;
<<<<<<< HEAD
        List<IFigure> _movedKingsOrRooks;

        
=======

>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
        public IFigure[,] Field
        {
            get {return _field;}
        }

<<<<<<< HEAD
        public delegate void StateChangedHandler(IFigure[,] field, bool reverse, List<Turn> moves, int activePlayer, int currentMove);
        public event StateChangedHandler StateChanged;

        //абстрактная фабрика или 2 конструктора () и (string file) ?
        public Game( IForm form, Player[] players
            , ITurnProcessor turnProcessor)
        {
            _form = form; 
            _players = players;
            _turnProcessor = turnProcessor;
=======
        public delegate void StateChangedHandler(IFigure[,] field);
        public event StateChangedHandler StateChanged;

        //абстрактная фабрика или 2 конструктора () и (string file) ?
        public Game(IForm form, Player[] players
            , ITurnProcessor turnProcessor)
        {
            _form = form; _field = CreateStartFigures(); _players = players;
            _turnProcessor = turnProcessor;
            _activePlayer = _players[0];
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439

            StateChanged += form.DrawBoard;

            foreach (var p in _players)
            {
                form.FigureMoved += p.UserDidTurn;
                form.MoveCancelled += p.UserCancelledTurn;
                form.MoveRepeated += p.UserRepeatedTurn;

            }
<<<<<<< HEAD


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
                ChoosePawnPromotionDelegate pawnPromotionDelegate = new ChoosePawnPromotionDelegate(() => t.PawnPromotion ?? EPawnPromotion.Queen);
                EPawnPromotion? wasPawnPromotion;
                _turnProcessor.DoAllowedTurn(ref _field, t.From, t.To, pawnPromotionDelegate, ref _movedKingsOrRooks,out wasPawnPromotion); 
            }
            StateChanged(_field,false,_memento.Turns,Array.IndexOf(_players,_activePlayer),_memento.CurrentTurn);
        }

        public void StartGame()
        {
            _memento = new GameMemento();
            StateChanged(_field,false,_memento.Turns,Array.IndexOf(_players,_activePlayer),_memento.CurrentTurn);
            _activePlayer.AllowToDoTurn(this);
        }

        public void GetCopyOfGameState(out IFigure[,] field, out Point2 previousTurnFrom,
            out Point2 previousTurnTo, out List<IFigure> movedKingsOrRooks)
        {
            field = (IFigure[,])_field.Clone();
            GetPreviousTurn(out previousTurnFrom, out previousTurnTo);
            movedKingsOrRooks = new List<IFigure>(this._movedKingsOrRooks);
=======
        }

        

        public void RestoreState(GameMemento memento)
        {
            _memento = memento;
            _field = CreateStartFigures();
            _activePlayer = memento.CurrentTurn % 2 == 0 ? _players[0] : _players[1];
            for (int i = 0; i < _memento.CurrentTurn; i++)
            {
                ExecuteTurn(_memento.Turns[i]);
            }
            //StateChanged(_field,false);
        }

        void ExecuteTurn(Turn turn)
        {
            // как сюда добавить caretaker?
            IFigure figure = _field[turn.From.Y, turn.From.X];
            IFigure victim = _field[turn.To.Y, turn.To.X];
            if (victim != null)
            {
                Player nonActivePlayer = _activePlayer == _players[0] ? _players[1] : _players[0];
                nonActivePlayer.LostFigures.Add(victim);
            }
            _field[turn.To.Y, turn.To.X] = figure;
            _field[turn.From.Y, turn.From.X] = null;
            //тут еще что то нужно делать со временем
        }

        public void StartGame()
        {
            _memento = new GameMemento();
            StateChanged(_field);
            _activePlayer.AllowToDoTurn(this);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
        }

        public void TryToDoTurn(Point2 from, Point2 to)
        {
<<<<<<< HEAD
            Point2 prevTo, prevFrom;
            GetPreviousTurn(out prevFrom, out prevTo);
            bool isAllowed = _turnProcessor.IsAllowedTurn(_field, _activePlayer.Team, from, to,
                _movedKingsOrRooks, prevFrom, prevTo);

            if (!isAllowed)
            {
                StateChanged(_field,false,_memento.Turns,Array.IndexOf(_players,_activePlayer),_memento.CurrentTurn);
                _activePlayer.AllowToDoTurn(this);
                return;
            }

            EPawnPromotion? wasPawnPromotion = EPawnPromotion.Queen;
            ETurnResult result = _turnProcessor.DoAllowedTurn(
                ref _field, from, to, _form.ChoosePawnPromotion
                , ref  _movedKingsOrRooks, out wasPawnPromotion);
            AddTurnInMemento(from, to, 0, wasPawnPromotion);

            StateChanged(_field,false,_memento.Turns,Array.IndexOf(_players,_activePlayer),_memento.CurrentTurn);

            if (result == ETurnResult.normal)
=======

            ETurnResult result = _turnProcessor.CheckTurn(_field, _activePlayer.Team, from, to);

            if (result == ETurnResult.prohibited) { 
                StateChanged(_field); 
                _activePlayer.AllowToDoTurn(this); 
                return;
            }

            Turn newTurn = new Turn(from, to, 0);
            _memento.Turns.RemoveRange(_memento.CurrentTurn, _memento.Turns.Count - _memento.CurrentTurn);
            _memento.Turns.Add(newTurn);
            _memento.CurrentTurn++;
            ExecuteTurn(newTurn);

            StateChanged(_field);

            if (result == ETurnResult.normal || result == ETurnResult.check)
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            {
                ChangeActivePlayer();
                _activePlayer.AllowToDoTurn(this);
            }
            else
            {
<<<<<<< HEAD
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
            StateChanged(_field,false,_memento.Turns,Array.IndexOf(_players,_activePlayer),_memento.CurrentTurn);
        }

        public void RedoTurn()
        {
            if (_memento.CurrentTurn < _memento.Turns.Count)
            {
                _memento.CurrentTurn++;
                RestoreState(_memento);
                _activePlayer.AllowToDoTurn(this);
            }
            StateChanged(_field,false,_memento.Turns,Array.IndexOf(_players,_activePlayer),_memento.CurrentTurn);
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

       

        void AddTurnInMemento(Point2 from, Point2 to, int time, EPawnPromotion? pawnPromotion)
        {
            Turn newTurn = new Turn(from, to, 0, pawnPromotion);
            _memento.Turns.RemoveRange(_memento.CurrentTurn, _memento.Turns.Count - _memento.CurrentTurn);
            _memento.Turns.Add(newTurn);
            _memento.CurrentTurn++;
=======
              //  FinishGame(result);
            }
            
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
        }

        void ChangeActivePlayer()
        {
            if (_activePlayer == _players[0]) _activePlayer = _players[1];
            else _activePlayer = _players[0];
        }

        

<<<<<<< HEAD
=======
        public bool CheckIfTurnIsPossible(Point2 from, Point2 to)
        {
            return _turnProcessor.CheckTurn(_field, _activePlayer.Team, from, to) 
                != ETurnResult.prohibited;
        }
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439

        IFigure[,] CreateStartFigures()
        {
            return new IFigure[8, 8]
            {
                {new Rook(ETeam.Black),new Knight(ETeam.Black),new Bishop(ETeam.Black),new Queen(ETeam.Black),new King(ETeam.Black),new Bishop(ETeam.Black),new Knight(ETeam.Black),new Rook(ETeam.Black)},
                {new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black),new Pawn(ETeam.Black)},
<<<<<<< HEAD
                //{new King(ETeam.Black),null,null,null,null,null,null,null},
                //{null,null,null,null,null,null,null,null},
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
                {null,null,null,null,null,null,null,null},
                {null,null,null,null,null,null,null,null},
                {null,null,null,null,null,null,null,null},
                {null,null,null,null,null,null,null,null},
                {new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White),new Pawn(ETeam.White)},
                {new Rook(ETeam.White),new Knight(ETeam.White),new Bishop(ETeam.White),new Queen(ETeam.White),new King(ETeam.White),new Bishop(ETeam.White),new Knight(ETeam.White),new Rook(ETeam.White)}
            };
        }
<<<<<<< HEAD
        #endregion

        #region game state properties
        public GameMemento Memento { get { return _memento; } }
        public Player[] Players { get { return _players; } }
        #endregion
    }
}
=======

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

        public GameMemento Memento { get { return _memento; } }

        
    }
}
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
