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

        public OutputViewVM()
        {
            _parseLevels = new ParseLevel();
            _mainView = new MainView(this, _parseLevels);
        }

        public void Start()
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
            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int i = 0; i < level.GetLength(1); i++)
                {
                    _mainView.Write(level.GetValue(x, i).ToString());
                }
                _mainView.WriteLine("");
            }
            _mainView.StartListening();
        }
    }
}





