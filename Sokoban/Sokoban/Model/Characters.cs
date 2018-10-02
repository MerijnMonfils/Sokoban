using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public enum Characters
    {
       Wall = '#',
       Tile = '.',
       Destination = 'X',
       Crate = 'O',
       CrateOnDestination = '0',
       Player = '@',
       Trap = '~',
       Worker = '$'
    }
}
