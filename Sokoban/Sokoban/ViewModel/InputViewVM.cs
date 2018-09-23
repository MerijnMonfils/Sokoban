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

        public void StartLevel(string x)
        {
            if (x.Equals("s"))
            {
                Environment.Exit(0);
            }
            try
            {
                int input = int.Parse(x);
                switch (input)
                {
                    case 1:
                        _output.OutputLevel(_level.ReadFiles(input));
                        break;
                    case 2:
                        _output.OutputLevel(_level.ReadFiles(input));
                        break;
                    case 3:
                        _output.OutputLevel(_level.ReadFiles(input));
                        break;
                    case 4:
                        _output.OutputLevel(_level.ReadFiles(input));
                        break;
                    default:
                        AskAgain();
                        break;

                }
            }
            catch (Exception e)
            {
                _view.WriteLine("Something went horribly wrong...");
            }
        }

        private void AskAgain()
        {
            _view.WriteLine("?");
            _view.StartListening();
        }
        
    }
}