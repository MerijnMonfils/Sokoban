using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class DestinationObject : BaseObject
    {
        private char _destinationValue = (char)Characters.Destination;

        public override bool HasChest { get; set; }

        public override char Value
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

        public override void SetChar(char x)
        {
            _destinationValue = x;
            base.SetChar(_destinationValue);
        }
    }
}
