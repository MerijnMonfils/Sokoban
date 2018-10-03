using System;
using System.Windows.Forms;
using Sokoban.ViewModel;

namespace Sokoban
{
    class Program
    {
        static void Main()
        {
            OutputViewVM output = new OutputViewVM();
            output.ShowMenu();
        }
    }
    
}
