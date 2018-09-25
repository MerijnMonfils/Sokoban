using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Characters
    {

        public char _wall { get; }
        public char _destination { get; }
        public char _tile { get; }
        public char _crate { get; }
        public char _truck { get; }
        public char _crateOnDestination { get; }


        public Characters()
        {
            _wall = '#';
            _destination = 'X';
            _crateOnDestination = '0';
            _tile = '.';
            _crate = 'O';
            _truck = '@';

        }

    }

   

    
}
