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

        public InputViewVM(MainView mainView, OutputViewVM output, ParseLevel level)
        {
            _view = mainView;
            _output = output;
            _level = level;
        }

        public int GetAmountOfLevels()
        {
            return _level._amount;
        }

        public void StartLevel(int x)
        {
            
            try
            {
                string input = x.ToString();
                if (x.Equals("s"))
                {
                    Environment.Exit(0);
                }
                switch (x)
                {
                    case 1:
                        _output.OutputLevel(_level.ReadFiles(x));
                        break;
                    case 2:
                        _output.OutputLevel(_level.ReadFiles(x));
                        break;
                    case 3:
                        _output.OutputLevel(_level.ReadFiles(x));
                        break;
                    case 4:
                        _output.OutputLevel(_level.ReadFiles(x));
                        break;
                    default:
                        AskAgain();
                        break;

                }
            }
            catch (Exception e)
            {
                AskAgain();
            }
        }

        private void AskAgain()
        {
            _view.WriteLine("?");
            _view.StartListening();
        }
        
    }
}