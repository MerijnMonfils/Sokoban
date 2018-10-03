using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class TrapLogic
    {
        private bool _isOpen { get; set; }

        private int _counter = 0;

        public void MovedOnTrap()
        {
            // either a crate or a player is on the trap
            // increment a counter + 1
            // if counter == 3 -> set char to Characters.OpenTrap
            
            // if a crate is on the trap -> remove crate from game
            // player can move over it
        }
    }
}
