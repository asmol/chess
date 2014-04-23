using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    class SimpleCareTaker:ICareTaker
    {
        public GameMemento Memento { get; set; }
    }
}
