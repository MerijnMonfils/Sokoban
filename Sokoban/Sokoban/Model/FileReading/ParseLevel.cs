using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class ParseLevel
    {
        // file reading resources
        private string _path;
        private string[] _files;
        private DirectoryInfo _di;

        // list of levels
        public int _amount { get; private set; }
        private LinkedList[] _allLevels;

        public void CountLevels()
        {
            this._path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Mazes");
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
                        list.InsertInRow(CheckCharacterAt(lines[z], i), z);
                    }
                }
                // finally add current linkedlist to array of all levels
                _allLevels[x] = list;
            }
        }

        public LinkedList ReloadLevel(int level)
        {
            LinkedList list = new LinkedList();
            // read all lines in current file
            string[] lines = System.IO.File.ReadAllLines(_files[level]);

            // setup linkedlist
            for (int z = 0; z < lines.Length; z++) // for each row
            {
                for (int i = 0; i < (lines[z].Length); i++) // for length of row
                {
                    list.InsertInRow(CheckCharacterAt(lines[z], i), z);
                }
            }
            // finally add current linkedlist to array of all levels
            _allLevels[level] = list;
            return _allLevels[level];
        }

        public LinkedList GetLevel(int input)
        {
            return _allLevels[input];
        }

        // check symbol in file -> returns new gameObject
        private BaseObject CheckCharacterAt(string line, int postionInRow)
        {
            char c = line[postionInRow];
            switch (c)
            {
                case (char) Characters.Wall:
                    return new WallObject();
                case (char) Characters.Crate:
                    return new CrateObject();
                case (char) Characters.Tile:
                    return new TileObject();
                case (char) Characters.Player:
                    return new PlayerObject();
                case (char) Characters.Destination:
                    return new DestinationObject();
                case (char) Characters.Trap:
                    return new TrapObject(false);
                case (char)Characters.OpenTrap:
                    return new TrapObject(true);
                case (char) Characters.Worker:
                    return new WorkerObject(false);
                case (char) Characters.WorkerSleeping:
                    return new WorkerObject(true);
                default:
                    return new WallObject();
            }
        }

    }
}