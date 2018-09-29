using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class WallObject : baseObject
    {
        private char _test = '#';
     

        public override char GetChar()
        {
            return _test;
        }
    }
}
