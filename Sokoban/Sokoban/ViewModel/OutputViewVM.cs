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


        public OutputViewVM()
        {
            _mainView = new MainView(this);
            _parseLevels = new ParseLevel();
        }

        public void Start()
        {
            _parseLevels.CountLevels();
            _mainView.StartScreen();
            _mainView.StartListening();
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





