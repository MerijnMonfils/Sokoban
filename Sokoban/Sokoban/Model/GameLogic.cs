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

                return currentLevel;
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

                    PlayerObject.ObjectAbove.ObjectAbove.GameObject.SetChar('0');
                    PlayerObject.ObjectAbove.GameObject.SetChar('@');
                    PlayerObject.GameObject.SetChar('.');

                    PlayerObject = PlayerObject.ObjectAbove;
                   
                }

            }


            return currentLevel;
        }

        public LinkedList MoveLeft(LinkedList currentLevel)
        {
            if (PlayerObject.ObjectPrevious.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectPrevious);
                return currentLevel;
            }

            if (PlayerObject.ObjectPrevious.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (PlayerObject.ObjectPrevious.ObjectPrevious.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(PlayerObject.ObjectPrevious, PlayerObject.ObjectPrevious.ObjectPrevious, true);

                    // move with player
                    SwapTwo(PlayerObject, PlayerObject.ObjectPrevious);
                }

                if (PlayerObject.ObjectPrevious.ObjectPrevious.GameObject.GetChar() == 'X')
                {

                    PlayerObject.ObjectPrevious.ObjectPrevious.GameObject.SetChar('0');
                    PlayerObject.ObjectPrevious.GameObject.SetChar('@');
                    PlayerObject.GameObject.SetChar('.');

                    PlayerObject = PlayerObject.ObjectPrevious;

                }
            }

                return currentLevel;
           
        }

        public LinkedList MoveDown(LinkedList currentLevel)
        {
            if (PlayerObject.ObjectBelow.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectBelow);
                return currentLevel;
            }

            if (PlayerObject.ObjectBelow.GameObject.GetChar() == 'O')
            {
                //If neighbour below the crate is a tile object: 
                if (PlayerObject.ObjectBelow.ObjectBelow.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(PlayerObject.ObjectBelow, PlayerObject.ObjectBelow.ObjectBelow, true);

                    // move with player
                    SwapTwo(PlayerObject, PlayerObject.ObjectBelow);
                }

                //If neighbour below the crate is a destination object: 
                if (PlayerObject.ObjectBelow.ObjectBelow.GameObject.GetChar() == 'X')
                {
                   
                    PlayerObject.ObjectBelow.ObjectBelow.GameObject.SetChar('0');
                    PlayerObject.ObjectBelow.GameObject.SetChar('@');
                    PlayerObject.GameObject.SetChar('.');

                    PlayerObject = PlayerObject.ObjectBelow;

                }
            }
                return currentLevel;
        }

        public LinkedList MoveRight(LinkedList currentLevel)
        {
            if (PlayerObject.ObjectNext.GameObject.GetChar() == '.')
            {
                SwapTwo(PlayerObject, PlayerObject.ObjectNext);
                return currentLevel;
            }

            if (PlayerObject.ObjectNext.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (PlayerObject.ObjectNext.ObjectNext.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(PlayerObject.ObjectNext, PlayerObject.ObjectNext.ObjectNext, true);

                    // move with player
                    SwapTwo(PlayerObject, PlayerObject.ObjectNext);
                }

                if (PlayerObject.ObjectNext.ObjectNext.GameObject.GetChar() == 'X')
                {

                    PlayerObject.ObjectNext.ObjectNext.GameObject.SetChar('0');
                    PlayerObject.ObjectNext.GameObject.SetChar('@');
                    PlayerObject.GameObject.SetChar('.');

                    PlayerObject = PlayerObject.ObjectNext;

                }
            }
            return currentLevel;
        }
    }


}