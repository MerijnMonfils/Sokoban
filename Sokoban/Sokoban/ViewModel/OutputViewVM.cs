using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sokoban
{
    public class OutputViewVM
    {
        private InputView _inputView;
        private OutputView _outputView;
        private ParseLevelVM _parseLevels;


        public OutputViewVM()
        {
            _inputView = new InputView();
            _outputView = new OutputView();
            _parseLevels = new ParseLevelVM();

            _parseLevels.ReadFiles(); // reads all .txt files\
        }

    }

}


