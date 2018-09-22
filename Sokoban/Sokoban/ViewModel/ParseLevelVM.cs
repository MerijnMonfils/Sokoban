using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class ParseLevelVM
    {
        private int _amount { get; set; }

        private enum Characters{
            Wall = '#',
            Tile = '.',
            Destination = 'x',
            Player = '@',
            Chest = 'o'
        }

        public void ReadAllFiles()
        {
            string path = Environment.CurrentDirectory;
            path = path.Substring(0, (path.Length-9)) + "Mazes";
            DirectoryInfo di = new DirectoryInfo(path);
            foreach(FileInfo f in di.GetFiles())
            {
                ReadSelectedFile(f.FullName);
                _amount = _amount + 1; // amount of files in map
            }
        }
        
        private void ReadSelectedFile(string name)
        {
            string[] lines = System.IO.File.ReadAllLines(name);

            //Size of this variable is the amount of columns
            string longest = lines.OrderByDescending(s => s.Length).First();

            //Amount of characters in the txt file
            int amountOfChars = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                //Add the lenght of each row to determine the amount of chars
                amountOfChars += lines[i].Length;
            }

            //Rows and columns are now dynamic depending on the file input. 
            int rows = lines.Length;
            int columns = longest.Length;

            char[,] first = new char[rows, columns];
            for (int x = 0; x < rows; x++)
            {
                for (int i = 0; i < (lines[x].Length); i++)
                {
                    first[x, i] = CheckCharacterAt(lines[x], i);
                }
            }

            // code to read the file
            for (int x = 0; x < first.GetLength(0); x++)
            {
                for (int i = 0; i < first.GetLength(1); i++)
                {
                    Console.Write(first.GetValue(x, i));
                }
                Console.WriteLine();
            }
            Console.Read();
        }

        private char CheckCharacterAt(string line, int postionInRow)
        {
            char c = line[postionInRow];
            char value;
            switch (c)
            {
                case (char)Characters.Wall:
                    value = (char)Characters.Wall;
                    break;
                case (char)Characters.Tile:
                    value = (char)Characters.Tile;
                    break;
                case (char)Characters.Player:
                    value = (char)Characters.Player;
                    break;
                case (char)Characters.Destination:
                    value = (char)Characters.Destination;
                    break;
                case (char)Characters.Chest:
                    value = (char)Characters.Chest;
                    break;
                default: // not accepted characters
                    value = (char)Characters.Wall;
                    break;
            }
            return value;
        }
    }
}