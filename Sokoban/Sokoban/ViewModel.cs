using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            this.OpenFile();
        }

        private void OpenFile()
        {
            // select file
            // check file
            // send file to -> parseLevels
        }
    }
}