using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    enum EPlayerType { user, simpleComputer };
    interface IRepository
    {
        List<string> GetGameNames();
        List<Turn> GetTurns(string gameName);
        void GetPlayers(string gameName, out EPlayerType[] types, out int[] startTime);

        void AddGame(string gameName, EPlayerType[] playerTypes, int[] playerStartTime);
        void SaveOrRewriteTurns(string gameName, List<Turn> turns);
    }
}
