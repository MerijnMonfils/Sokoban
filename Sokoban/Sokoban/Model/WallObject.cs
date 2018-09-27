﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class WallObject : TileObject
    {
        private char _wallValue = '#';

        protected new bool _canHavePlayer = false;

        protected new char GetChar()
        {
            return _wallValue;
        }
    }
}
