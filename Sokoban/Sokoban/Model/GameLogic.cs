using System;
using System.Security.Cryptography.X509Certificates;

namespace Sokoban.Model
{
    public class GameLogic
    {
        private LinkedGameObject _playerObject;
        private LinkedGameObject _tempObject;
        public bool GameWon { get; set; }


        // set PlayerObject
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

        private bool NormalMove(LinkedGameObject move)
        {
            if (move.GameObject.GetChar() == (char)Characters.Tile)
            {
                if (_tempObject != null)
                {
                    move.GameObject.SetChar((char)Characters.Player);
                    _playerObject.GameObject.SetChar(_tempObject.GameObject.GetChar());
                    _playerObject = move;
                    _tempObject = null; // reset object
                    return true;
                }
                move.GameObject.SetChar((char)Characters.Player);
                _playerObject.GameObject.SetChar((char)Characters.Tile);
                _playerObject = move;
                return true;
            }
            return false;
        }

        private bool MoveOntoDestinationOrTrap(LinkedGameObject move)
        {
            if(move.GameObject.GetChar() == (char)Characters.Destination 
                || move.GameObject.GetChar() == (char)Characters.Trap 
                || move.GameObject.GetChar() == (char)Characters.OpenTrap)
            {
                
                move.GameObject.SetChar((char)Characters.Player);
                _playerObject.GameObject.SetChar((char)Characters.Tile); // player becomes a tile
                _playerObject = move;
                return true;
            }
            return false;
        }



        public LinkedList MoveUp(LinkedList currentLevel)
        {
            if (NormalMove(_playerObject.ObjectAbove))
                return currentLevel;
            if (MoveOntoDestinationOrTrap(_playerObject.ObjectAbove))
                return currentLevel;





            if (_playerObject.ObjectAbove.GameObject.GetChar() == 'O' &&
                _playerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == '.')
            {
                _playerObject.GameObject.SetChar('X');
                _playerObject.ObjectAbove.GameObject.SetChar('@');
                _playerObject.ObjectAbove.ObjectAbove.GameObject.SetChar('O');

                _playerObject = _playerObject.ObjectAbove;

                return currentLevel;

            }




            if (_playerObject.ObjectAbove.GameObject.GetChar() == 'X')
            {
                _playerObject.ObjectAbove.GameObject.SetChar('@');
                _playerObject.GameObject.SetChar('.');
                _playerObject = _playerObject.ObjectAbove;

                return currentLevel;
            }

            if (_playerObject.ObjectAbove.GameObject.GetChar() == '.')

            {
                SwapTwo(_playerObject, _playerObject.ObjectAbove);

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
                    //if above the crate is a destination object
                    _playerObject.ObjectAbove.ObjectAbove.GameObject.SetChar((char)Characters.CrateOnDestination);
                    _playerObject.ObjectAbove.GameObject.SetChar((char)Characters.Player);
                    _playerObject.GameObject.SetChar((char)Characters.Tile);

                    _playerObject = _playerObject.ObjectAbove;

                    return currentLevel;

                }

            }

            if (_playerObject.ObjectAbove.GameObject.GetChar() == '0'
                && _playerObject.ObjectAbove.ObjectAbove.GameObject.GetChar() == '.'
                && GameWon == false)
            {
                _playerObject.ObjectAbove.ObjectAbove.GameObject.SetChar('O');
                _playerObject.ObjectAbove.GameObject.SetChar('@');
                _playerObject.GameObject.SetChar('.');

                _playerObject = _playerObject.ObjectAbove;
            }


            return currentLevel;
        }


        public LinkedList MoveLeft(LinkedList currentLevel)
        {
            if (NormalMove(_playerObject.ObjectPrevious))
                return currentLevel;
            if (MoveOntoDestinationOrTrap(_playerObject.ObjectPrevious))
                return currentLevel;

            if (_playerObject.ObjectPrevious.GameObject.GetChar() == 'O' &&
                    _playerObject.ObjectPrevious.ObjectPrevious.GameObject.GetChar() == '.')
                {
                    _playerObject.GameObject.SetChar('X');
                    _playerObject.ObjectPrevious.GameObject.SetChar('@');
                    _playerObject.ObjectPrevious.ObjectPrevious.GameObject.SetChar('O');

                    _playerObject = _playerObject.ObjectPrevious;

                    return currentLevel;

                }


            

            if (_playerObject.ObjectPrevious.GameObject.GetChar() == 'X')
            {
                _playerObject.ObjectPrevious.GameObject.SetChar('@');
                _playerObject.GameObject.SetChar('.');
                _playerObject = _playerObject.ObjectPrevious;

                return currentLevel;
            }


            if (_playerObject.ObjectPrevious.GameObject.GetChar() == '.')

            {
                SwapTwo(_playerObject, _playerObject.ObjectPrevious);
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
            if (NormalMove(_playerObject.ObjectBelow))
                return currentLevel;
            if (MoveOntoDestinationOrTrap(_playerObject.ObjectBelow))
                return currentLevel;
           

                if (_playerObject.ObjectBelow.GameObject.GetChar() == (char)Characters.Crate &&
                    _playerObject.ObjectBelow.ObjectBelow.GameObject.GetChar() == (char)Characters.Tile)
                {
                    _playerObject.GameObject.SetChar((char)Characters.Destination);
                    _playerObject.ObjectBelow.GameObject.SetChar((char)Characters.Player);
                    _playerObject.ObjectBelow.ObjectBelow.GameObject.SetChar((char)Characters.Crate);

                    _playerObject = _playerObject.ObjectBelow;

                    return currentLevel;

                }
            
            if (_playerObject.ObjectBelow.GameObject.GetChar() == (char)Characters.Tile)

            {
                SwapTwo(_playerObject, _playerObject.ObjectBelow);
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
            if (NormalMove(_playerObject.ObjectNext))
                return currentLevel;
            if (MoveOntoDestinationOrTrap(_playerObject.ObjectNext))
                return currentLevel;


            if (_playerObject.ObjectNext.GameObject.GetChar() == (char)Characters.Crate &&
                    _playerObject.ObjectNext.ObjectNext.GameObject.GetChar() == (char)Characters.Tile)
                {
                    _playerObject.GameObject.SetChar((char)Characters.Destination);
                    _playerObject.ObjectNext.GameObject.SetChar((char)Characters.Player);
                    _playerObject.ObjectNext.ObjectNext.GameObject.SetChar((char)Characters.Crate);

                    _playerObject = _playerObject.ObjectNext;

                    return currentLevel;

                }
            


            if (_playerObject.ObjectNext.GameObject.GetChar() == (char)Characters.Tile)

            {
                SwapTwo(_playerObject, _playerObject.ObjectNext);
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

        public bool LessDestinationsThanCrates(LinkedList level)
        {
            var rows = level.First;
            var columns = level.First;
            var destinations = 0;
            var crates = 0;
            while (rows != null)
            {
                while (columns != null)
                {
                    if (columns.GameObject.GetChar() == (char)Characters.Destination)
                    {

                        destinations++;
                    }

                    if (columns.GameObject.GetChar() == (char)Characters.Crate)
                    {
                        crates++;
                    }
                    columns = columns.ObjectNext;
                }

                rows = rows.ObjectBelow;
                columns = rows;

            }

            if (destinations < crates)
            {
                return true;
            }

            return false;
        }
    }

}