using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    interface ICareTaker
    {
        GameMemento Memento { get; set; }
    }
}
