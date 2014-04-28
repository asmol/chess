using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using chess.Concrete.SDFRepository;
using chess.Concrete.SDFRepository.GamesDataSetTableAdapters;
namespace chess
{
    class SDFRepository:IRepository
    {
        GameTableAdapter _gameAdapter = new GameTableAdapter();
        PlayerTableAdapter _playerAdapter = new PlayerTableAdapter();
        GameTurnTableAdapter _gameTurnAdapter = new GameTurnTableAdapter();
        GamesDataSet.GameDataTable _game = new GamesDataSet.GameDataTable();
        GamesDataSet.PlayerDataTable _player = new GamesDataSet.PlayerDataTable();
        GamesDataSet.GameTurnDataTable _gameTurn = new GamesDataSet.GameTurnDataTable();
        public SDFRepository()
        {
            
        }

        #region Reading
        public List<string> GetGameNames() 
        {
            _gameAdapter.Fill(_game);
            var names = from g in _game
                         select g.name;
            return new List<string>(names);
        }

        public List<Turn> GetTurns(string gameName) 
        {
            _gameAdapter.Fill(_game);
            _gameTurnAdapter.Fill(_gameTurn);
            var turns = from g in _game
                        from t in _gameTurn
                        where g.name == gameName && g.id == t.GameID
                        select new { t.fromX, t.fromY, t.toX, t.toY, t.timePerTurn, t.pawnPromotionType };
            List<Turn> res = new List<Turn>();

            foreach (var turn in turns)
            {
                res.Add(new Turn(new Point2(turn.fromX, turn.fromY), 
                    new Point2(turn.toX, turn.toY),
                    turn.timePerTurn, (EPawnPromotion)turn.pawnPromotionType));
            }

            return res;
        }

        public void GetPlayers(string gameName, out EPlayerType[] types, out int[] startTime) 
        {
            _gameAdapter.Fill(_game);
            _playerAdapter.Fill(_player);

            types = new EPlayerType[2];
            startTime = new int[2];

            var  white = (from g in _game
                        from p in _player
                        where g.name == gameName && g.WhitePlayerID == p.id 
                        select p).First();
            types[0]= (EPlayerType)white.Type;
            startTime[0] = white.StartTime;

            var black = (from g in _game
                         from p in _player
                         where g.name == gameName && g.BlackPlayerID == p.id
                         select p).First();
            types[1] = (EPlayerType)black.Type;
            startTime[1] = black.StartTime;

        }

        #endregion

        #region writing
        public void AddGame(string gameName, EPlayerType[] playerTypes, int[] playerStartTime)
        {
            _gameAdapter.Fill(_game);
            _playerAdapter.Fill(_player);
            int? gameID = (from game in _game
                           where game.name == gameName
                           select game.id).FirstOrDefault();
            if (gameID != null)
            {
                _game.RemoveGameRow((GamesDataSet.GameRow)_game.Rows.Find(gameID));
            }
           
            int last;
            try
            {
                last = (from g in _game
                        select g.id).Max();
            }
            catch (Exception) { last = 0; }

            _game.AddGameRow(last + 1, gameName, WhitePlayerID, BlackPlayerID);

        }


        public void SaveOrRewriteTurns(string gameName, List<Turn> turns) { }

        #endregion

        #region aux
        void CreateOrRewritePlayers(string gameName, out int whiteID, out int blackID)
        {
            
            var playersToDelete = from g in _game
                                    from p in _player
                                    where g.name == gameName 
                                    && (g.WhitePlayerID == p.id || g.BlackPlayerID == p.id)
                                select p;
            
           
        }
        #endregion
    }
}
