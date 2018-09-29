using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class DestinationObject : TileObject
    {
        private char _destinationValue { get; set; }

        public DestinationObject()
        {
            _destinationValue = 'X';
        }

        public new char GetChar()
        {
            return _destinationValue;
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
