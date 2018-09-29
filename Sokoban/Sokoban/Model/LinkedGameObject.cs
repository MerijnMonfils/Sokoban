using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class LinkedGameObject
    {
        public Object GameObject { get; set; }
        public LinkedGameObject ObjectAbove { get; set; }
        public LinkedGameObject ObjectPrevious { get; set; }
        public LinkedGameObject ObjectBelow { get; set; }
        public LinkedGameObject ObjectNext { get; set; }
    }
}
