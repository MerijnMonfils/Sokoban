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

        }

        public void startLevel(string x)
        {

            string f = Console.ReadLine();
            switch (f)
            {
                case "1":
                    Level.ReadFiles(f);
                    break;
                case "2":
                    Level.ReadFiles(f);
                    break;
                case "3":
                    Level.ReadFiles(f);
                    break;
                case "4":
                    Level.ReadFiles(f);
                    break;
                default:
                    Environment.Exit(0);
                    break;

            }
        }


    }
}