using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class WallObject : TileObject
    {
        private char _standardValue = '#';

        private bool _canHavePlayer = false;

        public new char GetChar()
        {
            return _standardValue;
        }
    }
}
