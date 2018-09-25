using System;

namespace Sokoban
{
    public class GameLogic
    {
        private Characters _characters;

        public GameLogic()
        {
            _characters = new Characters();
        }

        public char[,] MoveToRight(char[,] level)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int k = 0; k < level.GetLength(1); k++)
                {
                    if (level[i, k].Equals(_characters._truck))
                    {

                        //going forward with a truck
                        if (level[i, k + 1].Equals(_characters._tile))
                        {
                            level[i, k + 1] = _characters._truck;
                            level[i, k] = _characters._tile;
                            return level;
                        }
                        //moving onto a Destination tile
                        if (level[i, k + 1].Equals(_characters._destination))
                        {
                            level[i, k + 1] = _characters._truck;
                            level[i, k] = _characters._tile;
                            return level;
                        }

                        //Pushing a crate to the next tile
                        if (k + 2 < level.GetLength(1) && level[i, k + 1].Equals(_characters._crate) &&
                            level[i, k + 2].Equals(_characters._tile))
                        {
                            level[i, k] = _characters._tile;
                            level[i, k + 1] = _characters._truck;
                            level[i, k + 2] = _characters._crate;
                            return level;

                        }

                        //pushing a crate to the destination.
                        if (k + 2 < level.GetLength(1) && level[i, k + 1].Equals(_characters._crate) &&
                            level[i, k + 2].Equals(_characters._destination))
                        {
                            level[i, k] = _characters._tile;
                            level[i, k + 1] = _characters._crate;
                            level[i, k + 2] = _characters._crateOnDestination;
                            return level;
                        }


                    }
                }
            }

            return level;
        }

        public char[,] MoveToLeft(char[,] level)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int k = 0; k < level.GetLength(1); k++)
                {
                    if (level[i, k].Equals(_characters._truck))
                    {

                        //going forwaard with a truck
                        if (level[i, k - 1].Equals(_characters._tile))
                        {
                            level[i, k - 1] = _characters._truck;
                            level[i, k] = _characters._tile;
                            return level;
                        }

                        //Pushing a crate to the next tile
                        if (k - 2 >= 0 && level[i, k - 1].Equals(_characters._crate) &&
                            level[i, k - 2].Equals(_characters._tile))
                        {
                            level[i, k] = _characters._tile;
                            level[i, k - 1] = _characters._truck;
                            level[i, k - 2] = _characters._crate;
                            return level;

                        }

                        //pushing a crate to the destination.
                        if (k - 2 >= 0 && level[i, k - 1].Equals(_characters._crate) &&
                            level[i, k - 2].Equals(_characters._destination))
                        {
                            level[i, k] = _characters._tile;
                            level[i, k - 1] = _characters._crate;
                            level[i, k - 2] = _characters._crateOnDestination;
                            return level;
                        }


                    }
                }
            }

            return level;
        }

        public char[,] MoveToTop(char[,] level)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int k = 0; k < level.GetLength(1); k++)
                {
                    if (i - 1 >= 0 && level[i, k].Equals(_characters._truck))
                    {
                        //Going downwards with the truck
                        if (level[i - 1, k].Equals(_characters._tile))
                        {
                            level[i - 1, k] = _characters._truck;
                            level[i, k] = _characters._tile;
                            return level;
                        }

                        //Pushing a crate to the next tile
                        if (i - 2 >= 0 && level[i - 1, k].Equals(_characters._crate) &&
                            level[i - 2, k].Equals(_characters._tile))
                        {
                            level[i, k] = _characters._tile;
                            level[i - 1, k] = _characters._truck;
                            level[i - 2, k] = _characters._crate;
                            return level;

                        }

                        //pushing a crate to the destination.
                        if (i - 2 >= 0 && level[i - 1, k].Equals(_characters._crate) &&
                            level[i - 2, k].Equals(_characters._destination))
                        {
                            level[i, k] = _characters._tile;
                            level[i - 1, k] = _characters._crate;
                            level[i - 2, k] = _characters._crateOnDestination;
                            return level;
                        }
                    }
                }
            }

            return level;
        }

        public char[,] MoveToBottom(char[,] level)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int k = 0; k < level.GetLength(1); k++)
                {
                    if (i + 1 < level.GetLength(0) && level[i, k].Equals(_characters._truck))
                    {
                        //Going downwards with the truck
                        if (level[i + 1, k].Equals(_characters._tile))
                        {
                            level[i + 1, k] = _characters._truck;
                            level[i, k] = _characters._tile;
                            return level;
                        }

                        //Pushing a crate to the next tile
                        if (i + 2 < level.GetLength(0) && level[i + 1, k].Equals(_characters._crate) &&
                            level[i + 2, k].Equals(_characters._tile))
                        {
                            level[i, k] = _characters._tile;
                            level[i + 1, k] = _characters._truck;
                            level[i + 2, k] = _characters._crate;
                            return level;

                        }

                        //pushing a crate to the destination.
                        if (i + 2 < level.GetLength(0) && level[i + 1, k].Equals(_characters._crate) &&
                            level[i + 2, k].Equals(_characters._destination))
                        {
                            level[i, k] = _characters._tile;
                            level[i + 1, k] = _characters._crate;
                            level[i + 2, k] = _characters._crateOnDestination;            
                            return level;
                        }
                    }
                }
            }

            return level;
        }

        public Boolean gameFinished(char[,] level)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int k = 0; k < level.GetLength(1); k++)
                {
                    if (level[i, k].Equals(_characters._truck))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}