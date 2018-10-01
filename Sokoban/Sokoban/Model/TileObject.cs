﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
     class TileObject : BaseObject
    {
        private char _tileValue = '.';
        public override char _value
        {
            get
            {
                return _tileValue;
            }
            set
            {
                _tileValue = value;
            }
        }
    }
}
