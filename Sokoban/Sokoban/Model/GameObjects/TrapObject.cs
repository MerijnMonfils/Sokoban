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
        public bool ObjectOnTrap { get; set; }

        public TrapObject(bool isOpen)
        {
            ObjectOnTrap = isOpen;
            if (ObjectOnTrap)
                this.SetChar((char)Characters.OpenTrap);
        }

        public override void IsOnTrap()
        {
            if(_amountOnTrap >= 2)
            {
                this.SetChar((char)Characters.OpenTrap);
                ObjectOnTrap = true;
            } else
            {
                _amountOnTrap++;
            }
        }

        public override char Value
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
