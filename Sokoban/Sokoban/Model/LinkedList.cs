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
        public LinkedGameObject FirstInCurrRow { get; set; }
        public LinkedGameObject LastInCurrRow { get; set; }
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

            Last.ObjectNext = new LinkedGameObject();
            Last.ObjectNext.SetGameObject(obj);
            Last.ObjectNext.ObjectPrevious = Last;
            Last = Last.ObjectNext;
            return;
        }
    }
}
