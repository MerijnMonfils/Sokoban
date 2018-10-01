using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
     class TileObject : baseObject
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



        public override void SetChar(char x)
        {
            _tileValue = x;
            base.SetChar(_tileValue);
        }
    }
}
