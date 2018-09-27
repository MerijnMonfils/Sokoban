using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class PlayerObject : TileObject
    {
        private char _playerValue = '@';

        protected new bool _canHavePlayer = false;

        protected new char GetChar()
        {

            return _playerValue;
        }
    }
}
