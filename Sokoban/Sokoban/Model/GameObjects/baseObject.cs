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
        
        public virtual bool ChestOnTrap { get; set; }

        public virtual char Value
        {
            get { return Value; }
            set { Value = value; }
        }

        public virtual char GetChar()
        {
            return Value;
        }

        public virtual void SetChar(char x)
        {
            x = Value;
        }
        
        public virtual void IsOnTrap() { }

    }
}
