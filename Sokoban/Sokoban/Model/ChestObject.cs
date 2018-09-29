using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class ChestObject : TileObject
    {
        public char _standardValue = 'O';

        private bool _canHavePlayer = false;

        public new char GetChar()
        {
            return _standardValue;
        }
    }
}
