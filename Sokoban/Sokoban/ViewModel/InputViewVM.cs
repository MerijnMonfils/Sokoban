using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sokoban.Model;
namespace Sokoban.ViewModel
{
    public class InputViewVM
    {
        private OutputViewVM _output;
        private ParseLevel _level;

        public InputViewVM(OutputViewVM output, ParseLevel level)
        {
            _output = output;
            _level = level;
        }

        public int GetAmountOfLevels()
        {
            return _level._amount;
        }

        public void StartLevel(string input)
        {
            if (input.Equals("s"))
            {
                Environment.Exit(0);
            }

            try
            {
                int x = int.Parse(input);
                switch (x)
                {
                    case 1:
                        SetupLevel(_level.ReadFiles(x), x);
                        break;
                    case 2:
                        SetupLevel(_level.ReadFiles(x), x);
                        break;
                    case 3:
                        SetupLevel(_level.ReadFiles(x), x);
                        break;
                    case 4:
                        SetupLevel(_level.ReadFiles(x), x);
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

        private void SetupLevel(char[,] level, int lvlNumb)
        {
            _output.SetCurrentLevel(level, lvlNumb);
            _output.OutputLevel(level);
            _output.StartPlaying();
        }

        private void AskAgain()
        {
            // _view.WriteLine("?");
            // _view.StartListening();
        }

    }
}