using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class TrapObject : BaseObject
    {
        private char _trapValue = (char)Characters.Trap;

        private int _amountOnTrap { get; set; }
        private bool _isOpenTrap { get; set; }

        public bool IsOpenTrap()
        {
            return _isOpenTrap;
        }

        public void IsOnTrap()
        {
            if(_amountOnTrap > 3)
            {
                this.SetChar((char)Characters.OpenTrap);
                _isOpenTrap = true;
            } else
            {
                _amountOnTrap++;
            }
        }

        public override char _value
        {
            get
            {
                return _trapValue;
            }
            set
            {
                _trapValue = value;
            }
        }

        public override void SetChar(char x)
        {
            _trapValue = x;
            base.SetChar(_trapValue);
        }

    }
}
