using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class InputViewVM
    {

        public ParseLevelVM Level;

        public InputViewVM()
        {
            Level = new ParseLevelVM();
        }

        public void startLevel(string x)
        {

            
            switch (x)
            {
                case "1":
                    Level.ReadFiles(x);
                    break;
                case "2":
                    Level.ReadFiles(x);
                    break;
                case "3":
                    Level.ReadFiles(x);
                    break;
                case "4":
                    Level.ReadFiles(x);
                    break;
                default:
                    Environment.Exit(0);
                    break;

            }
        }


    }
}