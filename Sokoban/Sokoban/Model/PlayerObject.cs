using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class PlayerObject : BaseObject
    {
        private char _playerValue = (char)Characters.Player;


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

        public override void SetChar(char x)
        {
            _playerValue = x;
            base.SetChar(_playerValue);
        }
    }
}
