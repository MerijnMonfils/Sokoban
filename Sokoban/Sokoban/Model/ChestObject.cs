using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class ChestObject : baseObject
    {
        private char _chestValue = 'O';
        public override char _value
        {
            get
            {
                return _chestValue;
            }
            set
            {
                _chestValue = value;
            }
        }

        public override void SetChar(char x)
        {
            _chestValue = x;
            base.SetChar(_chestValue);
        }
    }
}
