using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    interface Square
    {

        char _square { get; set; }
          Object _neighbourBelow { get; set; }
          Object _neighbourAbove { get; set; }
          Object _neighbourRight { get; set; }
          Object _neighbourLeft  { get; set; }

    }
}
