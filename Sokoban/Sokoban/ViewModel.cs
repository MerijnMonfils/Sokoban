using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class ViewModel
    {
        private InputView _inputView;
        private OutputView _outputView;
        private ParseLevels _parseLevels;
        private Tile _tile;

        public ViewModel()
        {
            _inputView = new InputView();
            _outputView = new OutputView();
            _parseLevels = new ParseLevels();
            _tile = new Tile();

            this.ReadFiles();
        }

        private void ReadFiles()
        {
            // read all files in folder
            // check files -> how much
            // send file to -> parseLevels 
        }
    }
}