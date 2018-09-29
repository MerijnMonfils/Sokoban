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

        // file reading resources
        private string _path;
        private string[] _files; 
        private DirectoryInfo _di;

        private Characters _characters;
        private LinkedList[] _allLevels;

        public ParseLevel()
        {
            _characters = new Characters();
        }

        public void CountLevels()
        {
            this._path = Environment.CurrentDirectory;
            this._path = _path.Substring(0, (_path.Length - 9)) + "Mazes";
            this._di = new DirectoryInfo(_path);
            _files = new string[_di.GetFiles().Count()];
            foreach (FileInfo f in _di.GetFiles())
            {
                _files[_amount] = f.FullName;
                this._amount = _amount + 1; // amount of files in map
            }
            _allLevels = new LinkedList[_amount];
        }

        public void SaveCollection()
        {
            // loop through all files
            // foreach file create a linkedObject which gets updated for each after

            // create linkedlist
            LinkedList list;

            // execute for each file
            for (int x = 0; x < _amount; x++) 
            {
                // initialize linkedlist
                list = new LinkedList();

                // read all lines in current file
                string[] lines = System.IO.File.ReadAllLines(_files[x]);
                
                // setup linkedlist
                for (int z = 0; z < lines.Length; z++) // for each row
                {
                    for (int i = 0; i < (lines[z].Length); i++) // for length of row
                    {
                        list.InsertInRow(CheckCharacterAt(lines[z], i), z, i);
                    }
                }
                // finally add current linkedlist to array of all levels
                _allLevels[x] = list;
            }
        }

        public LinkedList GetLevel(int input)
        {
            return _allLevels[input];
        }


        // TODO REMOVE THIS METHOD
        public char[,] ReadFiles(int a)
        {
            //Size of this variable is the amount of rows
            string[] lines = System.IO.File.ReadAllLines(_files[a - 1]);

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
                   // first[x,i] = CheckCharacterAt(lines[x], i);
                }
            }
            return first;
        }

        // check symbol in file -> returns new gameObject
        private LinkedGameObject CheckCharacterAt(string line, int postionInRow)
        {
            LinkedGameObject newGameObject = new LinkedGameObject();
            char c = line[postionInRow];
            switch (c)
            {
                case '#':
                    newGameObject.SetGameObject(new WallObject());
                    break;
                case 'O':
                    newGameObject.SetGameObject(new ChestObject());
                    break;
                case '.':
                    newGameObject.SetGameObject(new TileObject());
                    break;
                case '@':
                    newGameObject.SetGameObject(new PlayerObject());
                    break;
                case 'X':
                    newGameObject.SetGameObject(new DestinationObject());
                    break;
     
                default: // not accepted characters
                    newGameObject.SetGameObject(new WallObject());
                    break;
            }
            return new LinkedGameObject();
        }
        
    }
}