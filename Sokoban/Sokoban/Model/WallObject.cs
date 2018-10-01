using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class WallObject : BaseObject
    {
        private char _playerValue = '#';
        public override char _value
        {
            get
            {
                return _playerValue;
            }
            set
            {
                _playerValue = value;
            }
        }
    }
}
