using System;
using System.Security.Cryptography.X509Certificates;

namespace Sokoban.Model
{
    public class GameLogic
    {
        private LinkedGameObject _playerObject;
        private char _tempChar;
        public bool _isOnSpecialSquare { get; set; }
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
                if (_isOnSpecialSquare)
                {
                    move.GameObject.SetChar((char)Characters.Player);
                    _playerObject.GameObject.SetChar(_tempChar);
                    _playerObject = move;
                    _isOnSpecialSquare = false; // reset object
                    return true;
                }
                SwapTwo(_playerObject, move);
                return true;
            }
            return false;
        }

        private bool MoveOntoDestinationOrTrap(LinkedGameObject move)
        {
            if (move.GameObject.GetChar() == (char)Characters.Destination
                || move.GameObject.GetChar() == (char)Characters.Trap
                || move.GameObject.GetChar() == (char)Characters.OpenTrap)
            {
                if (_isOnSpecialSquare)
                    _playerObject.GameObject.SetChar(_tempChar); // player becomes a tile
                else
                    _playerObject.GameObject.SetChar((char)Characters.Tile); // player becomes a tile

                _isOnSpecialSquare = true;
                SetChar(move.GameObject.GetChar());
                move.GameObject.SetChar((char)Characters.Player);
                _playerObject = move;
                return true;
            }
            return false;
        }

        private void SetChar(char c)
        {
            if (c == (char)Characters.Destination)
                _tempChar = (char)Characters.Destination;
            if (c == (char)Characters.Trap)
                _tempChar = (char)Characters.Trap;
            if (c == (char)Characters.OpenTrap)
                _tempChar = (char)Characters.OpenTrap;
        }

        private bool CheckCrateMove(LinkedGameObject move, LinkedGameObject moveAfter)
        {
            if (move.GameObject.GetChar() == (char)Characters.Crate &&
                moveAfter.GameObject.GetChar() == (char)Characters.Tile)
            {
                SwapTwo(move, moveAfter, true);
                if (_isOnSpecialSquare)
                {
                    move.GameObject.SetChar(_tempChar);
                    _isOnSpecialSquare = false;
                }
                SwapTwo(_playerObject, move);
                return true;
            }

            if (move.GameObject.HasChest)
            {
                if (_isOnSpecialSquare)
                    move.GameObject.SetChar(_tempChar);
                else
                {
                    _isOnSpecialSquare = true;
                    _tempChar = (char)Characters.Destination;
                    move.GameObject.SetChar((char)Characters.Tile);
                }
                _tempChar = (char)Characters.Destination;
                move.GameObject.HasChest = false;
                SwapTwo(_playerObject, move);
                moveAfter.GameObject.SetChar((char)Characters.Crate);
            }

            if (move.GameObject.GetChar() == (char)Characters.Crate &&
                 moveAfter.GameObject.GetChar() == (char)Characters.Destination)
            {
                moveAfter.GameObject.HasChest = true;
                moveAfter.GameObject.SetChar((char)Characters.CrateOnDestination);
                if (_isOnSpecialSquare)
                {
                    move.GameObject.SetChar(_tempChar);
                    _isOnSpecialSquare = false;
                }
                else
                    move.GameObject.SetChar((char)Characters.Tile);
                SwapTwo(_playerObject, move);
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
            if (CheckCrateMove(_playerObject.ObjectAbove, _playerObject.ObjectAbove.ObjectAbove))
                return currentLevel;
            return currentLevel;
        }


        public LinkedList MoveLeft(LinkedList currentLevel)
        {
            if (NormalMove(_playerObject.ObjectPrevious))
                return currentLevel;
            if (MoveOntoDestinationOrTrap(_playerObject.ObjectPrevious))
                return currentLevel;
            if (CheckCrateMove(_playerObject.ObjectPrevious, _playerObject.ObjectPrevious.ObjectPrevious))
                return currentLevel;
            return currentLevel;
        }

        public LinkedList MoveDown(LinkedList currentLevel)
        {
            if (NormalMove(_playerObject.ObjectBelow))
                return currentLevel;
            if (MoveOntoDestinationOrTrap(_playerObject.ObjectBelow))
                return currentLevel;
            if (CheckCrateMove(_playerObject.ObjectBelow, _playerObject.ObjectBelow.ObjectBelow))
                return currentLevel;
            return currentLevel;
        }

        public LinkedList MoveRight(LinkedList currentLevel)
        {
            if (NormalMove(_playerObject.ObjectNext))
                return currentLevel;
            if (MoveOntoDestinationOrTrap(_playerObject.ObjectNext))
                return currentLevel;
            if (CheckCrateMove(_playerObject.ObjectNext, _playerObject.ObjectNext.ObjectNext))
                return currentLevel;
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
                    if (columns.GameObject.GetChar() == (char)Characters.Destination ||
                        columns.GameObject.GetChar() == (char)Characters.Crate)
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