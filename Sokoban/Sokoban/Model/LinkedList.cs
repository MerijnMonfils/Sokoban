using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class LinkedList
    {
        public LinkedGameObject First { get; set; }
        public LinkedGameObject FirstInPreviousRow { get; set; }
        public LinkedGameObject FirstInCurrentRow { get; set; }
        public LinkedGameObject Last { get; set; }

        public LinkedGameObject player;

        private int _prevRow;


        public void InsertInRow(baseObject obj, int currRow)
        {
            // first row
            if (First == null)
            {
                First = new LinkedGameObject();
                First.GameObject = obj;
                Last = First;
                FirstInCurrentRow = First;
                return;
            }
            else if (currRow == 0)
            {
                Last.ObjectNext = new LinkedGameObject();
                Last.ObjectNext.GameObject = obj;
                Last.ObjectNext.ObjectPrevious = Last;
                Last = Last.ObjectNext;
                _prevRow = currRow;
                return;
            }

            // new row
            if (_prevRow != currRow)
            {
                FirstInPreviousRow = FirstInCurrentRow;
                FirstInCurrentRow = null;
                _prevRow = currRow;
            }

            var mostRightObj = new LinkedGameObject();
            // find most right element in current row
            if (FirstInCurrentRow != null)
            {
                mostRightObj = FirstInCurrentRow;
                while (mostRightObj.ObjectNext != null)
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
            l.GameObject = obj;
            
            // Assign top neighbour
            if (l == FirstInCurrentRow )
            {
                l.ObjectAbove = FirstInPreviousRow;
                FirstInPreviousRow.ObjectBelow = l;
            }
            else
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

        public LinkedGameObject Player()
        {

            //Op een of ander manier hier _currentlevel krijgen
            var rows = currentLevel.First;
            var columns = currentLevel.First;

            while (rows != null)
            {
                while (columns != null)
                {
                    //As long as object char isn't a Player, keep looking
                    if (First != null && First.GameObject.GetChar() != '@')
                    {
                        First = First.ObjectNext;
                        player = First;
                        //Return player object

                    }
                }
            }
            return player;
        }

        public LinkedList SwapTop(LinkedList currentLevel)
        {
         

            //if above neighbour == tile
        
                    if (Player().ObjectAbove.GameObject.GetChar() == '.')
                    {
                        var temp = Player().ObjectAbove.GameObject;

                        Player().ObjectAbove.GameObject = Player().GameObject;

                        Player().GameObject = temp;

                    }

           
            //if above neighbour == crate

            if (player.ObjectAbove.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (player.ObjectAbove.ObjectAbove.GameObject.GetChar() == 'X' ||
                    player.ObjectAbove.ObjectAbove.GameObject.GetChar() == '.')
                {
                   //Swap em all!

                    var temp1 = Player().ObjectAbove.ObjectAbove.GameObject; //.
                    var temp = Player().ObjectAbove.GameObject; //O
                    var p = Player().GameObject; //@

                    Player().ObjectAbove.GameObject = Player().ObjectAbove.ObjectAbove.GameObject;
                    Player().ObjectAbove.ObjectAbove.GameObject = temp;


                    player.GameObject = temp1;
                    Player().ObjectAbove.GameObject = p;

                }

            }

            return currentLevel;

        }
    }

 }

    



