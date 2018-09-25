using System;

namespace Sokoban
{
    public class GameLogic
    {

        public char[,] MoveToRight(char[,] level)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int k = 0; k < level.GetLength(1); k++)
                {
                    if (level[i, k].Equals('@'))
                    {
                        if (level[i, k + 1].Equals('.'))
                        {
                            level[i, k + 1] = '@';
                            level[i, k] = '.';
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
                    if (level[i, k].Equals('@'))
                    {
                        if (level[i, k - 1].Equals('.'))
                        {
                            level[i, k - 1] = '@';
                            level[i,k] = '.';
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
                    if (i-1 >= 0 && level[i, k].Equals('@'))
                    {
                        if (level[i-1, k].Equals('.'))
                        {
                            level[i-1, k] = '@';
                            level[i, k] = '.';
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
                    if (i + 1 >= 0 && level[i, k].Equals('@'))
                    {
                        if (level[i + 1, k].Equals('.'))
                        {
                            level[i + 1, k] = '@';
                            level[i, k] = '.';
                            return level;
                        }
                    }
                }
            }
            return level;
        }
    }
}