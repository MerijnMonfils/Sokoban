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
        private GameLogic logic;

        private int _currentLevelNumber { get; set; }
        private LinkedList _currentLevel { get; set; }
        private bool isPlaying;

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

        public void LoadLevel(int level)
        {
            _currentLevel = _parseLevels.GetLevel(level);
            OutputLevel();
        }

        public void OutputLevel()
        {
            Console.Clear();
            
            // Rows
            var rows = _currentLevel.First;
            // Columns
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

                // LOOP \\
            // We know First
            // We know Last
            // First knows something below -> save to temp 
            // if temp in next row does not have a neighbour below. Finished

        }
    }
}





