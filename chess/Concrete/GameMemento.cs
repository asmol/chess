using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public class GameMemento
    {
        public GameMemento() {
            CurrentTurn = 0;
            Turns = new List<Turn>();
        }   
        public int CurrentTurn { get; set; }
        public List<Turn> Turns { get; set; }
    }
}
