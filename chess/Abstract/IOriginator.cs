using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public interface IOriginator
    {
        void RestoreState(GameMemento memento);
        GameMemento Memento { get; }
    }
}
