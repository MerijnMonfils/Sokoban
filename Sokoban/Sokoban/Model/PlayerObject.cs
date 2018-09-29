using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class PlayerObject : baseObject
    {
        private char _test = '#';
        public override char _value
        {
            get
            {
                return _test;
            }
            set
            {

                _test = value;

            }
        }
    }
}
