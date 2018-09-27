using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class LinkedGameObject
    {
        private object gameObject;


        public object GetGameObject()
        {
            return gameObject;
        }

        public void SetGameObject(object value)
        {

            gameObject = value;
        }

        public LinkedGameObject ObjectAbove { get; set; }
        public LinkedGameObject ObjectPrevious { get; set; }
        public LinkedGameObject ObjectBelow { get; set; }
        public LinkedGameObject ObjectNext { get; set; }
    }
}
