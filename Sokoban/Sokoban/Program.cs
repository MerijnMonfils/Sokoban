using System;
using System.Windows.Forms;

namespace Sokoban
{
    class Program
    {
        static void Main()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.ReadFiles();
        }
    }
    
}
