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
                    if (columns.GameObject.GetChar() == (char)Characters.Player)
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
            move.GameObject.SetChar((char)Characters.Tile);
            SwapTwo(_playerObject, move);

            // set trap to know it has a player ontop
            // if player moves off, last place of playerObject is a trap
        }

        public LinkedList MoveUp(LinkedList currentLevel)
        {
            if (_playerObject.ObjectAbove.GameObject.GetChar() == (char)Characters.Tile)
            {
                SwapTwo(_playerObject, _playerObject.ObjectAbove);

                return currentLevel;
            }

            if (_playerObject.ObjectAbove.GameObject.GetChar() == (char)Characters.Trap)
            {
                MoveToTrap(_playerObject.ObjectAbove);

                return currentLevel;
            }


            //if above neighbour = crate
            if (_playerObject.ObjectAbove.GameObject.GetChar() == (char)Characters.Crate)
            {
                //If above the crate are either a tile or a destination objects: 
                if (_playerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == (char)Characters.Tile)
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectAbove, _playerObject.ObjectAbove.ObjectAbove, true);
                    
                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectAbove);
                }

                if (_playerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == (char)Characters.Destination)
                {

                    _playerObject.ObjectAbove.ObjectAbove.GameObject.SetChar((char)Characters.CrateOnDestination);
                    _playerObject.ObjectAbove.GameObject.SetChar((char)Characters.Player);
                    _playerObject.GameObject.SetChar((char)Characters.Tile);

                    _playerObject = _playerObject.ObjectAbove;
                   
                }

            }


            return currentLevel;
        }


        public LinkedList MoveLeft(LinkedList currentLevel)
        {
            if (_playerObject.ObjectPrevious.GameObject.GetChar() == (char)Characters.Tile)
            {
                SwapTwo(_playerObject, _playerObject.ObjectPrevious);
                return currentLevel;
            }

            if (_playerObject.ObjectPrevious.GameObject.GetChar() == (char)Characters.Trap)
            {
                MoveToTrap(_playerObject.ObjectPrevious);

                return currentLevel;
            }

            if (_playerObject.ObjectPrevious.GameObject.GetChar() == (char)Characters.Crate)
            {
                //If above the crate are either a tile or a destination objects: 
                if (_playerObject.ObjectPrevious.ObjectPrevious.GameObject.GetChar() == (char)Characters.Tile)
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectPrevious, _playerObject.ObjectPrevious.ObjectPrevious, true);

                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectPrevious);
                }

                if (_playerObject.ObjectPrevious.ObjectPrevious.GameObject.GetChar() == (char)Characters.Destination)
                {

                    _playerObject.ObjectPrevious.ObjectPrevious.GameObject.SetChar((char)Characters.CrateOnDestination);
                    _playerObject.ObjectPrevious.GameObject.SetChar((char)Characters.Player);
                    _playerObject.GameObject.SetChar((char)Characters.Tile);

                    _playerObject = _playerObject.ObjectPrevious;

                }
            }

                return currentLevel;
           
        }

        public LinkedList MoveDown(LinkedList currentLevel)
        {
            if (_playerObject.ObjectBelow.GameObject.GetChar() == (char)Characters.Tile)
            {
                SwapTwo(_playerObject, _playerObject.ObjectBelow);
                return currentLevel;
            }

            if (_playerObject.ObjectBelow.GameObject.GetChar() == (char)Characters.Trap)
            {
                MoveToTrap(_playerObject.ObjectBelow);

                return currentLevel;
            }

            if (_playerObject.ObjectBelow.GameObject.GetChar() == (char)Characters.Crate)
            {
                //If neighbour below the crate is a tile object: 
                if (_playerObject.ObjectBelow.ObjectBelow.GameObject.GetChar() == (char)Characters.Tile)
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectBelow, _playerObject.ObjectBelow.ObjectBelow, true);

                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectBelow);
                }

                //If neighbour below the crate is a destination object: 
                if (_playerObject.ObjectBelow.ObjectBelow.GameObject.GetChar() == (char)Characters.Destination)
                {
                   
                    _playerObject.ObjectBelow.ObjectBelow.GameObject.SetChar((char)Characters.CrateOnDestination);
                    _playerObject.ObjectBelow.GameObject.SetChar((char)Characters.Player);
                    _playerObject.GameObject.SetChar((char)Characters.Tile);

                    _playerObject = _playerObject.ObjectBelow;

                }
            }
                return currentLevel;
        }

        public LinkedList MoveRight(LinkedList currentLevel)
        {
            if (_playerObject.ObjectNext.GameObject.GetChar() == (char)Characters.Tile)
            {
                SwapTwo(_playerObject, _playerObject.ObjectNext);
                return currentLevel;
            }

            if (_playerObject.ObjectNext.GameObject.GetChar() == (char)Characters.Trap)
            {
                MoveToTrap(_playerObject.ObjectNext);

                return currentLevel;
            }

            if (_playerObject.ObjectNext.GameObject.GetChar() == (char)Characters.Crate)
            {
                //If above the crate are either a tile or a destination objects: 
                if (_playerObject.ObjectNext.ObjectNext.GameObject.GetChar() == (char)Characters.Tile)
                {
                    // move with chest
                    SwapTwo(_playerObject.ObjectNext, _playerObject.ObjectNext.ObjectNext, true);

                    // move with player
                    SwapTwo(_playerObject, _playerObject.ObjectNext);
                }

                if (_playerObject.ObjectNext.ObjectNext.GameObject.GetChar() == (char)Characters.Destination)
                {

                    _playerObject.ObjectNext.ObjectNext.GameObject.SetChar((char)Characters.CrateOnDestination);
                    _playerObject.ObjectNext.GameObject.SetChar((char)Characters.Player);
                    _playerObject.GameObject.SetChar((char)Characters.Tile);

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
                    if (columns.GameObject.GetChar() == (char)Characters.Destination)
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