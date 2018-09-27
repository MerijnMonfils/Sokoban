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


        protected new bool _canHavePlayer = true;

        protected new char GetChar()
        {

            return _destinationValue;
        }

        protected void HasChest(bool hasChest)
        {
            if (hasChest)
                this._destinationValue = '0';
            else
                this._destinationValue = 'X';            
        }
    }
}
