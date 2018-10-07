using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class CrateObject : BaseObject
    {
        private char _chestValue = (char)Characters.Crate;

        public bool _isOnTrap { get; set; }

        public override void IsOnTrap()
        {
            if (_isOnTrap)
                _isOnTrap = true;
        }

        public override char Value
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
