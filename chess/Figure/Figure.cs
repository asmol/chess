using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chess
{
    public abstract class Figure
    {
        protected readonly ETeam team;
        protected readonly EType type;

        public Figure(ETeam team, EType type)
        {
            this.team = team;
            this.type = type;
        }
    }
}