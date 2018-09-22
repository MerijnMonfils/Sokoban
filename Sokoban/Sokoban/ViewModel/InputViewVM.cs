using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class InputViewVM
    {
        private MainView _view;
        private OutputViewVM _output;
        private ParseLevelVM _level;

        public InputViewVM()
        {
            _view = new MainView();
            _output = new OutputViewVM();
            _level = new ParseLevelVM();
        }

        public void startLevel(string x)
        {
            switch (x)
            {
                case "1":
                    _output.OutputLevel(_level.ReadFiles(x));
                    break;
                case "2":
                    _output.OutputLevel(_level.ReadFiles(x));
                    break;
                case "3":
                    _output.OutputLevel(_level.ReadFiles(x));
                    break;
                case "4":
                    _output.OutputLevel(_level.ReadFiles(x));
                    break;
                default:
                    _view.WriteLine("Error, please choose correctly!");
                    break;

            }
        }
        
    }
}