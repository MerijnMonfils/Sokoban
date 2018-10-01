using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class DestinationObject : BaseObject
    {
        private char _destinationValue = 'X';
        public override char _value
        {
            get
            {
                return _destinationValue;
            }
            set
            {
                _destinationValue = value;
            }
        }

        public void HasChest(bool hasChest)
        {
            if (hasChest)
                this._destinationValue = '0';
            else
                this._destinationValue = 'X';
        }
    }
}
