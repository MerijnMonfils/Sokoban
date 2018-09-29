using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class ChestObject : TileObject
    {
        private char _chestValue = 'O';

        private bool _canHavePlayer = false;

        public new char GetChar()
        {
            return _chestValue;
        }
    }
}
