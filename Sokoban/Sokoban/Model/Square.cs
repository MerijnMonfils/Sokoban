using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Square
    {

         public char _square { get; set; }
         public Object _neighbourBelow { get; set; }
         public Object _neighbourAbove { get; set; }
         public Object _neighbourRight { get; set; }
         public Object _neighbourLeft  { get; set; }

    }
}
