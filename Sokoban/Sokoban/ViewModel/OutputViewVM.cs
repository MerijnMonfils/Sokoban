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

        private char[,] _currentLevel; // the current array thats being used
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

        public void SetCurrentLevel(char[,] level)
        {
            _currentLevel = level;
        }

        public void OutputLevel(char[,] level)
        {
            Console.Clear();

            _mainView.WriteLine("Press 's' to leave and 'm' to show menu.");
            _mainView.WriteLine("");

            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int i = 0; i < level.GetLength(1); i++)
                {
                    _mainView.Write(level.GetValue(x, i).ToString());
                }
                _mainView.WriteLine("");
            }

            isPlaying = true;
        }

        public void StartPlaying()
        {
            while (isPlaying)
            {
                checkInput(Console.ReadKey().Key);
            }
        }

        private void checkInput(ConsoleKey input)
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

            if(input == ConsoleKey.UpArrow)
            {
                
            } else if (input == ConsoleKey.DownArrow)
            {
                
            } else if (input == ConsoleKey.LeftArrow)
            {
                
            } else if (input == ConsoleKey.RightArrow)
            {
                
            }
        }
    }
}





