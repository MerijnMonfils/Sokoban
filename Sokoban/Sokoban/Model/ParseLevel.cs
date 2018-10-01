using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class ParseLevel

    {
        public int _amount { get; private set; }

        private string _path;
        private string[] _levels; 
        private DirectoryInfo _di;

        private Characters _characters;
        public List<Object> level = new List<Object>();

        public ParseLevel()
        {
            _characters = new Characters();
        }

        public void CountLevels()
        {
            this._path = Environment.CurrentDirectory;
            this._path = _path.Substring(0, (_path.Length - 9)) + "Mazes";
            this._di = new DirectoryInfo(_path);
            _levels = new string[_di.GetFiles().Count()];
            foreach (FileInfo f in _di.GetFiles())
            {
                _levels[_amount] = f.FullName;
                this._amount = _amount + 1; // amount of files in map
            }
        }
        public char[,] ReadFiles(int a)
        {
            //Size of this variable is the amount of rows
            string[] lines = System.IO.File.ReadAllLines(_levels[a - 1]);

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

            char[,] first = new char[rows,columns];
            for(int x = 0; x < rows; x++)
            {
                for(int i = 0; i < (lines[x].Length); i++)
                {
                   first[x,i] = CheckCharacterAt(lines[x], i);
                }
            }
         
            return first;
        }

        private object CheckCharacterAt(string line, int postionInRow)
        {
            
            char c = line[postionInRow];
            char value = ' ';
            switch (c)

            {
                case '#':
                    value = '#';
                    level.Add(new Wall());
                   
                    break;
                case 'O':
                    value = 'O';
                    level.Add(new Crate());
                    break;
                case '.':
                    value = '.';
                    level.Add(new Tile());
                    break;
                case '@':
                    value = '@';
                    level.Add(new Player());
                    break;
                case 'X':
                    value = 'X';
                    level.Add(new Destination());
                    break;
                default: // not accepted characters
                    level.Add(new Wall());
                    break;
            }
            return level;
        }

    

       
    }
}