using Sokoban.Model;
using Sokoban.View;
using System;

namespace Sokoban.ViewModel
{
    public class InputViewVM
    {
        private OutputViewVM _output;
        private MainView _mainView;
        private GameLogic _logic;

        public InputViewVM(OutputViewVM output, MainView view)
        {
            _mainView = view;
            _output = output;
        }

        public void LoadLevel(ConsoleKey input)
        {
            if (input == ConsoleKey.S)
            {
                Environment.Exit(0);
            }
            try
            {
                string x = input.ToString().Substring(1, 1);
                int i = int.Parse(x);
                _logic = new GameLogic();
                _output.LoadLevel(i - 1);
                _logic.SetPlayer(_output._currentLevel);
                _output.ShowLevel();
            }
            catch (Exception e)
            {
                _mainView.StartListening();
            }
        }


        public void PlayLevel(ConsoleKey key)
        {
            if (key == ConsoleKey.S)
            {
                Environment.Exit(0);
            }
            else if (key == ConsoleKey.R)
            {
                _output.ReloadLevel(_output.CurrentLevelNumber);
                _logic.GameWon = false;
                _logic.IsOnSpecialSquare = false;
                _logic.SetPlayer(_output._currentLevel);
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.M)
            {
                _output.ReshowMenu();
            }
            else if (key == ConsoleKey.L && _logic.GameWon)
            {
                if (_output.GetAmountOfLevels() <= _output.CurrentLevelNumber + 1)
                    _output.ReshowMenu();
                _output.LoadLevel(_output.CurrentLevelNumber + 1);
                _logic.GameWon = false;
                _logic.IsOnSpecialSquare = false;
                _logic.SetPlayer(_output._currentLevel);
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.UpArrow && !_logic.GameWon || key == ConsoleKey.W && !_logic.GameWon)
            {
                _output._currentLevel = _logic.MoveUp(_output._currentLevel);
                CheckGameOver();
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.LeftArrow && !_logic.GameWon || key == ConsoleKey.A && !_logic.GameWon)
            {
                _output._currentLevel = _logic.MoveLeft(_output._currentLevel);
                CheckGameOver();
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.DownArrow && !_logic.GameWon || key == ConsoleKey.S && !_logic.GameWon)
            {
                _output._currentLevel = _logic.MoveDown(_output._currentLevel);
                CheckGameOver();
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.RightArrow && !_logic.GameWon || key == ConsoleKey.D && !_logic.GameWon)
            {
                _output._currentLevel = _logic.MoveRight(_output._currentLevel);
                CheckGameOver();
                _output.ShowLevel();
            }
            else
            {
                _mainView.StartPlaying();
            }

        }

        private void CheckGameOver()
        {
            if (_logic.GameFinished(_output._currentLevel))
            {
                _output.ShowLevel(true);
                _mainView.WriteLine("Congratulations, you have completed the level");
                _mainView.WriteLine("Press M to go to Menu");
                _mainView.WriteLine("Press R to play again");
                _mainView.WriteLine("Press L to play next level");
                _mainView.StartPlaying();
            }
        }
    }
}