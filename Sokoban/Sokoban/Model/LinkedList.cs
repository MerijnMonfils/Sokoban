using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class LinkedList
    {
        public LinkedGameObject First { get; set; }

        public LinkedGameObject Last { get; set; }

        private int _currentRow;

        public void InsertInRow(LinkedGameObject obj, int currRow)
        {
            // assign left and right in first row
            // assign left right and up and down in second row and continue

            if (First == null)
            {
                First = new LinkedGameObject();
                First.SetGameObject(obj);
                Last = First;
                return;
            }

            var temp = First;
            First = new LinkedGameObject();
            First.SetGameObject(obj);
            First.ObjectNext = temp;
            temp.ObjectPrevious = First;
            return;
        }
    }
}
