using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class BaseObject
    {
        public virtual bool HasChest { get; set; }

        public virtual void IsOnTrap() { }

        public virtual char _value
        {
            get { return _value; }
            set { _value = value; }
        }

        public virtual char GetChar()
        {
            return _value;
        }

        public virtual void SetChar(char x)
        {
            x = _value;
        }

    }
}
