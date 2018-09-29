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
        public LinkedGameObject FirstInPreviousRow { get; set; }
        public LinkedGameObject FirstInCurrentRow { get; set; }
        public LinkedGameObject Last { get; set; }

        private int _prevRow;
        
        public void InsertInRow(LinkedGameObject obj, int currRow, int currCol)
        {
            // first row
            if (First == null)
            {
                First = new LinkedGameObject();
                First.SetGameObject(obj);
                Last = First;
                FirstInPreviousRow = First;
                return;
            } else if(currRow < 0)
            {
                Last.ObjectNext = new LinkedGameObject();
                Last.ObjectNext.SetGameObject(obj);
                Last.ObjectNext.ObjectPrevious = Last;
                Last = Last.ObjectNext;
                _prevRow = currRow;
                return;
            }

            if(_prevRow != currRow)
            {
                FirstInPreviousRow = FirstInCurrentRow;
                FirstInCurrentRow = null;
                _prevRow = currRow;
            } 

            // find most right element in current row
            var mostRightObj = FirstInCurrentRow;
            for(int x = 0; x < currCol; x++)
            {
                if(mostRightObj.ObjectNext != null)
                {
                    mostRightObj = mostRightObj.ObjectNext;
                } 
            }

            LinkedGameObject l = new LinkedGameObject();
            
            if (FirstInCurrentRow == null)
            {
                // first object in new row
                FirstInCurrentRow = l;
                Last = l;
            }
            else
            {
                // current object(l) has a neighbour to his left
                mostRightObj.ObjectNext = l;
                l.ObjectPrevious = mostRightObj;
                Last = l;
            }
            // set game object
            l.SetGameObject(obj);

            // Assign top neighbour
            if(l == FirstInCurrentRow)
            {
                l.ObjectAbove = FirstInPreviousRow;
                FirstInPreviousRow.ObjectBelow = l;
            } else
            {
                var mostRightInPreviousRow = FirstInPreviousRow;
                while (mostRightInPreviousRow.ObjectNext != null)
                {
                    mostRightInPreviousRow = mostRightInPreviousRow.ObjectNext;
                }
                l.ObjectAbove = mostRightInPreviousRow;
                mostRightInPreviousRow.ObjectBelow = l;
            }
        }
    }
}
