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
        private ParseLevel _level;

        public InputViewVM(MainView mainView, OutputViewVM output)
        {
            _view = mainView;
            _output = output;
            _level = new ParseLevel();
        }

        public int GetAmountOfLevels()
        {
            return _level._amount;
        }

        public void StartLevel(string x)
        {
            try
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
                        _view.StartListening();
                        break;

                }
            }
            catch (Exception e)
            {
                _view.WriteLine( "ERROR: " + e.StackTrace + ", please choose correctly!");
                _view.StartListening();
            }
        }
        
    }
}