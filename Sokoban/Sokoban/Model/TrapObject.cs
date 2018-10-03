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



        public void IsOnTrap()
        {

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
