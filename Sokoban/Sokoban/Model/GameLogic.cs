using System;

namespace Sokoban.Model
{
    public class GameLogic
    {
        private LinkedGameObject PlayerObject;

        public void SetPlayer(LinkedList currentLevel)
        {
            var rows = currentLevel.First;
            var columns = currentLevel.First;

            while (rows != null)
            {
                while (columns != null)
                {
                    if(columns.GameObject.GetChar() == '@')
                    {
                        PlayerObject = columns;
                        return;
                    }
                    columns = columns.ObjectNext;
                }
                rows = rows.ObjectBelow;
                columns = rows;
            }            
        }

        private void SwapTwo(LinkedGameObject first, LinkedGameObject second)
        {
            var temp = first.GameObject;

            first.GameObject = second.GameObject;

            second.GameObject = temp;
        }

        public LinkedList MoveUp(LinkedList currentLevel)
        {
            Console.WriteLine("ObjectAbove: " + PlayerObject.ObjectAbove.GameObject.GetChar());
            Console.WriteLine("ObjectBelow: " + PlayerObject.ObjectBelow.GameObject.GetChar());
            Console.WriteLine("ObjectPrevious: " + PlayerObject.ObjectPrevious.GameObject.GetChar());
            Console.WriteLine("ObjectNext: " + PlayerObject.ObjectNext.GameObject.GetChar());

            Console.ReadLine();
            if (PlayerObject.ObjectAbove.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectAbove);
                PlayerObject = PlayerObject.ObjectAbove;
            }
            return currentLevel;
            //if above neighbour == crate

            if (PlayerObject.ObjectAbove.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (PlayerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == 'X' ||
                    PlayerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == '.')
                {
                    //Swap em all!

                    var temp1 = PlayerObject.ObjectAbove.ObjectAbove.GameObject; //.
                    var temp = PlayerObject.ObjectAbove.GameObject; //O
                    var p = PlayerObject.GameObject; //@

                    PlayerObject.ObjectAbove.GameObject = PlayerObject.ObjectAbove.ObjectAbove.GameObject;
                    PlayerObject.ObjectAbove.ObjectAbove.GameObject = temp;


                    PlayerObject.GameObject = temp1;
                    PlayerObject.ObjectAbove.GameObject = p;
                }
            }
            return currentLevel;
        }

        public LinkedList MoveLeft(LinkedList currentLevel)
        {
            throw new NotImplementedException();
        }

        public LinkedList MoveDown(LinkedList currentLevel)
        {
            throw new NotImplementedException();
        }

        public LinkedList MoveRight(LinkedList currentLevel)
        {
            throw new NotImplementedException();
        }
    }
}