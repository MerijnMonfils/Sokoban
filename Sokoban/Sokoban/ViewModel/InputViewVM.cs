using Sokoban.Model;
using Sokoban.View;
using System;

namespace Sokoban.ViewModel
{
    public class InputViewVM
    {
        private OutputViewVM _output;
        private MainView _view;
        private GameLogic logic;

        public InputViewVM(OutputViewVM output, MainView view)
        {
            _view = view;
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
                string x = input.ToString().Substring(1,1);
                int i = int.Parse(x);
                logic = new GameLogic();
                _output.LoadLevel(i - 1);
                logic.SetPlayer(_output._currentLevel);
                _output.ShowLevel();
            } catch (Exception e)
            {
                _view.StartListening();
            }
        }

        public void PlayLevel(ConsoleKey key)
        {
            try { 
            if (key == ConsoleKey.S)
            {
                Environment.Exit(0);
            }
            else if (key == ConsoleKey.R)
            {
                _output.LoadLevel(_output._currentLevelNumber);
            }
            else if (key == ConsoleKey.M)
            {
                _output.ReshowMenu();
            }
            else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                _output._currentLevel = logic.MoveUp(_output._currentLevel);
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
            {
                _output._currentLevel = logic.MoveLeft(_output._currentLevel);
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                _output._currentLevel = logic.MoveDown(_output._currentLevel);
                _output.ShowLevel();
            }
            else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
            {
                _output._currentLevel = logic.MoveRight(_output._currentLevel);
                _output.ShowLevel();
            }
            else
            {
                _view.StartPlaying();
            }
        } catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.Read();
            }
        }
    }
}