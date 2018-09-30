﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sokoban.Model;
using Sokoban.View;

namespace Sokoban.ViewModel
{
    public class InputViewVM
    {
        private OutputViewVM _output;
        private MainView _view;

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
            else if (input == ConsoleKey.D1)
            {
                _output.LoadLevel(0);
            }
            else if (input == ConsoleKey.D2)
            {
                _output.LoadLevel(1);
            }
            else if (input == ConsoleKey.D3)
            {
                _output.LoadLevel(2);
            }
            else if (input == ConsoleKey.D4)
            {
                _output.LoadLevel(3);
            }
            else if (input == ConsoleKey.D5)
            {
                _output.LoadLevel(4);
            }
            else
            {
                _view.StartListening();
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
                _output.LoadLevel(_output._currentLevelNumber);
            }
            else if (key == ConsoleKey.M)
            {
                _output.ReshowMenu();
            }
            else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                // Up movement
            }
            else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
            {
                // Left movement
            }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                // Down movement
            }
            else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
            {
                // Right movement
            }
            else
            {
                _view.StartPlaying();
            }
        }
    }
}