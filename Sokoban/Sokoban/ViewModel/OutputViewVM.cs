using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sokoban.Model;
using Sokoban.View;

namespace Sokoban.ViewModel

{
    public class OutputViewVM
    {
        private MainView _mainView;
        private ParseLevel _parseLevels;

        public LinkedList _currentLevel { get; set; }
        public int _currentLevelNumber { get; private set; }

        public OutputViewVM()
        {
            _parseLevels = new ParseLevel();
            _mainView = new MainView(this);
        }

        public void ShowMenu()
        {
            _parseLevels.CountLevels();
            _parseLevels.SaveCollection();
            _mainView._amount = _parseLevels._amount;
            _mainView.StartScreen();
            _mainView.StartListening();            
        }

        public void ReshowMenu()
        {
            _mainView.Clear();
            _mainView.StartScreen();
            _mainView.StartListening();
        }

        public void LoadLevel(int level)
        {
            _currentLevel = _parseLevels.GetLevel(level);
            _currentLevelNumber = level;
        }

        public void ReloadLevel(int currentLevelNumber)
        {
            _currentLevel = _parseLevels.ReloadLevel(currentLevelNumber);
        }

        public void ShowLevel()
        {
            _mainView.Clear();
            
            var rows = _currentLevel.First;
            var columns = _currentLevel.First;

            while(rows != null)
            {
                while (columns != null)
                {
                    _mainView.Write(columns.GameObject.GetChar() + "");
                    columns = columns.ObjectNext;
                }
                _mainView.WriteLine("");
                rows = rows.ObjectBelow;
                columns = rows;
            }
            _mainView.StartPlaying();
        }
    }
}





