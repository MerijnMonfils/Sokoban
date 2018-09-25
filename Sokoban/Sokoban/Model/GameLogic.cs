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
                        if (level[i, k + 1].Equals(_characters._tile))
                        {
                            level[i, k + 1] = _characters._truck;
                            level[i, k] = _characters._tile;
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
                        if (level[i, k - 1].Equals(_characters._tile))
                        {
                            level[i, k - 1] = _characters._truck;
                            level[i,k] = _characters._tile;
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
                    if (i-1 >= 0 && level[i, k].Equals(_characters._truck))
                    {
                        if (level[i-1, k].Equals(_characters._tile))
                        {
                            level[i-1, k] = _characters._truck;
                            level[i, k] = _characters._tile;
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
                    if (i + 1 >= 0 && level[i, k].Equals(_characters._truck))
                    {
                        if (level[i + 1, k].Equals(_characters._tile))
                        {
                            level[i + 1, k] = _characters._truck;
                            level[i, k] = _characters._tile;
                            return level;
                        }
                    }
                }
            }
            return level;
        }
    }
}