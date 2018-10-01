using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class TrapObject : BaseObject
    {
        private char _trapValue = '~';

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

    }
}
