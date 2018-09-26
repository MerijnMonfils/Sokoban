using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sokoban
{
    public class OutputViewVM
    {
        private MainView _mainView;
        private ParseLevel _parseLevels;
        private GameLogic logic;

        public char[,] _currentLevel; // the current array thats being used
        private int _currentLevelNumber { get; set; }
        private bool isPlaying;

        public OutputViewVM()
        {
            _parseLevels = new ParseLevel();
            _mainView = new MainView(this, _parseLevels);
        }

        public void ShowMenu()
        {
            _parseLevels.CountLevels();
            _mainView.StartScreen();
            _mainView.StartListening();
        }

        public void SetCurrentLevel(char[,] level, int lvlNumb)
        {
            _currentLevel = level;
            _currentLevelNumber = lvlNumb;
        }

        public char[,] getCurrentLevelArray()
        {
            return _currentLevel;
        }

        public void OutputLevel(char[,] level)
        {
            Console.Clear();

            _mainView.WriteLine("'s' to leave\n'm' to show menu\n'r' to reset");
            _mainView.WriteLine("");

            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int i = 0; i < level.GetLength(1); i++)
                {
                    _mainView.Write(level.GetValue(x, i).ToString());
                }
                _mainView.WriteLine("");
            }

        }

        public void StartPlaying()
        {
            logic = new GameLogic();
            isPlaying = true;
            while (isPlaying)
            {
                if (!logic.gameFinished(_currentLevel))
                {
                    Console.WriteLine("Congratulations. You finished the level!");
                    Console.WriteLine("Press M to return to Menu");
                    Console.Write("Press S to close application");
                }
                checkInput(Console.ReadKey().Key, logic);
            }
        }

        private void checkInput(ConsoleKey input, GameLogic logic)
        {
            if (input == ConsoleKey.S)
            {
                Environment.Exit(0);
            }

            if (input == ConsoleKey.M)
            {
                Console.Clear();
                isPlaying = false;
                _mainView.StartScreen();
                _mainView.StartListening();
            }

            if (input == ConsoleKey.R)
            {
                InputViewVM v = new InputViewVM(_mainView, this, _parseLevels);
                Console.Clear();
                v.StartLevel("" + _currentLevelNumber);
            }

            if(input == ConsoleKey.UpArrow)
            {
                // _currentLevel = logic.movePlayerUp(_currentLevel);
                _currentLevel = logic.MoveToTop(_currentLevel);
                this.OutputLevel(_currentLevel);

            } else if (input == ConsoleKey.DownArrow)
            {
                _currentLevel = logic.MoveToBottom(_currentLevel);
                this.OutputLevel(_currentLevel);
            } else if (input == ConsoleKey.LeftArrow)
            {
                _currentLevel = logic.MoveToLeft(_currentLevel);
                this.OutputLevel(_currentLevel);
                
            } else if (input == ConsoleKey.RightArrow)
            {
                _currentLevel = logic.MoveToRight(_currentLevel);
                this.OutputLevel(_currentLevel);

            }
        }
    }
}





