using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class TileObject
    {
        protected char _standardValue = '.';

        protected bool _canHavePlayer = true;

        protected char GetChar()
        {
            return _standardValue;
        }
    }
}
