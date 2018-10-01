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
                    if (columns.GameObject.GetChar() == '@')
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

        // normal move
        private void SwapTwo(LinkedGameObject first, LinkedGameObject second)
        {
            var temp = first.GameObject;

            first.GameObject = second.GameObject;

            second.GameObject = temp;

            PlayerObject = second; 
        }

        // move with chest
        private void SwapTwo(LinkedGameObject first, LinkedGameObject second, bool withChest)
        {
            var temp = first.GameObject;

            first.GameObject = second.GameObject;

            second.GameObject = temp;
        }

        public LinkedList MoveUp(LinkedList currentLevel)
        {
            if (PlayerObject.ObjectAbove.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectAbove);
            }
           

            //if above neighbour = crate
            if (PlayerObject.ObjectAbove.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (PlayerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(PlayerObject.ObjectAbove, PlayerObject.ObjectAbove.ObjectAbove, true);
                    
                    // move with player
                    SwapTwo(PlayerObject, PlayerObject.ObjectAbove);

                }

                if (PlayerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == 'X')
                {
                    
                    // move with chest
                    SwapTwo(PlayerObject.ObjectAbove, PlayerObject.ObjectAbove.ObjectAbove, true);

                    // move with player
                    SwapTwo(PlayerObject, PlayerObject.ObjectAbove);

                }

            }


            return currentLevel;
        }

        public LinkedList MoveLeft(LinkedList currentLevel)
        {
            if (PlayerObject.ObjectPrevious.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectPrevious);
            }
            return currentLevel;
        }

        public LinkedList MoveDown(LinkedList currentLevel)
        {
            if (PlayerObject.ObjectBelow.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectBelow);
            }
            return currentLevel;
        }

        public LinkedList MoveRight(LinkedList currentLevel)
        {
            if (PlayerObject.ObjectNext.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectNext);
            }
            return currentLevel;
        }
    }
}