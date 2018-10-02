using System;

namespace Sokoban.Model
{
    public class GameLogic
    {
        private LinkedGameObject _playerObject;
        public bool GameWon { get; set; }
        

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
                        _playerObject = columns;
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

            _playerObject = second; 
        }

        // move with chest
        private void SwapTwo(LinkedGameObject first, LinkedGameObject second, bool withChest)
        {
            var temp = first.GameObject;

            first.GameObject = second.GameObject;

            second.GameObject = temp;
        }

        private void MoveToTrap(LinkedGameObject move)
        {
            move.GameObject.SetChar('.');
            SwapTwo(_playerObject, move);

            // set trap to know it has a player ontop
            // if player moves off, last place of playerObject is a trap
        }

        public LinkedList MoveUp(LinkedList currentLevel)
        {
            if (_playerObject.ObjectAbove.GameObject.GetChar() == '.')
            {
                SwapTwo(_playerObject, _playerObject.ObjectAbove);

                return currentLevel;
            }

            if (_playerObject.ObjectAbove.GameObject.GetChar() == '~')
            {
                MoveToTrap(_playerObject.ObjectAbove);

                return currentLevel;
            }


            //if above neighbour = crate
            if (_playerObject.ObjectAbove.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (_playerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectAbove, _playerObject.ObjectAbove.ObjectAbove, true);
                    
                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectAbove);
                }

                if (_playerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == 'X')
                {

                    _playerObject.ObjectAbove.ObjectAbove.GameObject.SetChar('0');
                    _playerObject.ObjectAbove.GameObject.SetChar('@');
                    _playerObject.GameObject.SetChar('.');

                    _playerObject = _playerObject.ObjectAbove;
                   
                }

            }


            return currentLevel;
        }


        public LinkedList MoveLeft(LinkedList currentLevel)
        {
            if (_playerObject.ObjectPrevious.GameObject.GetChar() == '.')
            {
                SwapTwo(_playerObject, _playerObject.ObjectPrevious);
                return currentLevel;
            }

            if (_playerObject.ObjectPrevious.GameObject.GetChar() == '~')
            {
                MoveToTrap(_playerObject.ObjectPrevious);

                return currentLevel;
            }

            if (_playerObject.ObjectPrevious.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (_playerObject.ObjectPrevious.ObjectPrevious.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectPrevious, _playerObject.ObjectPrevious.ObjectPrevious, true);

                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectPrevious);
                }

                if (_playerObject.ObjectPrevious.ObjectPrevious.GameObject.GetChar() == 'X')
                {

                    _playerObject.ObjectPrevious.ObjectPrevious.GameObject.SetChar('0');
                    _playerObject.ObjectPrevious.GameObject.SetChar('@');
                    _playerObject.GameObject.SetChar('.');

                    _playerObject = _playerObject.ObjectPrevious;

                }
            }

                return currentLevel;
           
        }

        public LinkedList MoveDown(LinkedList currentLevel)
        {
            if (_playerObject.ObjectBelow.GameObject.GetChar() == '.')
            {
                SwapTwo(_playerObject, _playerObject.ObjectBelow);
                return currentLevel;
            }

            if (_playerObject.ObjectBelow.GameObject.GetChar() == '~')
            {
                MoveToTrap(_playerObject.ObjectBelow);

                return currentLevel;
            }

            if (_playerObject.ObjectBelow.GameObject.GetChar() == 'O')
            {
                //If neighbour below the crate is a tile object: 
                if (_playerObject.ObjectBelow.ObjectBelow.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectBelow, _playerObject.ObjectBelow.ObjectBelow, true);

                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectBelow);
                }

                //If neighbour below the crate is a destination object: 
                if (_playerObject.ObjectBelow.ObjectBelow.GameObject.GetChar() == 'X')
                {
                   
                    _playerObject.ObjectBelow.ObjectBelow.GameObject.SetChar('0');
                    _playerObject.ObjectBelow.GameObject.SetChar('@');
                    _playerObject.GameObject.SetChar('.');

                    _playerObject = _playerObject.ObjectBelow;

                }
            }
                return currentLevel;
        }

        public LinkedList MoveRight(LinkedList currentLevel)
        {
            if (_playerObject.ObjectNext.GameObject.GetChar() == '.')
            {
                SwapTwo(_playerObject, _playerObject.ObjectNext);
                return currentLevel;
            }

            if (_playerObject.ObjectNext.GameObject.GetChar() == '~')
            {
                MoveToTrap(_playerObject.ObjectNext);

                return currentLevel;
            }

            if (_playerObject.ObjectNext.GameObject.GetChar() == 'O')
            {
                //If above the crate are either a tile or a destination objects: 
                if (_playerObject.ObjectNext.ObjectNext.GameObject.GetChar() == '.')
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectNext, _playerObject.ObjectNext.ObjectNext, true);

                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectNext);
                }

                if (_playerObject.ObjectNext.ObjectNext.GameObject.GetChar() == 'X')
                {

                    _playerObject.ObjectNext.ObjectNext.GameObject.SetChar('0');
                    _playerObject.ObjectNext.GameObject.SetChar('@');
                    _playerObject.GameObject.SetChar('.');

                    _playerObject = _playerObject.ObjectNext;

                }
            }
            return currentLevel;
        }

        public bool GameFinished(LinkedList level)
        {
            var rows = level.First;
            var columns = level.First;

            while (rows != null)
            {
                while (columns != null)
                {
                    if (columns.GameObject.GetChar() == 'X')
                    {

                        GameWon = false;
                        return false;
                    }
                    columns = columns.ObjectNext;
                }

                rows = rows.ObjectBelow;
                columns = rows;

            }
            GameWon = true;
            return true;
        }
    }

}