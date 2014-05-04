using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace chess
{
    public class Player
    {

        protected ETeam _team;
        protected int _timeLeft;
        protected int _timeStart;

        protected Point2? _lastUsersTurnTo=null, _lastUsersTurnFrom=null;
        protected bool _userCancelledTurn = false;
        protected bool _userRepeatedTurn = false;

        public Player(ETeam team,  int startTime)
        {
            _team = team;
            _timeLeft = startTime;
            _timeStart = startTime;
        }

        //потокобезопасность, как заблокировать эти 3 переменные до выполнения команды?
        public virtual void AllowToDoTurn(Game game)
        {
            ClearUserActions();

            while (!UserDidSomeAction())
            {
                Thread.Sleep(10);
            }
            RunCommand(game);
        }

        
        protected void RunCommand(Game game)
        {
            
            if (_userCancelledTurn)
            {
                game.CancelTurn();
            }
            else if (_userRepeatedTurn)
            {
                game.RedoTurn();
            }
            else
            {
                game.TryToDoTurn((Point2)_lastUsersTurnFrom, (Point2)_lastUsersTurnTo);
            }
        }

        void ClearUserActions()
        {
            _lastUsersTurnTo = null;
            _lastUsersTurnFrom = null;
            _userCancelledTurn = false;
            _userRepeatedTurn = false;
        }

        bool UserDidSomeAction()
        {
            return (_lastUsersTurnFrom != null && _lastUsersTurnTo != null) || _userCancelledTurn 
                || _userRepeatedTurn;
        }

        public void UserDidTurn( object sender, FigureMovedEventArgs e)
        {
            _lastUsersTurnFrom = new Point2( e.From.X, e.From.Y);
            _lastUsersTurnTo = new Point2(e.To.X, e.To.Y);
        }

        public void UserCancelledTurn(object sender, EventArgs e)
        {
            _userCancelledTurn = true;
        }
        public void UserRepeatedTurn(object sender, EventArgs e)
        {
            _userRepeatedTurn = true;
        }
        public ETeam Team { get { return _team; } }
        public int StartTime { get { return _timeStart; } }
        public int Time { get { return _timeLeft; } }
    }
}
