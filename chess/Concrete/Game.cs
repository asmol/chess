using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public class Game:IOriginator
    {

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
        public Game(IForm form, Player[] players
            , ITurnProcessor turnProcessor)
        {
            _form = form; _field = CreateStartFigures(); _players = players;
            _turnProcessor = turnProcessor;
            _activePlayer = _players[0];

            StateChanged += form.DrawBoard;

            foreach (var p in _players)
            {
                form.FigureMoved += p.UserDidTurn;
                form.MoveCancelled += p.UserCancelledTurn;
                form.MoveRepeated += p.UserRepeatedTurn;

            }
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
        }

        public void TryToDoTurn(Point2 from, Point2 to)
        {
            Turn previousTurn = _memento.CurrentTurn>0? _memento.Turns[_memento.CurrentTurn-1] : null;
            Point2 prevFrom = previousTurn == null ? new Point2(0, 0) : previousTurn.From;
            Point2 prevTo = previousTurn == null ? new Point2(0, 0) : previousTurn.To;
            bool isAllowed = _turnProcessor.IsAllowedTurn(_field, _activePlayer.Team, from, to,
                _movedKingsOrRooks, prevFrom, prevTo);

            if (! isAllowed) { 
                StateChanged(_field); 
                _activePlayer.AllowToDoTurn(this); 
                return;
            }

            AddTurnInMemento(from, to, 0);
            ETurnResult result =  _turnProcessor.DoAllowedTurn(_field, from, to, EmptyDelegate, ref  _movedKingsOrRooks);

            StateChanged(_field);

            if (result == ETurnResult.normal )
            {
                ChangeActivePlayer();
                _activePlayer.AllowToDoTurn(this);
            }
            else
            {
              //  FinishGame(result);
            }
            
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
