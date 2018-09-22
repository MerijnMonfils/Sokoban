using System;
using System.Windows.Forms;

namespace Sokoban
{
    class Program
    {
        static void Main()
        {
           MainView output = new MainView();
            ParseLevelVM parse = new ParseLevelVM();

            output.startScreen();

            
        }
    }
    
}
