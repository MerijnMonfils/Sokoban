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
    public class ViewModel
    {
        private InputView _inputView;
        private OutputView _outputView;
        private ParseLevels _parseLevels;


        public ViewModel()
        {
            _inputView = new InputView();
            _outputView = new OutputView();
            _parseLevels = new ParseLevels();

        }

     
        }

    }


