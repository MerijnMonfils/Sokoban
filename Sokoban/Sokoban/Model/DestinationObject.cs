using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class DestinationObject : TileObject
    {
        private char _standardValue { get; set; }

        public DestinationObject()
        {
            _standardValue = 'X';
        }

        public new char GetChar()
        {
            return _standardValue;
        }

        public void HasChest(bool hasChest)
        {
            if (hasChest)
                this._standardValue = '0';
            else
                this._standardValue = 'X';            
        }
    }
}
