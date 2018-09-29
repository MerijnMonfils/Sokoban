using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class TileObject
    {
        private char _standardValue = '.';

        private bool _canHavePlayer = true;

        public char GetChar()
        {
            return _standardValue;
        }
    }
}
