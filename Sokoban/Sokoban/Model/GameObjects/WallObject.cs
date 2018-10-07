using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class WallObject : BaseObject
    {
        private char _wallValue = (char) Characters.DesignWall;

        public override char Value
        {
            get
            {
                return _wallValue;
            }
            set
            {
                _wallValue = value;
            }
        }
    }
}
